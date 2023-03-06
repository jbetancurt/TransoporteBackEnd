import { Component } from '@angular/core';
import LocacionesService from './locaciones.service';

@Component({
  selector: 'app-locaciones',
  templateUrl: './locaciones.component.html',
  styleUrls: ['./locaciones.component.css']
})
export class LocacionesComponent 
{
  constructor(private locacionesService : LocacionesService)
  {
    
  }
}
