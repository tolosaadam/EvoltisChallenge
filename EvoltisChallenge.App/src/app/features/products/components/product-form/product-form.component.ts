import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { FormGroupState } from 'ngrx-forms';
import { ProductCategory } from '../../../product-categories/models/product-category.interface';
import { CreateProduct, UpdateProduct } from '../../models/product.interface';
import { ProductFormValue } from './models/product-form.interface';
import * as ProductCategorySelectors from '../../../product-categories/state/product-category.selectors';
import * as ProductFormSelectors from './state/product-form.selectors';
import * as ProductFormActions from './state/product-form.actions';
import { createProduct, updateProduct } from '../../state/product.actions';

@Component({
    selector: 'app-product-form',
    templateUrl: './product-form.component.html',
    styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent implements OnInit {

    productForm$!: Observable<FormGroupState<ProductFormValue>>;
    categories$!: Observable<ProductCategory[]>;
    modalVisible$!: Observable<boolean>;
    isEditMode$!: Observable<boolean>;
    productId$!: Observable<string | null>;
    isFormValid$!: Observable<boolean>;

    constructor(private store: Store) { }

    ngOnInit(): void {
        this.categories$ = this.store.select(ProductCategorySelectors.selectProductCategories);
        this.productForm$ = this.store.select(ProductFormSelectors.selectProductForm);
        this.modalVisible$ = this.store.select(ProductFormSelectors.selectModalVisible);
        this.isEditMode$ = this.store.select(ProductFormSelectors.selectIsEditMode);
        this.productId$ = this.store.select(ProductFormSelectors.selectProductId);
        this.isFormValid$ = this.store.select(ProductFormSelectors.selectIsFormValid);
    }

    onSubmit(): void {
        this.productForm$.subscribe(form => {
            if (form.isValid) {
                const formValue = form.value;

                this.isEditMode$.subscribe(isEditMode => {
                    if (isEditMode) {
                        this.productId$.subscribe(productId => {
                            if (productId) {
                                const updateData: UpdateProduct = {
                                    name: formValue.name,
                                    description: formValue.description,
                                    price: formValue.price,
                                    productCategoryId: formValue.productCategoryId
                                };
                                this.store.dispatch(updateProduct({ id: productId, product: updateData }));
                            }
                        }).unsubscribe();
                    } else {
                        const createData: CreateProduct = {
                            name: formValue.name,
                            description: formValue.description,
                            price: formValue.price,
                            productCategoryId: formValue.productCategoryId
                        };
                        this.store.dispatch(createProduct({ product: createData }));
                    }
                }).unsubscribe();

                this.onCancel();
            }
        }).unsubscribe();
    }

    onCancel(): void {
        this.store.dispatch(ProductFormActions.closeProductForm());
    }

    onVisibleChange(visible: boolean): void {
        if (!visible) {
            this.store.dispatch(ProductFormActions.closeProductForm());
        }
    }
}
