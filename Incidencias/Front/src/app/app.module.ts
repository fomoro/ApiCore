import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AsideComponent } from './layout/aside/aside.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { FooterComponent } from './layout/footer/footer.component';

import { IncidenciasModule } from './incidencias/incidencias.module';
import { ProyectoModule } from './proyectos/proyectos.module';
import { UsuariosModule } from './usuarios/usuarios.module';
import { PerfilesModule } from './perfiles/perfiles.module';

@NgModule({
  declarations: [ 
    AppComponent, 
    AsideComponent,
    NavbarComponent,
    FooterComponent    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    IncidenciasModule,
    ProyectoModule,
    UsuariosModule,
    PerfilesModule
  ],
  providers: [
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
