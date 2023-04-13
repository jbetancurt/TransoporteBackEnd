import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-ubicaciones-modal',
  templateUrl: './ubicaciones-modal.component.html',
  styleUrls: ['./ubicaciones-modal.component.css']
})
export class UbicacionesModalComponent {
  public idUbicacion = 0;
  editar=false;
  constructor(){

  }
  public asignarid(idUbicacion:number){
    this.idUbicacion=idUbicacion;
   // console.log(idPersona);
    
    this.editar=true;
  }
}






