import { Empregado } from './model/empregado';
import { Injectable } from '@angular/core';
import { CollectionViewer, DataSource } from "@angular/cdk/collections";
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

const url = "http://localhost:52278/api/Empregados"

@Injectable({
  providedIn: 'root'
})
export class DominioService {

  constructor(private http: HttpClient) { }

  

  retornarEmpregadosPorPaginacao(pagina: string, tamanhoPagina: string) : Observable<Empregado[]>{
    debugger
    let params = new HttpParams;
    params = params.set("pagina", pagina.toString())
    params = params.set("tamanhoPagina", tamanhoPagina.toString())
    return this.http.get<Empregado[]>("http://localhost:51933/api/Empregados", {params: params})
  }

  salvarEmpregados(empregados: Empregado[]): Observable<Empregado[]>{
    return this.http.post<Empregado[]>(url, empregados)
  }

  obterEmpregados(pagina: string, tamanho: string): Observable<Empregado[]>{
    let params = new HttpParams();
    params = params.set('pagina', pagina);
    params = params.set('tamanho', tamanho);
    return this.http.get<Empregado[]>(url + "?" + params.toString())
  }

  ExcluirEmpregado(id: string, pagina: string, tamanho: string): Observable<Empregado[]>{
    let params = new HttpParams();
    params = params.set('id', id);
    params = params.set('pagina', pagina);
    params = params.set('tamanho', tamanho);
    return this.http.delete<Empregado[]>(url + "?" + params.toString())
  }

}
