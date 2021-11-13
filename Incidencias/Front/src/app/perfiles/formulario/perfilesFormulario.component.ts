import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import Swal from 'sweetalert2';
import { PerfilModelo } from '../../modelos/perfil.modelo';
import { PerfilesService } from '../servicios/perfiles.service';
import { Form, NgForm } from '@angular/forms';

@Component({
  selector: 'app-perfilesFormulario',
  templateUrl: './perfilesFormulario.component.html'
})

export class PerfilesFormularioComponent implements OnInit {
  titulo: string = "Crear Perfil"
  
  modelo: PerfilModelo = {
    id: 0,
    nombre: ''
  }

  constructor(private servicio: PerfilesService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getItem()
  }

  getItem(): void {
    this.activatedRoute.params.subscribe(params => {
      let id = params['id']
      if (id) {
        this.servicio.getById(id).subscribe((item) => this.modelo = item)
      }
    })
  }

  add() {
    this.servicio.save(this.modelo).subscribe(
      (result: PerfilModelo) => {
        //let obj = result as PerfilModelo;
        this.router.navigate(['/perfil'])
        Swal.fire('Nuevo Perfil', `Perfil ${result.nombre} creado con éxito!`, 'success')
      },
      error => {
        console.log(error);
      }
    );
  }

  update() {
    this.servicio.update(this.modelo).subscribe(
      (result: PerfilModelo) => {
        //let obj = result as PerfilModelo;
        this.router.navigate(['/perfil'])
        Swal.fire('Perfil Actualizado', `Perfil ${result.nombre} actualizado con éxito!`, 'success')
      },
      error => {
        console.log(error);
      }
    );
  }
}