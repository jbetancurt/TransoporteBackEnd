
  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { TiposDocumentos } from './tipos-documentos.model';
  const urlPage = environment.apiUrl +'/api/tipos-documentos';
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({
    providedIn: 'root'
  })
  export default class TiposDocumentosService {
    _TiposDocumentos? : TiposDocumentos[];
    
  
    constructor(private httpClient : HttpClient) { }
  
    public Get(id : string): Observable<TiposDocumentos>{ 
      let url = urlPage + "/" + id; 
      console.log(url);  
      let obj =this.httpClient.get<TiposDocumentos>(url, httpOptions);
      return obj;
    }
  
    public Edit(_TiposDocumentos : TiposDocumentos): Observable<boolean>{  
      
      //console.log(this.urlPage + '/' + (_TiposDocumentos.idTipoDocumento));  
      return this.httpClient.put<boolean>(urlPage + '/' + (_TiposDocumentos.idTipoDocumento), _TiposDocumentos, httpOptions);
    }
  
    public Create(_TiposDocumentos : TiposDocumentos): Observable<number>{    
      return this.httpClient.post<number>(urlPage, _TiposDocumentos, httpOptions);
    }
    
    public Delete(idTipoDocumento : string){    
      this.httpClient.delete(urlPage +''+ idTipoDocumento, httpOptions);
    }
  }
  
  
  
  
  