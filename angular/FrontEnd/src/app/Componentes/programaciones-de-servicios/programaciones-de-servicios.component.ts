import { Component } from '@angular/core';
import ProgramacionesDeServiciosService from './programaciones-de-servicios.service';

@Component({
  selector: 'app-programaciones-de-servicios',
  templateUrl: './programaciones-de-servicios.component.html',
  styleUrls: ['./programaciones-de-servicios.component.css']
})
export class ProgramacionesDeServiciosComponent
{
  constructor(private programacionesDeServiciosService : ProgramacionesDeServiciosService)
  {
    
  }   
}
