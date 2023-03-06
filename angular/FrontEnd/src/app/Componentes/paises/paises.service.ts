
  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { Paises } from './paises.model';
  const urlPage = environment.apiUrl +'/api/paises';
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({
    providedIn: 'root'
  })
  export default class PaisesService {
    _Paises? : Paises[];
    
  
    constructor(private httpClient : HttpClient) { }
  
    public Get(id : string): Observable<Paises>{ 
      let url = urlPage + "/" + id; 
      console.log(url);  
      let obj =this.httpClient.get<Paises>(url, httpOptions);
      return obj;
    }
  
    public Edit(_Paises : Paises): Observable<boolean>{  
      
      //console.log(this.urlPage + '/' + (_Paises.idPais));  
      return this.httpClient.put<boolean>(urlPage + '/' + (_Paises.idPais), _Paises, httpOptions);
    }
  
    public Create(_Paises : Paises): Observable<number>{    
      return this.httpClient.post<number>(urlPage, _Paises, httpOptions);
    }
    
    public Delete(idPais : string){    
      this.httpClient.delete(urlPage +''+ idPais, httpOptions);
    }
  }
  
  