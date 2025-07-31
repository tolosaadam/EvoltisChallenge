import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as ProductActions from './product.actions';
import { catchError, exhaustMap, map, mergeMap, of } from 'rxjs';
import { ProductService } from '../services/product.service';

@Injectable()
export class ProductEffects {
    // NgRx espera que el efecto devuelva un observable de acciones, y map ya lo hace sin necesidad de envolverlo en of().
    // mergeMap: permite múltiples requests en paralelo.
    // exhaustMap: solo una request activa, ignora las demás hasta que termina.

    loadProducts$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProductActions.loadProducts),
            exhaustMap(() =>
                this.productService.getAll()
                    .pipe(
                        map(products => ProductActions.loadProductsSuccess({ products })),
                        catchError(error => of(ProductActions.loadProductsFailure({ error })))
                    )
            )
        )
    );

    loadProductById$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProductActions.loadProductById),
            exhaustMap((action) =>
                this.productService.getById(action.id)
                    .pipe(
                        map(product => ProductActions.loadProductByIdSuccess({ product })),
                        catchError(error => of(ProductActions.loadProductByIdFailure({ error })))
                    )
            )
        )
    );

    createProduct$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProductActions.createProduct),
            exhaustMap((action) =>
                this.productService.create(action.product)
                    .pipe(
                        map(id => ProductActions.createProductSuccess({ id, product: action.product })),
                        catchError(error => of(ProductActions.createProductFailure({ error })))
                    )
            )
        )
    );

    updateProduct$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProductActions.updateProduct),
            exhaustMap((action) =>
                this.productService.update(action.id, action.product)
                    .pipe(
                        map(() => ProductActions.updateProductSuccess({ id: action.id, product: action.product })),
                        catchError(error => of(ProductActions.updateProductFailure({ error })))
                    )
            )
        )
    );

    deleteProduct$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProductActions.deleteProduct),
            exhaustMap((action) =>
                this.productService.delete(action.id)
                    .pipe(
                        map(() => ProductActions.deleteProductSuccess({ id: action.id })),
                        catchError(error => of(ProductActions.deleteProductFailure({ error })))
                    )
            )
        )
    );

    constructor(private actions$: Actions, private productService: ProductService) { }
}
