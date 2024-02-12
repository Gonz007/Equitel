import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Producto } from '../Interfaces/producto';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  private endpoint: string = environment.endPoint;
  private apirUrl: string = this.endpoint + "Producto/";

  constructor(private http: HttpClient) { }

  getList(): Observable<Producto[]> {
    return this.http.get<Producto[]>(`${this.apirUrl}lista`);
  }

  add(modelo: Producto): Observable<Producto> {
    return this.http.post<Producto>(`${this.apirUrl}guardar`,modelo);
  }

  update(id: number, modelo: Producto): Observable<Producto> {
    return this.http.put<Producto>(`${this.apirUrl}actualizar/${id}`, modelo);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apirUrl}eliminar/${id}`);
  }

}
