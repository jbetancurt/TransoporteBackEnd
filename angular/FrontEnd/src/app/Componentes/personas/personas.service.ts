
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Personas } from './personas.model';
const urlPage = environment.apiUrl +'/api/personas';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export default class PersonasService {
  _Personas? : Personas[];
  
  constructor(private httpClient : HttpClient) { }

  public Get(id : string): Observable<Personas>{ 
    let url = urlPage + "/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<Personas>(url, httpOptions);
    return obj;
  }

  public Edit(_Personas : Personas): Observable<boolean>{  
    
   // console.log(this.urlPage + '/' + (_Personas.idPersona));  
    return this.httpClient.put<boolean>(urlPage + '/' + (_Personas.idPersona), _Personas, httpOptions);
  }

  public Create(_Personas : Personas): Observable<number>{    
    return this.httpClient.post<number>(urlPage, _Personas, httpOptions);
  }
  
  public Delete(idPersona : string){    
    this.httpClient.delete(urlPage +''+ idPersona, httpOptions);
  }
}


