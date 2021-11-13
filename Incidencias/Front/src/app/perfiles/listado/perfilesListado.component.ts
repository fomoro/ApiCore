import { Component, Input } from '@angular/core';
import Swal from 'sweetalert2';
import { UsuarioModelo } from '../../modelos/Usuario.modelo';
import { PerfilesService } from '../servicios/perfiles.service';

@Component({
  selector: 'app-perfilesListado',
  templateUrl: './perfilesListado.component.html'
})

export class PerfilesListadoComponent {

  usuarios: UsuarioModelo[] = [];
  errorHttp = false;
  cargando: boolean = false;

  constructor(private servicio: PerfilesService) { }

  ngOnInit() {
    this.cargando = true;
    //this.cargarLista();
  }

  get cargarLista() {
    this.cargando = false;
    return this.servicio.obtenerusuarios;
  }

  eliminar(obj: UsuarioModelo): void {
    Swal.fire({
      title: 'Está seguro?',
      text: `¿Seguro que desea eliminar al Perfil ${obj.nombre}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, eliminar!',
    }).then((result) => {
      if (result.isConfirmed) {

        this.servicio.eliminar(obj.id).subscribe(   response => {
            this.usuarios = this.usuarios.filter(item => item !== obj)
            Swal.fire('Eliminado!', `Incidencia ${obj.nombre} eliminado con éxito.`, 'success')
          })        
      }
    })

  }
}

