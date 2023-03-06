import { Component } from '@angular/core';
import PersonasService from './personas.service';

@Component({
  selector: 'app-personas',
  templateUrl: './personas.component.html',
  styleUrls: ['./personas.component.css']
})
export class PersonasComponent
{
  constructor(private personasService : PersonasService)
  {
    
  }   

}
