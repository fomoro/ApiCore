import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { ReporteAComponent } from './reporteA/reporteA.component';


@NgModule({
  declarations: [
    ReporteAComponent,    
  ],
  exports: [

  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  providers: [    
  ]
})

export class ProyectoModule { }
