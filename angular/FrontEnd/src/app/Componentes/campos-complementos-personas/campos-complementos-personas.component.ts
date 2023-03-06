import { Component } from '@angular/core';
import CamposComplementosPersonasService from './campos-complementos-personas.service';

@Component({
  selector: 'app-campos-complementos-personas',
  templateUrl: './campos-complementos-personas.component.html',
  styleUrls: ['./campos-complementos-personas.component.css']
})
export class CamposComplementosPersonasComponent 
{
  constructor(private camposComplementosPersonasService : CamposComplementosPersonasService)
  {
    
  }
}
