import { NgModule } from '@angular/core';
import { ProductCategoryModule } from './product-categories/product-category.module';

@NgModule({
    imports: [
        ProductCategoryModule
    ],
    exports: []
})
export class FeatureModule { }