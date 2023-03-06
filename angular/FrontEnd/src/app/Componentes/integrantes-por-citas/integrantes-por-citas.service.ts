
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IntegrantesPorCitas } from './integrantes-por-citas.model';
const urlPage = environment.apiUrl +'/api/integrantes-por-citas';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export default class IntegrantesPorCitasService {
  _IntegrantesPorCitas? : IntegrantesPorCitas[];
  

  constructor(private httpClient : HttpClient) { }

  public Get(id : string): Observable<IntegrantesPorCitas>{ 
    let url = urlPage + "/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<IntegrantesPorCitas>(url, httpOptions);
    return obj;
  }

  public Edit(_IntegrantesPorCitas : IntegrantesPorCitas): Observable<boolean>{  
    
   // console.log(this.urlPage + '/' + (_IntegrantesPorCitas.idIntegrantePorCita));  
    return this.httpClient.put<boolean>(urlPage + '/' + (_IntegrantesPorCitas.idIntegrantePorCita), _IntegrantesPorCitas, httpOptions);
  }

  public Create(_IntegrantesPorCitas : IntegrantesPorCitas): Observable<number>{    
    return this.httpClient.post<number>(urlPage, _IntegrantesPorCitas, httpOptions);
  }
  
  public Delete(idIntegrantePorCita : string){    
    this.httpClient.delete(urlPage + '' + idIntegrantePorCita, httpOptions);
  }
}

