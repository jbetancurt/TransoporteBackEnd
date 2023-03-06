import { Component } from '@angular/core';
import CitasPorLocacionesService from './citas-por-locaciones.service';

@Component({
  selector: 'app-citas-por-locaciones',
  templateUrl: './citas-por-locaciones.component.html',
  styleUrls: ['./citas-por-locaciones.component.css']
})
export class CitasPorLocacionesComponent
{
  constructor(private citasPorLocacionesService : CitasPorLocacionesService)
  {
    
  }
}
