
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Inventarios } from './inventarios.model';
const urlPage = environment.apiUrl +'/api/inventarios';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export default class InventariosService {
  _Inventarios? : Inventarios[];
  

  constructor(private httpClient : HttpClient) { }

  public Get(id : string): Observable<Inventarios>{ 
    let url = urlPage + "/" + id; 
    console.log(url);  
    let obj =this.httpClient.get<Inventarios>(url, httpOptions);
    return obj;
  }

  public Edit(_Inventarios : Inventarios): Observable<boolean>{  
    
    //console.log(this.urlPage + '/' + (_Inventarios.idInventario));  
    return this.httpClient.put<boolean>(urlPage + '/' + (_Inventarios.idInventario), _Inventarios, httpOptions);
  }

  public Create(_Inventarios : Inventarios): Observable<number>{    
    return this.httpClient.post<number>(urlPage, _Inventarios, httpOptions);
  }
  
  public Delete(idInventario : string){    
    this.httpClient.delete(urlPage +''+ idInventario, httpOptions);
  }
}

