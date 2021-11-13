import { Injectable } from '@angular/core';
import { INCIDENCIAS } from '../../modelos/incidencias.json';
import { IncidenciaModelo } from '../../modelos/incidencia.modelo';
import { Observable } from 'rxjs';
import { of } from 'rxjs';

@Injectable()
export class IncidenciasService {

    private _incidencias: IncidenciaModelo[] = [
        { id: 1, nombre: 'fallo grabe', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 2, testerId: 5 },
        { id: 2, nombre: 'daño dos', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 2, testerId: 5 },
        { id: 3, nombre: 'incidencia b', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 3, testerId: 5 },
        { id: 4, nombre: 'incidencia c', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 3, testerId: 5 }
    ];

    get obtenerIncidencias(): IncidenciaModelo[] {
        return [...this._incidencias];
    }

    agregarIncidencia(incidencia: IncidenciaModelo): void {
        let tamano = this._incidencias.length + 1
        incidencia.id = tamano
        this._incidencias.push(incidencia);
    }

    actualizarIncidencia(incidencia: IncidenciaModelo): void {
        var foundIndex = this._incidencias.findIndex(x => x.id == incidencia.id);
        this._incidencias[foundIndex].nombre = incidencia.nombre
        this._incidencias[foundIndex].descripcion = incidencia.descripcion
    }

    obtenerIncidencia(id: number): Observable<IncidenciaModelo> {
        let incidencia = this._incidencias.filter((x) => x.id == id)[0];
        return of(incidencia)
    }

    delete(id: number): Observable<IncidenciaModelo> {
        var foundIndex = this._incidencias.findIndex(x => x.id == id);
        var eliminado = this._incidencias[foundIndex]
        this._incidencias.splice(foundIndex, 1);
        return of(eliminado)
    }
}
