import { createAction, props } from '@ngrx/store';
import { ProductWithCategory } from '../../../models/product.interface';
import { ProductFormValue } from '../models/product-form.interface';

export const openCreateProductForm = createAction(
    '[Product Form] Open Product Form');

export const openEditProductForm = createAction(
    '[Product Form] Open Product Edit Form',
    props<{ product: ProductWithCategory }>()
);

export const closeProductForm = createAction(
    '[Product Form] Close Product Form');

export const resetProductForm = createAction(
    '[Product Form] Reset Product Form');