
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CamposComplementosPersonas } from './campos-complementos-personas.model';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
const urlPage = environment.apiUrl +'/api/CamposComplementosPersonas';
@Injectable({
  providedIn: 'root'
})
export default class CamposComplementosPersonasService {
  _CamposComplementosPersonas? : CamposComplementosPersonas[];
  nombre:string='juan';
  constructor(private httpClient : HttpClient) { }

  public Get(id : string): Observable<CamposComplementosPersonas>{ 
    let url = urlPage + "/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<CamposComplementosPersonas>(url, httpOptions);
    return obj;
  }

  public Edit(_CamposComplementosPersonas : CamposComplementosPersonas): Observable<boolean>{  
    
   // console.log(urlPage + '/' + (_CamposComplementosPersonas.idCampoComplementoPersona));  
    return this.httpClient.put<boolean>(urlPage + '/' + (_CamposComplementosPersonas.idCampoComplementoPersona), _CamposComplementosPersonas, httpOptions);
  }

  public Create(_CamposComplementosPersonas : CamposComplementosPersonas): Observable<number>{    
    return this.httpClient.post<number>(urlPage, _CamposComplementosPersonas, httpOptions);
  }
  
  public Delete(idCampoComplementoPersona : string){    
    this.httpClient.delete(urlPage + '/' + idCampoComplementoPersona, httpOptions);
  } 
}
