import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CitasPorProgramacionesDeServicios } from './citas-por-programaciones-de-servicios.model';
const urlPage = environment.apiUrl +'/api/citas-por-programaciones-de-servicios';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export default class CitasPorProgramacionesDeServiciosService {
  _CitasPorProgramacionesDeServicios? : CitasPorProgramacionesDeServicios[];
  
  constructor(private httpClient : HttpClient) { }

  public Get(id : string): Observable<CitasPorProgramacionesDeServicios>{ 
    let url = urlPage + "/" + id;    
    console.log(url);  
    let obj =this.httpClient.get<CitasPorProgramacionesDeServicios>(url, httpOptions);
    return obj;
  }

  public Edit(_CitasPorProgramacionesDeServicios : CitasPorProgramacionesDeServicios): Observable<boolean>{  
    
    //console.log(this.urlPage + '/' + (_CitasPorProgramacionesDeServicios.idCitaPorProgramacionDeServicio));  
    return this.httpClient.put<boolean>(urlPage + '/' + (_CitasPorProgramacionesDeServicios.idCitaPorProgramacionDeServicio), _CitasPorProgramacionesDeServicios, httpOptions);
  }

  public Create(_CitasPorProgramacionesDeServicios : CitasPorProgramacionesDeServicios): Observable<number>{    
    return this.httpClient.post<number>(urlPage, _CitasPorProgramacionesDeServicios, httpOptions);
  }
  public Delete(idCitaPorProgramacionDeServicio : string){    
     this.httpClient.delete(urlPage + '/' +  idCitaPorProgramacionDeServicio, httpOptions);
  }
}
