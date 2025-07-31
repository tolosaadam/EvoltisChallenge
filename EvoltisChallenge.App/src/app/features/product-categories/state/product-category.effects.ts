import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as ProductCategoryActions from './product-category.actions';
import { catchError, exhaustMap, map, mergeMap, of } from 'rxjs';
import { ProductCategoryService } from '../services/product-category.service';

@Injectable()
export class ProductCategoryEffects {
  loadProductCategories$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProductCategoryActions.loadProductCategories),
      exhaustMap(() =>
        this.productCategoryService.getAll().pipe(
          map(categories => ProductCategoryActions.loadProductCategoriesSuccess({ categories })),
          catchError(error => of(ProductCategoryActions.loadProductCategoriesFailure({ error })))
        )
      )
    )
  );

  constructor(private actions$: Actions, private productCategoryService: ProductCategoryService) {}
}
