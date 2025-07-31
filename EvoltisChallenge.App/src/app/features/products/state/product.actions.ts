import { createAction, props } from '@ngrx/store';
import { CreateProduct, Product, UpdateProduct } from '../models/product.interface';

export const createProductRequest = createAction('[Product] Create Product Request', props<{ product: CreateProduct }>());
export const createProductSuccess = createAction('[Product] Create Product Success', props<{ id: string, product: CreateProduct }>());
export const createProductFailure = createAction('[Product] Create Product Failure', props<{ error: any }>());

export const updateProductRequest = createAction('[Product] Update Product Request', props<{ id: string, product: UpdateProduct }>());
export const updateProductSuccess = createAction('[Product] Update Product Success', props<{ id: string, product: UpdateProduct }>());
export const updateProductFailure = createAction('[Product] Update Product Failure', props<{ error: any }>());

export const deleteProductRequest = createAction('[Product] Delete Product Request', props<{ id: string }>());
export const deleteProductSuccess = createAction('[Product] Delete Product Success', props<{ id: string }>());
export const deleteProductFailure = createAction('[Product] Delete Product Failure', props<{ error: any }>());

export const loadProductsRequest = createAction('[Product] Load Products Request');
export const loadProductsSuccess = createAction('[Product] Load Products Success', props<{ products: Product[] }>());
export const loadProductsFailure = createAction('[Product] Load Products Failure', props<{ error: any }>());

export const loadProductByIdRequest = createAction('[Product] Load Product By Id Request', props<{ id: string }>());
export const loadProductByIdSuccess = createAction('[Product] Load Product By Id Success', props<{ product: Product }>());
export const loadProductByIdFailure = createAction('[Product] Load Product By Id Failure', props<{ error: any }>());
