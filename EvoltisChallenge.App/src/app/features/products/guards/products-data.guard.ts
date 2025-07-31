import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { Observable, of, combineLatest } from 'rxjs';
import { tap, filter, take, switchMap } from 'rxjs/operators';
import * as ProductSelectors from '../state/product.selectors';
import * as ProductActions from '../state/product.actions';
import * as ProductCategorySelectors from '../../product-categories/state/product-category.selectors';
import * as ProductCategoryActions from '../../product-categories/state/product-category.actions';
import { LoadingService } from '../../../core/services/loading.service';

@Injectable({ providedIn: 'root' })
export class ProductsDataGuard implements CanActivate, CanActivateChild {
    constructor(
        private store: Store,
        private loadingService: LoadingService
    ) { }

    private checkStoreLoaded(): Observable<boolean> {
        return combineLatest([
            this.store.pipe(select(ProductSelectors.selectAllProducts)),
            this.store.pipe(select(ProductCategorySelectors.selectAllProductCategories))
        ]).pipe(
            take(1),
            switchMap(([products, categories]) => {
                const needsProducts = !products || products.length === 0;
                const needsCategories = !categories || categories.length === 0;

                if (needsProducts || needsCategories) {
                    // Carga los datos que faltan
                    this.loadingService.setLoading(true);

                    if (needsProducts) {
                        this.store.dispatch(ProductActions.loadProducts());
                    }
                    if (needsCategories) {
                        this.store.dispatch(ProductCategoryActions.loadProductCategories());
                    }

                    // Espera a que ambos terminen de cargar
                    return combineLatest([
                        this.store.pipe(select(ProductSelectors.selectProductsLoading)),
                        this.store.pipe(select(ProductCategorySelectors.selectProductCategoriesLoading))
                    ]).pipe(
                        filter(([productsLoading, categoriesLoading]) => !productsLoading && !categoriesLoading),
                        take(1),
                        tap(() => this.loadingService.setLoading(false)),
                        switchMap(() => of(true))
                    );
                } else {
                    // Ya estan cargados
                    console.log('Guard - Data already loaded, allowing access');
                    return of(true);
                }
            })
        );
    }

    canActivate(): Observable<boolean> {
        return this.checkStoreLoaded();
    }

    canActivateChild(): Observable<boolean> {
        return this.checkStoreLoaded();
    }
}
