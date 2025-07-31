import { FormGroupState } from 'ngrx-forms';

// Interfaz para los valores del formulario de producto
export interface ProductFormValue {
    name: string;
    description: string;
    price: number;
    productCategoryId: string;
}

// Estado de formularios del feature products
export interface ProductFormState {
    productForm: FormGroupState<ProductFormValue>;
    modalVisible: boolean;
    isEditMode: boolean;
    productId: string | null;
}
