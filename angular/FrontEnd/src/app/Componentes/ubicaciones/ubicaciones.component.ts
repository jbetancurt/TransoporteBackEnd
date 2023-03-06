import { Component } from '@angular/core';
import UbicacionesService from './ubicaciones.service';

@Component({
  selector: 'app-ubicaciones',
  templateUrl: './ubicaciones.component.html',
  styleUrls: ['./ubicaciones.component.css']
})
export class UbicacionesComponent 
{
  constructor(private ubicacionesService : UbicacionesService)
  {
    
  }   
}
