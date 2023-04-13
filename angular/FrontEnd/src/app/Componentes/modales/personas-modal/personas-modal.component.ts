import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-personas-modal',
  templateUrl: './personas-modal.component.html',
  styleUrls: ['./personas-modal.component.css']
})
export class PersonasModalComponent {
  
  public idPersona = 0;
  editar=false;
  constructor(){

  }
  public asignarid(idPersona:number){
    this.idPersona=idPersona;
   // console.log(idPersona);
    
    this.editar=true;
  }
}
