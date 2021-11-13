import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import Swal from 'sweetalert2';
import { UsuarioModelo } from '../../modelos/Usuario.modelo';
import { UsuariosService } from '../servicios/usuarios.service';

@Component({
  selector: 'app-usuariosFormulario',
  templateUrl: './usuariosFormulario.component.html'
})

export class UsuariosFormularioComponent implements OnInit {

  titulo: string = "Crear Incidente"
  testId: any
  usuario: UsuarioModelo = new UsuarioModelo()

  constructor(private usuariosService: UsuariosService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.cargarIncidencia()      
  }

  agregar(): void {        
    if (this.usuario.nombre.trim().length === 0) {
      return;
    }
    this.usuariosService.agregarIncidencia(this.usuario);
    this.router.navigate(['/usuarios'])
    Swal.fire('Nuevo cliente', `Cliente ${this.usuario.nombre} creado con éxito!`, 'success')
    
  }

  actualizar(): void {
    if (this.usuario.nombre.trim().length === 0) {
      return;
    }

    this.usuariosService.actualizarIncidencia(this.usuario);
    this.router.navigate(['/usuarios'])    
    Swal.fire('Cliente Actualizado', `Cliente ${this.usuario.nombre} creado con éxito!`, 'success')
  }

  cargarIncidencia(): void {    
    //this.testId = this.activatedRoute.snapshot.paramMap.get('id');     
    this.activatedRoute.params.subscribe(params => {
      let id = params['id']
      if (id) {
        this.usuariosService.obtenerIncidencia(id).subscribe((incidencia) => this.usuario = incidencia)
      }
    })
  }
}