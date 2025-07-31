import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { MessageService } from 'primeng/api';
import * as ProductActions from './product.actions';
import { catchError, exhaustMap, map, of, tap } from 'rxjs';
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

    // Effects para notificaciones
    createProductSuccess$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProductActions.createProductSuccess),
            tap(() => {
                this.messageService.add({
                    severity: 'success',
                    summary: 'Producto creado',
                    detail: 'El producto ha sido creado exitosamente'
                });
            })
        ),
        { dispatch: false }
    );

    updateProductSuccess$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProductActions.updateProductSuccess),
            tap(() => {
                this.messageService.add({
                    severity: 'success',
                    summary: 'Producto actualizado',
                    detail: 'El producto ha sido actualizado exitosamente'
                });
            })
        ),
        { dispatch: false }
    );

    deleteProductSuccess$ = createEffect(() =>
        this.actions$.pipe(
            ofType(ProductActions.deleteProductSuccess),
            tap(() => {
                this.messageService.add({
                    severity: 'success',
                    summary: 'Producto eliminado',
                    detail: 'El producto ha sido eliminado exitosamente'
                });
            })
        ),
        { dispatch: false }
    );

    // Effects para errores
    productFailure$ = createEffect(() =>
        this.actions$.pipe(
            ofType(
                ProductActions.createProductFailure,
                ProductActions.updateProductFailure,
                ProductActions.deleteProductFailure
            ),
            tap(() => {
                this.messageService.add({
                    severity: 'error',
                    summary: 'Error',
                    detail: 'Ha ocurrido un error. Por favor, inténtalo de nuevo.'
                });
            })
        ),
        { dispatch: false }
    );

    constructor(
        private actions$: Actions,
        private productService: ProductService,
        private messageService: MessageService
    ) { }
}
