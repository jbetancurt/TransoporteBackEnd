import { Component } from '@angular/core';
import ComplementosPersonasService from './complementos-personas.service';

@Component({
  selector: 'app-complementos-personas',
  templateUrl: './complementos-personas.component.html',
  styleUrls: ['./complementos-personas.component.css']
})
export class ComplementosPersonasComponent
{ 
  constructor(private complementosPersonasService : ComplementosPersonasService)
  {
    
  }

}
