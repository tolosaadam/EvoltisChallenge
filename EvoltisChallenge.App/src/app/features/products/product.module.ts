import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductTableComponent } from './components/product-table/product-table.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { ProductRoutingModule } from './product-routing.module';

@NgModule({
    declarations: [ProductTableComponent, ProductDetailsComponent],
    imports: [
        CommonModule,
        ProductRoutingModule 
    ],
    exports: []
})
export class ProductModule { }