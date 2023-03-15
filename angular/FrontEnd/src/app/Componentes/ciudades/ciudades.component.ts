import { Component } from '@angular/core';
import {CiudadesService} from './ciudades.service';

@Component({
  selector: 'app-ciudades',
  templateUrl: './ciudades.component.html',
  styleUrls: ['./ciudades.component.css']
})
export class CiudadesComponent 
{
  constructor(private ciudadesService : CiudadesService)
  {
    
  }
}
