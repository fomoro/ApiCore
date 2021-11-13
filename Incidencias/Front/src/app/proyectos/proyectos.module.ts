import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


import { ProyectosService } from './servicios/proyectos.service';
import { ProyectosFormularioComponent } from './formulario/proyectosFormulario.component';
import { ProyectosListadoComponent } from './listado/proyectosListado.component';


@NgModule({
  declarations: [
    ProyectosFormularioComponent,
    ProyectosListadoComponent
  ],
  exports: [

  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  providers: [
    ProyectosService
  ]
})

export class ProyectoModule { }
