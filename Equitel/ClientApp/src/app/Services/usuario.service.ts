import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Usuario } from '../Interfaces/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private endpoint:string = environment.endPoint;
  private apirUrl: string = this.endpoint + "Usuario/";

  constructor(private http:HttpClient) { }

  getList(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${this.apirUrl}lista`);
}
}
