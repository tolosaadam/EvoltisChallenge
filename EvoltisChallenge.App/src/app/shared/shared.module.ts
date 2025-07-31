import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';

@NgModule({
    declarations: [
        NotFoundComponent, 
        LoadingSpinnerComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        ProgressSpinnerModule,
        ButtonModule,
        CardModule
    ],
    exports: [
        NotFoundComponent, 
        LoadingSpinnerComponent,
    ]
})
export class SharedModule { }