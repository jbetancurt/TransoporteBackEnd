
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Locaciones } from './locaciones.model';
const urlPage = environment.apiUrl +'/api/locaciones';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class LocacionesService {
  _Locaciones? : Locaciones[];
  

  constructor(private httpClient : HttpClient) { }

  public Get(id : string): Observable<Locaciones>{ 
    let url = urlPage + "/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<Locaciones>(url, httpOptions);
    return obj;
  }

  public Edit(_Locaciones : Locaciones): Observable<boolean>{  
    
    //console.log(this.urlPage + '/' + (_Locaciones.idLocacion));  
    return this.httpClient.put<boolean>(urlPage + '/' + (_Locaciones.idLocacion), _Locaciones, httpOptions);
  }

  public Create(_Locaciones : Locaciones): Observable<number>{    
    return this.httpClient.post<number>(urlPage, _Locaciones, httpOptions);
  }
  
  public Delete(idLocacion : string){    
    this.httpClient.delete(urlPage +''+ idLocacion, httpOptions);
  }
}

