import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { UsuariosService } from './servicios/usuarios.service';
import { UsuariosFormularioComponent } from './formulario/usuariosFormulario.component';
import { UsuariosListadoComponent } from './listado/usuariosListado.component';

@NgModule({
  declarations: [    
    UsuariosFormularioComponent,
    UsuariosListadoComponent
  ],
  exports: [    
    UsuariosListadoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  providers: [
    UsuariosService
  ]
})
export class UsuariosModule { }
