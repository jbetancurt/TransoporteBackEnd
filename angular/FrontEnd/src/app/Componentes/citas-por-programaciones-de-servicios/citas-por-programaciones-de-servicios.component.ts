import { Component } from '@angular/core';
import CitasPorProgramacionesDeServiciosService from './citas-por-programaciones-de-servicios.service';

@Component({
  selector: 'app-citas-por-programaciones-de-servicios',
  templateUrl: './citas-por-programaciones-de-servicios.component.html',
  styleUrls: ['./citas-por-programaciones-de-servicios.component.css']
})
export class CitasPorProgramacionesDeServiciosComponent 
{
  constructor(private citasPorProgramacionesDeServiciosService : CitasPorProgramacionesDeServiciosService)
  {
    
  }
}
