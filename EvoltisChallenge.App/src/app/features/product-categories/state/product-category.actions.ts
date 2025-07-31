import { createAction, props } from '@ngrx/store';
import { ProductCategory } from '../models/product-category.interface';

export const loadProductCategories = createAction('[ProductCategory] Load Product Categories');
export const loadProductCategoriesSuccess = createAction('[ProductCategory] Load Product Categories Success', props<{ categories: ProductCategory[] }>());
export const loadProductCategoriesFailure = createAction('[ProductCategory] Load Product Categories Failure', props<{ error: any }>());
