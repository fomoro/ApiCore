import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { of } from 'rxjs';
import { PerfilModelo } from '../../modelos/perfil.modelo';

@Injectable()
export class PerfilesService {

    private array: PerfilModelo[] = [
        { id: 1, nombre: 'fallo grabe', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 2, testerId: 5 },
        { id: 2, nombre: 'daño dos', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 2, testerId: 5 },
        { id: 3, nombre: 'incidencia b', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 3, testerId: 5 },
        { id: 4, nombre: 'incidencia c', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 3, testerId: 5 }
    ];

    get obtenerusuarios(): PerfilModelo[] {
        return [...this.array];
    }

    agregar(incidencia: PerfilModelo): void {
        let tamano = this.array.length + 1
        incidencia.id = tamano
        this.array.push(incidencia);
    }

    actualizar(incidencia: PerfilModelo): void {
        var foundIndex = this.array.findIndex(x => x.id == incidencia.id);
        this.array[foundIndex].nombre = incidencia.nombre
        this.array[foundIndex].descripcion = incidencia.descripcion
    }

    obtenerId(id: number): Observable<PerfilModelo> {
        let incidencia = this.array.filter((x) => x.id == id)[0];
        return of(incidencia)
    }

    eliminar(id: number): Observable<PerfilModelo> {
        var foundIndex = this.array.findIndex(x => x.id == id);
        var eliminado = this.array[foundIndex]
        this.array.splice(foundIndex, 1);
        return of(eliminado)
    }
}
