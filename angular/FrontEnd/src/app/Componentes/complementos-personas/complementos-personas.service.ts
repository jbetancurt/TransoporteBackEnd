
  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { ComplementosPersonas } from './complementos-personas.model';
  const urlPage = environment.apiUrl +'/api/complementos-personas';
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({
    providedIn: 'root'
  })
  export default class ComplementosPersonasService {
    _ComplementosPersonas? : ComplementosPersonas[];
    
  
    constructor(private httpClient : HttpClient) { }
  
    public Get(id : string): Observable<ComplementosPersonas>{ 
      let url = urlPage + "/" + id; 
      console.log(url);  
      let obj =this.httpClient.get<ComplementosPersonas>(url, httpOptions);
      return obj;
    }
  
    public Edit(_ComplementosPersonas : ComplementosPersonas): Observable<boolean>{  
      
    //  console.log(this.urlPage + '/' + (_ComplementosPersonas.idComplementoPersona));  
      return this.httpClient.put<boolean>(urlPage + '/' + (_ComplementosPersonas.idComplementoPersona), _ComplementosPersonas, httpOptions);
    }
  
    public Create(_ComplementosPersonas : ComplementosPersonas): Observable<number>{    
      return this.httpClient.post<number>(urlPage, _ComplementosPersonas, httpOptions);
    }
    
    public Delete(idComplementoPersona : string){    
      this.httpClient.delete(urlPage +'/'+ idComplementoPersona, httpOptions);
    }
  }
  