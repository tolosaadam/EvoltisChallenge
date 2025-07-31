import { createReducer, on } from '@ngrx/store';
import * as ProductActions from './product.actions';
import { ProductState } from '../models/product.interface';

export const initialState: ProductState = {
    products: [],
    loading: false,
    error: null
};

export const _productReducer = createReducer(
    initialState,

    // load products.
    on(ProductActions.loadProducts, state => ({
        ...state,
        loading: true
    })),

    on(ProductActions.loadProductsSuccess, (state, { products }) => ({
        ...state,
        products,
        loading: false
    })),

    on(ProductActions.loadProductsFailure, (state, { error }) => ({
        ...state,
        error,
        loading: false
    })),



    // load product by id.
    on(ProductActions.loadProductById, state => ({
        ...state,
        loading: true
    })),

    on(ProductActions.loadProductByIdSuccess, (state, { product }) => ({
        ...state,
        loading: false,
        products: state.products.some(p => p.id === product.id)
            ? state.products
            : [...state.products, product]
    })),

    on(ProductActions.loadProductByIdFailure, (state, { error }) => ({
        ...state,
        error,
        loading: false
    })),



    // create product.
    on(ProductActions.createProduct, state => ({
        ...state,
        loading: true
    })),

    on(ProductActions.createProductSuccess, (state, { id, product }) => ({
        ...state,
        loading: false,
        products: product ? [...state.products, { ...product, id }] : state.products
    })),

    on(ProductActions.createProductFailure, (state, { error }) => ({
        ...state,
        error,
        loading: false
    })),



    // update product.
    on(ProductActions.updateProduct, state => ({
        ...state,
        loading: true
    })),

    on(ProductActions.updateProductSuccess, (state, { id, product }) => ({
        ...state,
        loading: false,
        products: state.products.map(p => p.id === id ? { ...p, ...product } : p)
    })),

    on(ProductActions.updateProductFailure, (state, { error }) => ({
        ...state,
        error,
        loading: false
    })),



    // delete product.
    on(ProductActions.deleteProduct, state => ({
        ...state,
        loading: true
    })),

    on(ProductActions.deleteProductSuccess, (state, { id }) => ({
        ...state,
        loading: false,
        products: state.products.filter(p => p.id !== id)
    })),

    on(ProductActions.deleteProductFailure, (state, { error }) => ({
        ...state,
        error,
        loading: false
    })),
);
