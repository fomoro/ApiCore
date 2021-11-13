import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BlankComponent } from './layout/blank/blank.component';
import { IncidenciasListadoComponent } from './incidencias/listado/incidenciasListado.component';
import { IncidenciasFormularioComponent } from './incidencias/formulario/incidenciasFormulario.component';
import { ProyectosListadoComponent } from './proyectos/listado/proyectosListado.component';
import { ProyectosFormularioComponent } from './proyectos/formulario/proyectosFormulario.component';
import { UsuariosListadoComponent } from './usuarios/listado/usuariosListado.component';
import { UsuariosFormularioComponent } from './usuarios/formulario/usuariosFormulario.component';
import { PerfilesListadoComponent } from './perfiles/listado/perfilesListado.component';
import { PerfilesFormularioComponent } from './perfiles/formulario/perfilesFormulario.component';

const routes: Routes = [
  { path: 'index', component: BlankComponent },
  //{ path: '404', component: Error404Component },
  { path: '', redirectTo: 'index', pathMatch: 'full' },
  //{ path: '**', redirectTo: '404' },
    
  {path: 'incidencia', component: IncidenciasListadoComponent},
  {path: 'incidencia/formulario', component: IncidenciasFormularioComponent},
  {path: 'incidencia/formulario/:id', component: IncidenciasFormularioComponent},

  {path: 'proyecto', component: ProyectosListadoComponent},
  {path: 'proyecto/formulario', component: ProyectosFormularioComponent},
  {path: 'proyecto/formulario/:id', component: ProyectosFormularioComponent},

  {path: 'usuario', component: UsuariosListadoComponent},
  {path: 'usuario/formulario', component: UsuariosFormularioComponent},
  {path: 'usuario/formulario/:id', component: UsuariosFormularioComponent},

  {path: 'perfil', component: PerfilesListadoComponent},
  {path: 'perfil/formulario', component: PerfilesFormularioComponent},
  {path: 'perfil/formulario/:id', component: PerfilesFormularioComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }