  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { Empresas } from './empresas.model';
  const urlPage = environment.apiUrl +'/api/empresas';
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  @Injectable({
    providedIn: 'root'
  })
  export default class EmpresasService {
    _Empresas? : Empresas[];
    
  
    constructor(private httpClient : HttpClient) { }
  
    public Get(id : string): Observable<Empresas>{ 
      let url = urlPage + "/" + id; 
      
      let obj =this.httpClient.get<Empresas>(url, httpOptions);
      return obj;
    }

    public ConsultarPorRutaEmpresa(rutaempresa:string): Observable<Empresas>{ 
      let url = urlPage + "/consultarporruta/" + rutaempresa; 
       
      let obj =this.httpClient.get<Empresas>(url, httpOptions);
      return obj;
    }

    public ConsultarPorDocumentoEmpresa(idTipoDocumentoEmpresa : string, documentoEmpresa:string): Observable<Empresas>{ 
      let url = urlPage + "/" + idTipoDocumentoEmpresa + "/" + documentoEmpresa; 
       
      let obj =this.httpClient.get<Empresas>(url, httpOptions);
      return obj;
    }
  
    public Edit(_Empresas : Empresas): Observable<boolean>{  
      
      //console.log(this.urlPage + '/' + (_Empresas.idEmpresa));  
      return this.httpClient.put<boolean>(urlPage + '/' + (_Empresas.idEmpresa), _Empresas, httpOptions);
    }
  
    public Create(_Empresas : Empresas): Observable<number>{    
      console.log(_Empresas);
      
      return this.httpClient.post<number>(urlPage, _Empresas, httpOptions);
    }
    
    public Delete(idEmpresa : string){    
      this.httpClient.delete(urlPage +''+ idEmpresa, httpOptions);
    }
  }
  