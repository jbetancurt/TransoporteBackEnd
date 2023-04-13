import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Locaciones } from './locaciones.model';
import {LocacionesService} from './locaciones.service';

@Component({
  selector: 'app-locaciones',
  templateUrl: './locaciones.component.html',
  styleUrls: ['./locaciones.component.css']
})
export class LocacionesComponent 
{
  
  @Input() idLocacion = 0;
  FGAgregarLocaciones : FormGroup = this.formBuilder.group({      
    nombrelocacion:new FormControl('',Validators.required),
    observacionlocacion:'',
  });
  constructor(private locacionesService : LocacionesService,
    private formBuilder: FormBuilder)
  {
    
  }

  cargarDatosLocaciones(locacion:Locaciones){
    this.FGAgregarLocaciones.patchValue({
      nombrelocacion:locacion.nombreLocacion,
      observacionlocacion:locacion.observacionLocacion,
      
    });
  }


  editarDatosLocaciones(idlocacion:number){
    let locacion : Locaciones = new Locaciones;

    locacion.idLocacion=idlocacion;
    //agregamos los datos del formulario a la tabla personas
   // inventario.idUbicacion=this.FGAgregarInventario.value.nombreempresa;
    locacion.nombreLocacion=this.FGAgregarLocaciones.value.nombrelocacion;
    locacion.observacionLocacion =this.FGAgregarLocaciones.value.observacionlocacion;
    
    
   //suscrubimos la guardada de los datos en la tabla personas
    this.locacionesService.Edit(locacion).subscribe(); 
    
  }

  crearLocacion(idUbicacion:number){
    let locacion :Locaciones = new Locaciones;
    locacion.idUbicacion = idUbicacion;
    locacion.nombreLocacion = this.FGAgregarLocaciones.value.nombrelocacion;
    locacion.observacionLocacion = this.FGAgregarLocaciones.value.observacionlocacion;
          
    this.locacionesService.Create(locacion).subscribe();
  } 
  
  enviarDatos() : void
  {
    console.log(this.FGAgregarLocaciones.value); 
  }
}
