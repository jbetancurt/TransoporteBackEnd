
  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { Servicios } from './servicios.model';
  const urlPage = environment.apiUrl +'/api/servicios';
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({
    providedIn: 'root'
  })
  export  class ServiciosService {
    _Servicios? : Servicios[];
    
  
    constructor(private httpClient : HttpClient) { }
  
    public Get(id : string): Observable<Servicios>{ 
      let url = urlPage + "/" + id; 
      console.log(url);  
      let obj =this.httpClient.get<Servicios>(url, httpOptions);
      return obj;
    }
  
    public Edit(_Servicios : Servicios): Observable<boolean>{  
      
      //console.log(this.urlPage + '/' + (_Servicios.idServicio));  
      return this.httpClient.put<boolean>(urlPage + '/' + (_Servicios.idServicio), _Servicios, httpOptions);
    }
  
    public Create(_Servicios : Servicios): Observable<number>{    
      return this.httpClient.post<number>(urlPage, _Servicios, httpOptions);
    }
    
    public Delete(idServicio :string){    
      this.httpClient.delete(urlPage +''+ idServicio, httpOptions);
    }
  }
  
  
  
  
  