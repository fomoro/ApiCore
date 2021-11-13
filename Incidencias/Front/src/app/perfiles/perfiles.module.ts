import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { PerfilesFormularioComponent } from './formulario/perfilesFormulario.component';
import { PerfilesListadoComponent } from './listado/perfilesListado.component';
import { PerfilesService } from './servicios/perfiles.service';

@NgModule({
  declarations: [
    PerfilesFormularioComponent,
    PerfilesListadoComponent
  ],
  exports: [
    PerfilesListadoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  providers: [
    PerfilesService
  ]
})
export class PerfilesModule { }
