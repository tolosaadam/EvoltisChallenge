import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductTableComponent } from './components/product-table/product-table.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { ProductRoutingModule } from './product-routing.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { _productReducer } from './state/product.reducer';
import { ProductEffects } from './state/product.effects';

@NgModule({
    declarations: [ProductTableComponent, ProductDetailsComponent],
    imports: [
        CommonModule,
        ProductRoutingModule,
        StoreModule.forFeature('products', _productReducer),
        EffectsModule.forFeature([ProductEffects])
    ],
    exports: []
})
export class ProductModule { }