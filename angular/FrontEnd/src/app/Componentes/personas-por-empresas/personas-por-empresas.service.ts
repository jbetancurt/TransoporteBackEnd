import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PersonasPorEmpresas } from './personas-por-empresas.model';
const urlPage = environment.apiUrl +'/api/personasporempresas';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export  class PersonasPorEmpresasService {
  _PersonasPorEmpresas? : PersonasPorEmpresas[];
  
  constructor(private httpClient : HttpClient) { }

  public Get(id : string): Observable<PersonasPorEmpresas>{ 
    let url = urlPage + "/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<PersonasPorEmpresas>(url, httpOptions);
    return obj;
  }


  public ConsultarPorIdPersonayIdEmpresa(idEmpresa : string, idPersona:string): Observable<PersonasPorEmpresas>{ 
    let url = urlPage + "/" + idEmpresa + "/" + idPersona; 
    console.log(url);  
    let obj =this.httpClient.get<PersonasPorEmpresas>(url, httpOptions);
    return obj;
  }
  
  public Edit(_PersonasPorEmpresas : PersonasPorEmpresas): Observable<boolean>{  
        //console.log(urlPage + '/' + (_Citas.idCita));  
    return this.httpClient.put<boolean>(urlPage + '/' + (_PersonasPorEmpresas.idPersonaPorEmpresa), _PersonasPorEmpresas, httpOptions);
  }

  //create nos devuelve el id del obejto que se esta creando por eso devuelve un numbre
  public Create(_PersonasPorEmpresas : PersonasPorEmpresas): Observable<number>{    
    return this.httpClient.post<number>(urlPage, _PersonasPorEmpresas, httpOptions);
  }
  
  //aca funcion que borra segun el id que le pasemos
  public Delete(idPersonaPorEmpresa : string){    
     this.httpClient.delete(urlPage + '/' + idPersonaPorEmpresa,  httpOptions);
  }
}
