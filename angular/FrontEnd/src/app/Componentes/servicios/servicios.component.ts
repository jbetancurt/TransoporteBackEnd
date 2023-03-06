import { Component } from '@angular/core';
import ServiciosService from './servicios.service';

@Component({
  selector: 'app-servicios',
  templateUrl: './servicios.component.html',
  styleUrls: ['./servicios.component.css']
})
export class ServiciosComponent
{
  constructor(private serviciosService : ServiciosService)
  {
    
  }   
}
