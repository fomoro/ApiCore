import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { of } from 'rxjs';
import { UsuarioModelo } from '../../modelos/Usuario.modelo';

@Injectable()
export class UsuariosService {

    private _usuarios: UsuarioModelo[] = [
        { id: 1, nombre: 'fallo grabe', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 2, testerId: 5 },
        { id: 2, nombre: 'daño dos', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 2, testerId: 5 },
        { id: 3, nombre: 'incidencia b', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 3, testerId: 5 },
        { id: 4, nombre: 'incidencia c', descripcion: 'carreta', proyectoId: 1, version: 1, estatusIncidencia: 2, desarrolladorId: 3, testerId: 5 }
    ];

    get obtenerusuarios(): UsuarioModelo[] {
        return [...this._usuarios];
    }

    agregarIncidencia(incidencia: UsuarioModelo): void {
        this._usuarios.push(incidencia);
    }

    actualizarIncidencia(incidencia: UsuarioModelo): void {
        var foundIndex = this._usuarios.findIndex(x => x.id == incidencia.id);
        this._usuarios[foundIndex].nombre = incidencia.nombre
        this._usuarios[foundIndex].descripcion = incidencia.descripcion
    }

    obtenerIncidencia(id: number): Observable<UsuarioModelo> {
        let incidencia = this._usuarios.filter((x) => x.id == id)[0];
        return of(incidencia)
    }

    delete(id: number): Observable<UsuarioModelo> {
        var foundIndex = this._usuarios.findIndex(x => x.id == id);
        var eliminado = this._usuarios[foundIndex]
        this._usuarios.splice(foundIndex, 1);
        return of(eliminado)
    }
}
