
  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { ProgramacionesDeServicios } from './programaciones-de-servicios.model';
  const urlPage = environment.apiUrl +'/api/programaciones-de-servicios';
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({
    providedIn: 'root'
  })
  export default class ProgramacionesDeServiciosService {
    _ProgramacionesDeServicios? : ProgramacionesDeServicios[];
    
  
    constructor(private httpClient : HttpClient) { }
  
    public Get(id : string): Observable<ProgramacionesDeServicios>{ 
      let url = urlPage + "/" + id; 
      console.log(url);  
      let obj =this.httpClient.get<ProgramacionesDeServicios>(url, httpOptions);
      return obj;
    }
  
    public Edit(_ProgramacionesDeServicios : ProgramacionesDeServicios): Observable<boolean>{  
      
     // console.log(this.urlPage + '/' + (_ProgramacionesDeServicios.idProgramacionDeServicio));  
      return this.httpClient.put<boolean>(urlPage + '/' + (_ProgramacionesDeServicios.idProgramacionDeServicio), _ProgramacionesDeServicios, httpOptions);
    }
  
    public Create(_ProgramacionesDeServicios : ProgramacionesDeServicios): Observable<number>{    
      return this.httpClient.post<number>(urlPage, _ProgramacionesDeServicios, httpOptions);
    }
    
    public Delete(idProgramacionDeServicio : string){    
      this.httpClient.delete(urlPage +''+ idProgramacionDeServicio, httpOptions);
    }
  }
  
  
  