import { Component, OnInit } from '@angular/core';
import { IncidenciaModelo } from '../../modelos/incidencia.modelo';
import { IncidenciasService } from '../servicios/incidencias.service';
import { Router, ActivatedRoute } from '@angular/router'
import Swal from 'sweetalert2';

@Component({
  selector: 'app-incidenciasFormulario',
  templateUrl: './incidenciasFormulario.component.html'
})

export class IncidenciasFormularioComponent implements OnInit {

  titulo: string = "Crear Incidente"
  testId: any
  incidencia: IncidenciaModelo = new IncidenciaModelo()

  constructor(private incidenciasService: IncidenciasService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.cargarIncidencia()      
  }

  agregar(): void {        
    if (this.incidencia.nombre.trim().length === 0) {
      return;
    }
    this.incidenciasService.agregarIncidencia(this.incidencia);
    this.router.navigate(['/incidencia'])
    Swal.fire('Nuevo cliente', `Cliente ${this.incidencia.nombre} creado con éxito!`, 'success')
    
  }

  actualizar(): void {
    if (this.incidencia.nombre.trim().length === 0) {
      return;
    }

    this.incidenciasService.actualizarIncidencia(this.incidencia);
    this.router.navigate(['/incidencia'])    
    Swal.fire('Cliente Actualizado', `Cliente ${this.incidencia.nombre} creado con éxito!`, 'success')
  }

  cargarIncidencia(): void {    
    //this.testId = this.activatedRoute.snapshot.paramMap.get('id');     
    this.activatedRoute.params.subscribe(params => {
      let id = params['id']
      if (id) {
        this.incidenciasService.obtenerIncidencia(id).subscribe((incidencia) => this.incidencia = incidencia)
      }
    })
  }
}