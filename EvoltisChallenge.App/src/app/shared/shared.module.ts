import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';

@NgModule({
    declarations: [NotFoundComponent, LoadingSpinnerComponent],
    imports: [CommonModule],
    exports: [NotFoundComponent, LoadingSpinnerComponent]
})
export class SharedModule { }