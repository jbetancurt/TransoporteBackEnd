import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Ubicaciones } from './ubicaciones.model';
import {UbicacionesService} from './ubicaciones.service';

@Component({
  selector: 'app-ubicaciones',
  templateUrl: './ubicaciones.component.html',
  styleUrls: ['./ubicaciones.component.css']
})
export class UbicacionesComponent 
{
  @Input() idUbicacion = 0;
  FGAgregarUbicaciones : FormGroup = this.formBuilder.group({      
    nombreubicacion:new FormControl('',Validators.required),
    direccionubicacion:new FormControl('',Validators.required),
    telefonoubicacion:new FormControl('',Validators.required),
    observacionubicacion:'',
  });
  
  constructor(private ubicacionesService : UbicacionesService,
    private formBuilder: FormBuilder)
  {
    
  }  

  cargarDatosUbicacion(ubicacion:Ubicaciones){
    this.FGAgregarUbicaciones.patchValue({
      nombreubicacion:ubicacion.nombreUbicacion,
      direccionubicacion:ubicacion.direccionUbicacion,
      telefonoubicacion:ubicacion.telefonoUbicacion,
      observacionubicacion:ubicacion.observacionUbicacion,
    });
  }


  editarDatosUbicacion(idubicacion:number){
    let ubicacion : Ubicaciones = new Ubicaciones;

    ubicacion.idUbicacion=idubicacion;
    //agregamos los datos del formulario a la tabla personas
   // inventario.idUbicacion=this.FGAgregarInventario.value.nombreempresa;
    ubicacion.nombreUbicacion =this.FGAgregarUbicaciones.value.nombreubicacion;
    ubicacion.direccionUbicacion =this.FGAgregarUbicaciones.value.direccionubicacion;
    ubicacion.telefonoUbicacion =this.FGAgregarUbicaciones.value.telefonoubicacion;
    ubicacion.observacionUbicacion =this.FGAgregarUbicaciones.value.observacionubicacion;
     
    
   //suscrubimos la guardada de los datos en la tabla personas
    this.ubicacionesService.Edit(ubicacion).subscribe(); 
    
  }

  crearUbicacion(idEmpresa:number){
    let ubicacion :Ubicaciones = new Ubicaciones;
    ubicacion.idEmpresa = idEmpresa;
    ubicacion.nombreUbicacion = this.FGAgregarUbicaciones.value.nombreubicacion;
    ubicacion.direccionUbicacion = this.FGAgregarUbicaciones.value.direccionubicacion;
    ubicacion.telefonoUbicacion = this.FGAgregarUbicaciones.value.telefonoubicacion;
    ubicacion.observacionUbicacion = this.FGAgregarUbicaciones.value.observacionubicacion;
     
    this.ubicacionesService.Create(ubicacion).subscribe();
  } 

  enviarDatos() : void
  {
    console.log(this.FGAgregarUbicaciones.value); 
  }
}
