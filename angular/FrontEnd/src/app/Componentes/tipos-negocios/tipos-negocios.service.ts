
  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { TiposNegocios } from './tipos-negocios.model';
  const urlPage = environment.apiUrl +'/api/TiposNegocios';
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({
    providedIn: 'root'
  })
  export class TiposNegociosService {
    _TiposNegocios? : TiposNegocios[];
    
  
    constructor(private httpClient : HttpClient) { }
  
    public Get(id : string): Observable<TiposNegocios>{ 
      let url = urlPage + "/" + id; 
      console.log(url);  
      let obj =this.httpClient.get<TiposNegocios>(url, httpOptions);
      return obj;
    }

    public ListarTiposNegocios(): Observable<TiposNegocios[]>{ 
      let url = urlPage; 
      //console.log(url);  
      let obj =this.httpClient.get<TiposNegocios[]>(url, httpOptions);
      return obj;
    }
  
    public Edit(_TiposNegocios : TiposNegocios): Observable<boolean>{  
      
     // console.log(urlPage + '/' + (_TiposNegocios.idTipoNegocio));  
      return this.httpClient.put<boolean>(urlPage + '/' + (_TiposNegocios.idTipoNegocio), _TiposNegocios, httpOptions);
    }
  
    public Create(_TiposNegocios : TiposNegocios): Observable<number>{    
      return this.httpClient.post<number>(urlPage, _TiposNegocios, httpOptions);
    }
    
    public Delete(idTipoNegocio : string){    
      this.httpClient.delete(urlPage + '' + idTipoNegocio, httpOptions);
    }
  }
  
  
  
  
  