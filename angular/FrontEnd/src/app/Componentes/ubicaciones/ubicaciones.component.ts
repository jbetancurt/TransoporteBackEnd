import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {UbicacionesService} from './ubicaciones.service';

@Component({
  selector: 'app-ubicaciones',
  templateUrl: './ubicaciones.component.html',
  styleUrls: ['./ubicaciones.component.css']
})
export class UbicacionesComponent 
{
  FGAgregarUbicaciones : FormGroup = this.formBuilder.group({      
    nombreubicacion:new FormControl('',Validators.required),
    direccionubicacion:new FormControl('',Validators.required),
    telefono:new FormControl('',Validators.required),
    observacionubicacion:'',
  });
  
  constructor(private ubicacionesService : UbicacionesService,
    private formBuilder: FormBuilder)
  {
    
  }  
  enviarDatos() : void
  {
    console.log(this.FGAgregarUbicaciones.value); 
  }
}
