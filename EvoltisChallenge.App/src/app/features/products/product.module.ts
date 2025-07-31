import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NgrxFormsModule } from 'ngrx-forms';
import { ProductTableComponent } from './components/product-table/product-table.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { ProductFormComponent } from './components/product-form/product-form.component';
import { ProductRoutingModule } from './product-routing.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { _productReducer } from './state/product.reducer';
import { ProductEffects } from './state/product.effects';
import { _productFormReducer } from './components/product-form/state/product-form.reducer';
import { ProductCategoryModule } from '../product-categories/product-category.module';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast';
import { InputTextModule } from 'primeng/inputtext';
import { TooltipModule } from 'primeng/tooltip';
import { CardModule } from 'primeng/card';
import { DividerModule } from 'primeng/divider';
import { TagModule } from 'primeng/tag';
import { SkeletonModule } from 'primeng/skeleton';
import { DialogModule } from 'primeng/dialog';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputNumberModule } from 'primeng/inputnumber';
import { DropdownModule } from 'primeng/dropdown';
import { ConfirmationService, MessageService } from 'primeng/api';

@NgModule({
    declarations: [ProductTableComponent, ProductDetailsComponent, ProductFormComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        NgrxFormsModule,
        ProductRoutingModule,
        ProductCategoryModule,
        StoreModule.forFeature('products', _productReducer),
        StoreModule.forFeature('productForm', _productFormReducer),
        EffectsModule.forFeature([ProductEffects]),
        TableModule,
        ButtonModule,
        ToolbarModule,
        ConfirmDialogModule,
        ToastModule,
        InputTextModule,
        TooltipModule,
        CardModule,
        DividerModule,
        TagModule,
        SkeletonModule,
        DialogModule,
        InputTextareaModule,
        InputNumberModule,
        DropdownModule
    ],
    providers: [
        ConfirmationService,
        MessageService
    ],
    exports: []
})
export class ProductModule { }