import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { of } from 'rxjs';
import { ProyectoModelo } from '../../modelos/proyecto.modelo';

@Injectable()
export class ProyectosService {

    private _incidencias: ProyectoModelo[] = [
        { id: 1, nombre: 'fallo grabe'},
        { id: 2, nombre: 'daño dos'}
    ];

    get obtenerIncidencias(): ProyectoModelo[] {
        return [...this._incidencias];
    }

    agregarIncidencia(incidencia: ProyectoModelo): void {
        this._incidencias.push(incidencia);
    }

    actualizarIncidencia(incidencia: ProyectoModelo): void {
        var foundIndex = this._incidencias.findIndex(x => x.id == incidencia.id);
        this._incidencias[foundIndex].nombre = incidencia.nombre
    }

    obtenerIncidencia(id: number): Observable<ProyectoModelo> {
        let incidencia = this._incidencias.filter((x) => x.id == id)[0];
        return of(incidencia)
    }

    delete(id: number): Observable<ProyectoModelo> {
        var foundIndex = this._incidencias.findIndex(x => x.id == id);
        var eliminado = this._incidencias[foundIndex]
        this._incidencias.splice(foundIndex, 1);
        return of(eliminado)
    }
}
