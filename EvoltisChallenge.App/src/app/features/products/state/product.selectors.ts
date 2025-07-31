import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ProductState } from '../models/product.interface';

export const selectProductState = createFeatureSelector<ProductState>('products');

export const selectAllProducts = createSelector(
    selectProductState,
    (state) => state.products
);

export const selectProductsLoading = createSelector(
    selectProductState,
    (state) => state.loading
);

export const selectProductsError = createSelector(
    selectProductState,
    (state) => state.error
);

export const selectProductById = (id: string) => createSelector(
    selectAllProducts,
    (products) => products.find(product => product.id === id)
);
