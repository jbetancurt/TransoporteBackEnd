

  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { RolesUsuarios } from './roles-usuarios.model';
  const urlPage = environment.apiUrl +'/api/roles-usuarios';
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({
    providedIn: 'root'
  })
  export default class RolesUsuariosService {
    _RolesUsuarios? : RolesUsuarios[];
    
  
    constructor(private httpClient : HttpClient) { }
  
    public Get(id : string): Observable<RolesUsuarios>{ 
      let url = urlPage + "/" + id; 
      console.log(url);  
      let obj =this.httpClient.get<RolesUsuarios>(url, httpOptions);
      return obj;
    }
  
    public Edit(_RolesUsuarios : RolesUsuarios): Observable<boolean>{  
      
      //console.log(this.urlPage + '/' + (_RolesUsuarios.idRolUsuario));  
      return this.httpClient.put<boolean>(urlPage + '/' + (_RolesUsuarios.idRolUsuario), _RolesUsuarios, httpOptions);
    }
  
    public Create(_RolesUsuarios : RolesUsuarios): Observable<number>{    
      return this.httpClient.post<number>(urlPage, _RolesUsuarios, httpOptions);
    }
    
    public Delete(idRolUsuario : string){    
      this.httpClient.delete(urlPage +''+idRolUsuario, httpOptions);
    }
  }
  
  
  
  
  