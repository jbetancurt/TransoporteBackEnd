import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Citas } from './citas.model';
const urlPage = environment.apiUrl +'/api/citas';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export default class CitasService {
  _Citas? : Citas[];
  
  constructor(private httpClient : HttpClient) { }

  public Get(id : string): Observable<Citas>{ 
    let url = urlPage + "/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<Citas>(url, httpOptions);
    return obj;
  }
  
  public Edit(_Citas : Citas): Observable<boolean>{  
        //console.log(urlPage + '/' + (_Citas.idCita));  
    return this.httpClient.put<boolean>(urlPage + '/' + (_Citas.idCita), _Citas, httpOptions);
  }

  //create nos devuelve el id del obejto que se esta creando por eso devuelve un numbre
  public Create(_Citas : Citas): Observable<number>{    
    return this.httpClient.post<number>(urlPage, _Citas, httpOptions);
  }
  
  //aca funcion que borra segun el id que le pasemos
  public Delete(idCita : string){    
     this.httpClient.delete(urlPage + '/' + idCita,  httpOptions);
  }
}
