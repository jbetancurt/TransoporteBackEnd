import { Component } from '@angular/core';
import UsuariosService from './usuarios.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent 
{
  constructor(private usuariosService : UsuariosService)
  {
    
  }   
}

