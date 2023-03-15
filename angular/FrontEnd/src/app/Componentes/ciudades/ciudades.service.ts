import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Ciudades, Departamentos } from './ciudades.model';
const urlPage = environment.apiUrl +'/api/ciudades';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export  class CiudadesService {
  _Ciudades? : Ciudades[];
  

  constructor(private httpClient : HttpClient) { }

  public Get(id : string): Observable<Ciudades>{ 
    let url = urlPage + "/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<Ciudades>(url, httpOptions);
    return obj;
  }

  public ListarCiudades(id : string): Observable<Ciudades[]>{ 
    let url = urlPage + "/ListarCiudades/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<Ciudades[]>(url, httpOptions);
    return obj;
  }

  public ListarDepartamentos(id : string): Observable<Departamentos[]>{ 
    let url = urlPage + "/ListarDepartamentos/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<Departamentos[]>(url, httpOptions);
    return obj;
  }

  public Edit(_Ciudades : Ciudades): Observable<boolean>{  
    
    //console.log(this.urlPage + '/' + (_Ciudades.idCiudad));  
    return this.httpClient.put<boolean>(urlPage + '/' + (_Ciudades.idCiudad), _Ciudades, httpOptions);
  }

  public Create(_Ciudades : Ciudades): Observable<number>{    
    return this.httpClient.post<number>(urlPage, _Ciudades, httpOptions);
  }
  
  public Delete(idCiudad : string){    
    this.httpClient.delete(urlPage + '/' + idCiudad, httpOptions);
  }
}
