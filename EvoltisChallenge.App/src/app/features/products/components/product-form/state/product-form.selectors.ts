import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ProductFormState } from '../models/product-form.interface';

export const selectProductFormState = createFeatureSelector<ProductFormState>('productForm');

export const selectProductForm = createSelector(
    selectProductFormState,
    (state) => state.productForm
);

export const selectModalVisible = createSelector(
    selectProductFormState,
    (state) => state.modalVisible
);

export const selectIsEditMode = createSelector(
    selectProductFormState,
    (state) => state.isEditMode
);

export const selectProductId = createSelector(
    selectProductFormState,
    (state) => state.productId
);

export const selectIsFormValid = createSelector(
    selectProductForm,
    (form) => {
        const values = form.value;
        return form.isValid && 
               Boolean(values.name?.trim()) && 
               Boolean(values.description?.trim()) && 
               values.price > 0 && 
               Boolean(values.productCategoryId);
    }
);