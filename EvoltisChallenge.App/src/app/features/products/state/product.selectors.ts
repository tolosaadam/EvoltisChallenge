import { selectAllProductCategories } from '../../product-categories/state/product-category.selectors';
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ProductState, ProductWithCategory } from '../models/product.interface';

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

export const selectAllProductsWithCategory = createSelector(
    selectAllProducts,
    selectAllProductCategories,
    (products, categories): ProductWithCategory[] =>
        products.map(({ productCategoryId, ...rest }) => ({
            ...rest,
            category: categories.find(cat => cat.id === productCategoryId)
        }))
);

export const selectProductWithCategoryById = (id: string) => createSelector(
    selectAllProductsWithCategory,
    (productsWithCat) => productsWithCat.find(pwc => pwc.id === id)
);
