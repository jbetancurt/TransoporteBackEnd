import { Component } from '@angular/core';
import EmpresasService from './empresas.service';

@Component({
  selector: 'app-empresas',
  templateUrl: './empresas.component.html',
  styleUrls: ['./empresas.component.css']
})
export class EmpresasComponent 
{
  constructor(private empresasService : EmpresasService)
  {
    
  }
}
