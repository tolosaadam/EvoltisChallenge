import { createAction, props } from '@ngrx/store';
import { CreateProduct, Product, UpdateProduct } from '../models/product.interface';

export const createProduct = createAction('[Product] Create Product', props<{ product: CreateProduct }>());
export const createProductSuccess = createAction('[Product] Create Product Success', props<{ id: string, product: CreateProduct }>());
export const createProductFailure = createAction('[Product] Create Product Failure', props<{ error: any }>());

export const updateProduct = createAction('[Product] Update Product', props<{ id: string, product: UpdateProduct }>());
export const updateProductSuccess = createAction('[Product] Update Product Success', props<{ id: string, product: UpdateProduct }>());
export const updateProductFailure = createAction('[Product] Update Product Failure', props<{ error: any }>());

export const deleteProduct = createAction('[Product] Delete Product', props<{ id: string }>());
export const deleteProductSuccess = createAction('[Product] Delete Product Success', props<{ id: string }>());
export const deleteProductFailure = createAction('[Product] Delete Product Failure', props<{ error: any }>());

export const loadProducts = createAction('[Product] Load Products');
export const loadProductsSuccess = createAction('[Product] Load Products Success', props<{ products: Product[] }>());
export const loadProductsFailure = createAction('[Product] Load Products Failure', props<{ error: any }>());

export const loadProductById = createAction('[Product] Load Product By Id', props<{ id: string }>());
export const loadProductByIdSuccess = createAction('[Product] Load Product By Id Success', props<{ product: Product }>());
export const loadProductByIdFailure = createAction('[Product] Load Product By Id Failure', props<{ error: any }>());
