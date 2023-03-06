  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { ContactosEmpresas } from './contactos-empresas.model';
  const urlPage = environment.apiUrl +'/api/contactos-empresas';
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({
    providedIn: 'root'
  })
  export default class ContactosEmpresasService {
    _ContactosEmpresas? : ContactosEmpresas[];
    
  
    constructor(private httpClient : HttpClient) { }
  
    public Get(id : string): Observable<ContactosEmpresas>{ 
      let url = urlPage + "/" + id; 
      console.log(url);  
      let obj =this.httpClient.get<ContactosEmpresas>(url, httpOptions);
      return obj;
    }
  
    public Edit(_ContactosEmpresas : ContactosEmpresas): Observable<ContactosEmpresas>{  
      
      console.log(urlPage + '/' + (_ContactosEmpresas.idContactoEmpresa));  
      return this.httpClient.put<ContactosEmpresas>(urlPage + '/' + (_ContactosEmpresas.idContactoEmpresa), _ContactosEmpresas, httpOptions);
    }
  
    public Create(_ContactosEmpresas : ContactosEmpresas): Observable<ContactosEmpresas>{    
      return this.httpClient.post<ContactosEmpresas>(urlPage, _ContactosEmpresas, httpOptions);
    }
    
    public Insert(_ContactosEmpresas : ContactosEmpresas): Observable<ContactosEmpresas>{    
      return this.httpClient.post<ContactosEmpresas>(urlPage , _ContactosEmpresas, httpOptions);
    }
  }
  