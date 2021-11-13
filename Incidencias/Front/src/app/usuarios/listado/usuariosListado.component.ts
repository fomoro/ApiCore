import { Component, Input } from '@angular/core';
import Swal from 'sweetalert2';
import { UsuarioModelo } from '../../modelos/Usuario.modelo';
import { UsuariosService } from '../servicios/usuarios.service';

@Component({
  selector: 'app-usuariosListado',
  templateUrl: './usuariosListado.component.html'
})

export class UsuariosListadoComponent {

  usuarios: UsuarioModelo[] = [];
  errorHttp = false;
  cargando: boolean = false;

  constructor(private usuariosService: UsuariosService) { }

  ngOnInit() {
    this.cargando = true;
    //this.cargarLista();
  }

  get cargarLista() {
    this.cargando = false;
    return this.usuariosService.obtenerusuarios;
  }

  delete(incidencia: UsuarioModelo): void {
    Swal.fire({
      title: 'Está seguro?',
      text: `¿Seguro que desea eliminar al cliente ${incidencia.nombre}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, eliminar!',
    }).then((result) => {
      if (result.isConfirmed) {

        this.usuariosService.delete(incidencia.id).subscribe(   response => {
            this.usuarios = this.usuarios.filter(cli => cli !== incidencia)
            Swal.fire('Eliminado!', `Incidencia ${incidencia.nombre} eliminado con éxito.`, 'success')
          })        
      }
    })

  }

  /*cargarLista(): void {
    this.usuariosService.obtenerusuarios.subscribe(      
      (respuesta) => { this.usuarios = respuesta; this.cargando = false; },
      (respuesta) => { this.errorHttp = true },
    )
  }*/

}

