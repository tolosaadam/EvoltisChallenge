import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ProductCategoryState } from '../models/product-category.interface';

export const selectProductCategoryState = createFeatureSelector<ProductCategoryState>('productCategories');

export const selectAllProductCategories = createSelector(
    selectProductCategoryState,
    (state) => state.categories
);

export const selectProductCategoriesLoading = createSelector(
    selectProductCategoryState,
    (state) => state.loading
);

export const selectProductCategoriesError = createSelector(
    selectProductCategoryState,
    (state) => state.error
);
