
  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { CitasPorLocaciones } from './citas-por-locaciones.model';
  const urlPage = environment.apiUrl +'/api/citas-por-locaciones';
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({
    providedIn: 'root'
  })
  export default class CitasPorLocacionesService {
    _CitasPorLocaciones? : CitasPorLocaciones[];
    
  
    constructor(private httpClient : HttpClient) { }
  
    public Get(id : string): Observable<CitasPorLocaciones>{ 
      let url = urlPage + "/" + id; 
      console.log(url);  
      let obj =this.httpClient.get<CitasPorLocaciones>(url, httpOptions);
      return obj;
    }
  
    public Edit(_CitasPorLocaciones : CitasPorLocaciones): Observable<boolean>{  
      
      //console.log(this.urlPage + '/' + (_CitasPorLocaciones.idCitaPorLocacion));  
      return this.httpClient.put<boolean>(urlPage + '/' + (_CitasPorLocaciones.idCitaPorLocacion), _CitasPorLocaciones, httpOptions);
    }
  
    public Create(_CitasPorLocaciones : CitasPorLocaciones): Observable<number>{    
      return this.httpClient.post<number>(urlPage, _CitasPorLocaciones, httpOptions);
    }
    
    public Delete(idCitaPorLocacion : string){    
      this.httpClient.delete(urlPage + '/'+ idCitaPorLocacion, httpOptions);
    }
  }
  