import { Component } from '@angular/core';
import TiposNegociosService from './tipos-negocios.service';

@Component({
  selector: 'app-tipos-negocios',
  templateUrl: './tipos-negocios.component.html',
  styleUrls: ['./tipos-negocios.component.css']
})
export class TiposNegociosComponent 
{
  constructor(private tiposNegociosService : TiposNegociosService)
  {
    
  }   
}
