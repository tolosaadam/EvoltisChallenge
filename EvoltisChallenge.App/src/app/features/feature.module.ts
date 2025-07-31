import { NgModule } from '@angular/core';
import { ProductCategoryModule } from './product-categories/product-category.module';
import { ProductModule } from './products/product.module';

@NgModule({
    imports: [
        ProductModule,
        ProductCategoryModule
    ],
    exports: []
})
export class FeatureModule { }