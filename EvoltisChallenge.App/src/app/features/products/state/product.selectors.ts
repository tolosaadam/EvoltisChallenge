import { selectProductCategories, selectProductCategoriesLoading } from '../../product-categories/state/product-category.selectors';
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ProductState, ProductWithCategory } from '../models/product.interface';

export const selectProductState = createFeatureSelector<ProductState>('products');

export const selectProducts = createSelector(
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
    selectProducts,
    (products) => products.find(product => product.id === id)
);

export const selectProductsWithCategory = createSelector(
    selectProducts,
    selectProductCategories,
    (products, categories): ProductWithCategory[] =>
        products.map(({ productCategoryId, ...rest }) => ({
            ...rest,
            category: categories.find(cat => cat.id === productCategoryId)
        }))
);

export const selectProductWithCategoryById = (id: string) => createSelector(
    selectProductsWithCategory,
    (productsWithCat) => productsWithCat.find(pwc => pwc.id === id)
);

export const selectProductsAndCategoriesLoading = createSelector(
    selectProductsLoading,
    selectProductCategoriesLoading,
    (productsLoading, categoriesLoading) => productsLoading || categoriesLoading
);
