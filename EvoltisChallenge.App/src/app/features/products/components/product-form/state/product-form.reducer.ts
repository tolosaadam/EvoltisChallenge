import { createReducer, on } from '@ngrx/store';
import { createFormGroupState, formGroupReducer, updateGroup, setValue, validate, compose } from 'ngrx-forms';
import { required, greaterThan } from 'ngrx-forms/validation';
import { ProductFormState, ProductFormValue } from '../models/product-form.interface';
import * as ProductFormActions from './product-form.actions';

const FORM_ID = 'productForm';

const initialFormGroupState = createFormGroupState<ProductFormValue>(FORM_ID, {
    name: '',
    description: '',
    price: 0,
    productCategoryId: ''
});

export const initialState: ProductFormState = {
    productForm: initialFormGroupState,
    modalVisible: false,
    isEditMode: false,
    productId: null
};

const productFormReducer = createReducer(
    initialState,

    // Abrir formulario para crear producto
    on(ProductFormActions.openCreateProductForm, state => {
        return {
            ...state,
            modalVisible: true,
            isEditMode: false,
            productId: null,
            productForm: initialFormGroupState
        };
    }),

    // Abrir formulario para editar producto
    on(ProductFormActions.openEditProductForm, (state, { product }) => {
        const editFormState = createFormGroupState<ProductFormValue>('productForm', {
            name: product.name,
            description: product.description,
            price: product.price,
            productCategoryId: product.category?.id || ''
        });

        return {
            ...state,
            modalVisible: true,
            isEditMode: true,
            productId: product.id,
            productForm: editFormState
        };
    }),

    // Cerrar formulario
    on(ProductFormActions.closeProductForm, state => ({
        ...state,
        modalVisible: false,
        productId: null
    })),

    // Resetear formulario (limpiarlo)
    on(ProductFormActions.resetProductForm, state => ({
        ...state,
        productForm: initialFormGroupState
    }))
);

export function _productFormReducer(state: ProductFormState | undefined, action: any): ProductFormState {
    const formState = productFormReducer(state, action);
    
    // Aplicamos el formGroupReducer para manejar las acciones de ngrx-forms
    let updatedFormState = formGroupReducer(formState.productForm, action);
    
    // Aplicamos validaciones de forma condicional cuando el campo ha sido tocado
    updatedFormState = updateGroup(updatedFormState, {
        name: updatedFormState.controls.name.isTouched ? validate(required) : (control: any) => control,
        description: updatedFormState.controls.description.isTouched ? validate(required) : (control: any) => control,
        price: updatedFormState.controls.price.isTouched ? validate(greaterThan(0)) : (control: any) => control,
        productCategoryId: updatedFormState.controls.productCategoryId.isTouched ? validate(required) : (control: any) => control
    });
    
    return {
        ...formState,
        productForm: updatedFormState
    };
}
