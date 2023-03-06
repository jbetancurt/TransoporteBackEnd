import { Component } from '@angular/core';
import RolesService from './roles.service';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
export class RolesComponent
{
  constructor(private rolesService : RolesService)
  {
    
  }   
}
