import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import Swal from 'sweetalert2';
import { PerfilModelo } from '../../modelos/perfil.modelo';
import { PerfilesService } from '../servicios/perfiles.service';

@Component({
  selector: 'app-perfilesFormulario',
  templateUrl: './perfilesFormulario.component.html'
})

export class PerfilesFormularioComponent implements OnInit {

  titulo: string = "Crear Perfil"
  testId: any
  modelo: PerfilModelo = new PerfilModelo()

  constructor(private servicio: PerfilesService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.cargarIncidencia()
  }

  agregar(): void {
    if (this.modelo.nombre.trim().length === 0) {
      return;
    }
    this.servicio.agregar(this.modelo);
    this.router.navigate(['/perfil'])
    Swal.fire('Nuevo Perfil', `Perfil ${this.modelo.nombre} creado con éxito!`, 'success')
  }

  actualizar(): void {
    if (this.modelo.nombre.trim().length === 0) {
      return;
    }

    this.servicio.actualizar(this.modelo);
    this.router.navigate(['/perfil'])
    Swal.fire('Perfil Actualizado', `Perfil ${this.modelo.nombre} creado con éxito!`, 'success')
  }

  cargarIncidencia(): void {
    //this.testId = this.activatedRoute.snapshot.paramMap.get('id');     
    this.activatedRoute.params.subscribe(params => {
      let id = params['id']
      if (id) {
        this.servicio.obtenerId(id).subscribe((incidencia) => this.modelo = incidencia)
      }
    })
  }
}