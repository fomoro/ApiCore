import { Component, Input } from '@angular/core';
import { IncidenciaModelo } from '../../modelos/incidencia.modelo';
import { IncidenciasService } from '../servicios/incidencias.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-incidenciasListado',
  templateUrl: './incidenciasListado.component.html'
})

export class IncidenciasListadoComponent {

  incidencias: IncidenciaModelo[] = [];
  errorHttp = false;
  cargando: boolean = false;

  constructor(private incidenciasService: IncidenciasService) { }

  ngOnInit() {
    this.cargando = true;
    //this.cargarLista();
  }

  get cargarLista() {
    this.cargando = false;
    return this.incidenciasService.obtenerIncidencias;
  }

  delete(incidencia: IncidenciaModelo): void {
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

        this.incidenciasService.delete(incidencia.id).subscribe(   response => {
            this.incidencias = this.incidencias.filter(cli => cli !== incidencia)
            Swal.fire('Eliminado!', `Incidencia ${incidencia.nombre} eliminado con éxito.`, 'success')
          })        
      }
    })

  }

  /*cargarLista(): void {
    this.incidenciasService.obtenerIncidencias.subscribe(      
      (respuesta) => { this.incidencias = respuesta; this.cargando = false; },
      (respuesta) => { this.errorHttp = true },
    )
  }*/

}

