import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductTableComponent } from './components/product-table/product-table.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';

const routes: Routes = [
    { path: '', component: ProductTableComponent },
    { path: ':id', component: ProductDetailsComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProductRoutingModule { }