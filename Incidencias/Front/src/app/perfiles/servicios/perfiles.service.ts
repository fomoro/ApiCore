import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { of } from 'rxjs';
import { PerfilModelo } from '../../modelos/perfil.modelo';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Injectable()
export class PerfilesService {
    //baseUrl = environment.baseUrl;
    private urlEndPoint: string = 'https://localhost:44364/api/Perfiles';

    private httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' })

    constructor(private http: HttpClient) { }

    getAll(): Observable<PerfilModelo[]> {
        //return this.http.get<PerfilModelo[]>(this.urlEndPoint);
        return this.http.get(this.urlEndPoint).pipe(
            map(response => response as PerfilModelo[])
        );
    }

    delete(id: number): Observable<any> {
        return this.http.delete(`${this.urlEndPoint}/${id}`);
    }

    getById(id: number): Observable<PerfilModelo> {
        return this.http.get<PerfilModelo>(`${this.urlEndPoint}/${id}`)
    }

    save(obj: PerfilModelo): Observable<any> {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json');
        return this.http.post(this.urlEndPoint + "/", JSON.stringify(obj), { headers: headers });
    }

    update(obj: PerfilModelo): Observable<any> {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json');
        return this.http.put(`${this.urlEndPoint}/${obj.id}`, JSON.stringify(obj), { headers: headers });
    }
}
