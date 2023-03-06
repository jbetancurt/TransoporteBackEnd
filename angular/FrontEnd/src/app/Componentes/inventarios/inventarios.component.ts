import { Component } from '@angular/core';
import InventariosService from './inventarios.service';

@Component({
  selector: 'app-inventarios',
  templateUrl: './inventarios.component.html',
  styleUrls: ['./inventarios.component.css']
})
export class InventariosComponent
{
  constructor(private inventariosService : InventariosService)
  {
    
  }
}
