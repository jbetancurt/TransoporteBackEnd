
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Roles } from './roles.model';
const urlPage = environment.apiUrl +'/api/roles';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export default class RolesService {
  _Roles? : Roles[];
  
  constructor(private httpClient : HttpClient) { }

  public Get(id : string): Observable<Roles>{ 
    let url = urlPage + "/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<Roles>(url, httpOptions);
    return obj;
  }

  public ListarRoles(): Observable<Roles[]>{ 
    let url = urlPage; 
    //console.log(url);  
    let obj =this.httpClient.get<Roles[]>(url, httpOptions);
    return obj;
  }

  public Edit(_Roles : Roles): Observable<boolean>{  
    
    //console.log(this.urlPage + '/' + (_Roles.idRol));  
    return this.httpClient.put<boolean>(urlPage + '/' + (_Roles.idRol), _Roles, httpOptions);
  }

  public Create(_Roles : Roles): Observable<number>{    
    return this.httpClient.post<number>(urlPage, _Roles, httpOptions);
  }
  
  public Delete(idRol : string){    
    this.httpClient.delete(urlPage +''+ idRol, httpOptions);
  }
}




