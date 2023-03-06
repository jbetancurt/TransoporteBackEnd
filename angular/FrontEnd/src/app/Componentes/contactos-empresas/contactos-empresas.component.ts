import { Component } from '@angular/core';
import ContactosEmpresasService from './contactos-empresas.service';

@Component({
  selector: 'app-contactos-empresas',
  templateUrl: './contactos-empresas.component.html',
  styleUrls: ['./contactos-empresas.component.css']
})
export class ContactosEmpresasComponent 
{
  constructor(private contactosEmpresasService : ContactosEmpresasService)
  {
    
  }
}
