import { Component } from '@angular/core';
import {PaisesService} from './';

@Component({
  selector: 'app-paises',
  templateUrl: './paises.component.html',
  styleUrls: ['./paises.component.css']
})
export class PaisesComponent 
{
  constructor(private paisesService : PaisesService)
  {
    
  }
}
