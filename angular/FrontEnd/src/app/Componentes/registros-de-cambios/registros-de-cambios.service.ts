import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RegistrosDeCambios } from './registros-de-cambios.model';
const urlPage = environment.apiUrl +'/api/registros-de-cambios';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export default class RegistrosDeCambiosService {
  _RegistrosDeCambios? : RegistrosDeCambios[];
  
  constructor(private httpClient : HttpClient) { }

  public Get(id : string): Observable<RegistrosDeCambios>{ 
    let url = urlPage + "/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<RegistrosDeCambios>(url, httpOptions);
    return obj;
  }
  
  public Edit(_RegistrosDeCambios : RegistrosDeCambios): Observable<boolean>{  
        //console.log(urlPage + '/' + (_Citas.idCita));  
    return this.httpClient.put<boolean>(urlPage + '/' + (_RegistrosDeCambios.idRegistroDeCambio), _RegistrosDeCambios, httpOptions);
  }

  //create nos devuelve el id del obejto que se esta creando por eso devuelve un numbre
  public Create(_RegistrosDeCambios : RegistrosDeCambios): Observable<number>{    
    return this.httpClient.post<number>(urlPage, _RegistrosDeCambios, httpOptions);
  }
  
  //aca funcion que borra segun el id que le pasemos
  public Delete(idRegistroDeCambio : string){    
     this.httpClient.delete(urlPage + '/' + idRegistroDeCambio,  httpOptions);
  }
}
