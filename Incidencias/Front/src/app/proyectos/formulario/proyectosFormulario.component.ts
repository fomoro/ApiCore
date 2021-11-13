import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import Swal from 'sweetalert2';
import { ProyectoModelo } from '../../modelos/proyecto.modelo';
import { ProyectosService } from '../servicios/proyectos.service';

@Component({
  selector: 'app-proyectosFormulario',
  templateUrl: './proyectosFormulario.component.html'
})

export class ProyectosFormularioComponent implements OnInit {

  titulo: string = "Crear Proyecto"
  proyecto: ProyectoModelo = new ProyectoModelo()

  constructor(private proyectosService: ProyectosService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.cargarIncidencia()      
  }

  agregar(): void {        
    if (this.proyecto.nombre.trim().length === 0) {
      return;
    }
    this.proyectosService.agregarIncidencia(this.proyecto);
    this.router.navigate(['/incidencias'])
    Swal.fire('Nuevo Proyecto', `Proyecto ${this.proyecto.nombre} creado con éxito!`, 'success')
    
  }

  actualizar(): void {
    if (this.proyecto.nombre.trim().length === 0) {
      return;
    }

    this.proyectosService.actualizarIncidencia(this.proyecto);
    this.router.navigate(['/incidencias'])    
    Swal.fire('Cliente Actualizado', `Cliente ${this.proyecto.nombre} creado con éxito!`, 'success')
  }

  cargarIncidencia(): void {    
    //this.testId = this.activatedRoute.snapshot.paramMap.get('id');     
    this.activatedRoute.params.subscribe(params => {
      let id = params['id']
      if (id) {
        this.proyectosService.obtenerIncidencia(id).subscribe((proyecto) => this.proyecto = proyecto)
      }
    })
  }
}