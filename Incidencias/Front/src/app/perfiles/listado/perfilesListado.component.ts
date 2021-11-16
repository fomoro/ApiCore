import { Component, Input } from '@angular/core';
import Swal from 'sweetalert2';
import { PerfilesService } from '../servicios/perfiles.service';
import { PerfilModelo } from '../../modelos/perfil.modelo';

@Component({
  selector: 'app-perfilesListado',
  templateUrl: './perfilesListado.component.html'
})

export class PerfilesListadoComponent {

  arreglo: PerfilModelo[] = [];
  errorHttp = false;
  cargando: boolean = false;

  constructor(private servicio: PerfilesService) { }

  ngOnInit() {
    this.cargando = true;
    this.getAll();
  }

  getAll() {
    this.servicio.getAll().subscribe(
      (perfiles) => {
        this.arreglo = perfiles
        this.cargando = false;
      },
      error => {
        this.cargando = false;
        this.errorHttp = true;
        console.log(error);
      });
    /*
  this.servicio.getAll().subscribe(
    (result: any) => {
      let arreglo: PerfilModelo[] = [];
      for (let i = 0; i < result.length; i++) {
        let obj = result[i] as PerfilModelo;
        arreglo.push(obj);
      }
      this.arreglo = arreglo;
    },
    error => {
      console.log(error);
    }
  );*/
  }

  delete(obj: PerfilModelo): void {
    if (obj == null || obj.id == null) {
      return;
    }

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
        this.servicio.delete(obj.id).subscribe(response => {
          this.deleteObject(obj.id);
          Swal.fire('Eliminado!', `Perfil ${obj.nombre} eliminado con éxito.`, 'success')
        })
      }
    })
  }

  deleteObject(id:number){
    let index = this.arreglo.findIndex((e) => e.id == id);
    if(index != -1){
      this.arreglo.splice(index, 1);
    }
  }
}

