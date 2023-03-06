import { Component } from '@angular/core';
import RolesUsuariosService from './roles-usuarios.service';

@Component({
  selector: 'app-roles-usuarios',
  templateUrl: './roles-usuarios.component.html',
  styleUrls: ['./roles-usuarios.component.css']
})
export class RolesUsuariosComponent
{
  constructor(private rolesUsuariosService : RolesUsuariosService)
  {
    
  }   
}
