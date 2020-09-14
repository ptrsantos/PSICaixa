import { Empregado } from './../model/empregado';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observer, Observable } from 'rxjs';

const url:string = "http://localhost:52278/api/Empregados"

@Injectable({
  providedIn: 'root'
})
export class EmpregadoService {

  constructor(private http: HttpClient) { }

  enviarEmpregado(empregado: Empregado): Observable<Empregado>{

    return this.http.post<Empregado>("http://localhost:52278/api/Empregados", empregado);

  }

  enviarEmpregados(empregados: Empregado[]): Observable<Empregado[]>{

    return this.http.post<Empregado[]>("http://localhost:52278/api/Empregados", empregados);

  }

  enviarArquivo(arquivo: any): Observable<any>{
    const formData = new FormData()
    formData.append('arquivo', arquivo, arquivo.name)
    return this.http.post<any>(url, formData).pipe(
    
    );
  }

}
