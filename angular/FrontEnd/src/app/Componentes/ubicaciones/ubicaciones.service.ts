
  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { Ubicaciones } from './ubicaciones.model';
  const urlPage = environment.apiUrl +'/api/ubicaciones';
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({
    providedIn: 'root'
  })
  export class UbicacionesService {
    _Ubicaciones? : Ubicaciones[];
    
  
    constructor(private httpClient : HttpClient) { }
  
    public Get(id : string): Observable<Ubicaciones>{ 
      let url = urlPage + "/" + id; 
      console.log(url);  
      let obj =this.httpClient.get<Ubicaciones>(url, httpOptions);
      return obj;
    }

    public ListarUbicaciones(): Observable<Ubicaciones[]>{ 
      let url = urlPage; 
      //console.log(url);  
      let obj =this.httpClient.get<Ubicaciones[]>(url, httpOptions);
      return obj;
    }
  
    public Edit(_Ubicaciones : Ubicaciones): Observable<boolean>{  
      
     // console.log(urlPage + '/' + (_Ubicaciones.idUbicacion));  
      return this.httpClient.put<boolean>(urlPage + '/' + (_Ubicaciones.idUbicacion), _Ubicaciones, httpOptions);
    }
  
    public Create(_Ubicaciones : Ubicaciones): Observable<number>{    
      return this.httpClient.post<number>(urlPage, _Ubicaciones, httpOptions);
    }
    
    public Delete(idUbicacion : string){    
      this.httpClient.delete(urlPage +''+ idUbicacion, httpOptions);
    }
  }
  
  
  
  
  