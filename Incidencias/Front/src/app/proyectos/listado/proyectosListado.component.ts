import { Component, Input } from '@angular/core';
import { ProyectosService } from '../servicios/proyectos.service';
import Swal from 'sweetalert2';
import { ProyectoModelo } from '../../modelos/proyecto.modelo';

@Component({
  selector: 'app-proyectosListado',
  templateUrl: './proyectosListado.component.html'
})

export class ProyectosListadoComponent {

  incidencias: ProyectoModelo[] = [];
  errorHttp = false;
  cargando: boolean = false;

  constructor(private proyectoService: ProyectosService) { }

  ngOnInit() {
    this.cargando = true;
    //this.cargarLista();
  }

  get cargarLista() {
    this.cargando = false;
    return this.proyectoService.obtenerIncidencias;
  }

  delete(incidencia: ProyectoModelo): void {
    Swal.fire({
      title: 'Está seguro?',
      text: `¿Seguro que desea eliminar al proyecto ${incidencia.nombre}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, eliminar!',
    }).then((result) => {
      if (result.isConfirmed) {

        this.proyectoService.delete(incidencia.id).subscribe(   response => {
            this.incidencias = this.incidencias.filter(cli => cli !== incidencia)
            Swal.fire('Eliminado!', `Incidencia ${incidencia.nombre} eliminado con éxito.`, 'success')
          })        
      }
    })

  }
  /*
  cargarLista(): void {
    this.proyectoService.obtenerIncidencias.subscribe(      
      (respuesta) => { this.incidencias = respuesta; this.cargando = false; },
      (respuesta) => { this.errorHttp = true },
    )
  }*/

}

