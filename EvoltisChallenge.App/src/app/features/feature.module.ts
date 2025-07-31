import { NgModule } from '@angular/core';
import { ProductModule } from './products/product.module';
import { ProductCategoryModule } from './product-categories/product-category.module';

@NgModule({
    imports: [
        ProductModule,
        ProductCategoryModule
    ],
    exports: []
})
export class FeatureModule { }