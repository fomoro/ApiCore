import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { IncidenciasFormularioComponent } from './formulario/incidenciasFormulario.component';
import { IncidenciasListadoComponent } from './listado/incidenciasListado.component';
import { IncidenciasService } from './servicios/incidencias.service';


@NgModule({
  declarations: [
    IncidenciasFormularioComponent,   
    IncidenciasListadoComponent  
  ],
  exports: [
    IncidenciasListadoComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  providers: [
    IncidenciasService
  ]
})
export class IncidenciasModule { }
