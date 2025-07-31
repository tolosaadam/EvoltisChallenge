import { createReducer, on } from '@ngrx/store';
import * as ProductCategoryActions from './product-category.actions';
import { ProductCategoryState } from '../models/product-category.interface';

export const initialState: ProductCategoryState = {
    categories: [],
    loading: false,
    error: null
};

export const _productCategoryReducer = createReducer(
    initialState,

    on(ProductCategoryActions.loadProductCategories, state => ({
        ...state,
        loading: true
    })),

    on(ProductCategoryActions.loadProductCategoriesSuccess, (state, { categories }) => ({
        ...state,
        loading: false,
        categories
    })),

    on(ProductCategoryActions.loadProductCategoriesFailure, (state, { error }) => ({
        ...state,
        loading: false,
        error
    }))
);

