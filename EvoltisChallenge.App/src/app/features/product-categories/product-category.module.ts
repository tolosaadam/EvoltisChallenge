import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { _productCategoryReducer } from './state/product-category.reducer';
import { ProductCategoryEffects } from './state/product-category.effects';

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        StoreModule.forFeature('productCategories', _productCategoryReducer),
        EffectsModule.forFeature([ProductCategoryEffects])
    ],
    exports: []
})
export class ProductCategoryModule { }