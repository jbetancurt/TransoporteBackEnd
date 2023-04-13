import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Servicios } from './servicios.model';
import {ServiciosService} from './servicios.service';

@Component({
  selector: 'app-servicios',
  templateUrl: './servicios.component.html',
  styleUrls: ['./servicios.component.css']
})
export class ServiciosComponent
{
  @Input() idServicio = 0;
  FGAgregarServicio : FormGroup = this.formBuilder.group({      
    nombreservicio:new FormControl('',Validators.required),
    duracionservicio:new FormControl('',Validators.required),
    cuposervicio:new FormControl('',Validators.required),
    
  });
  constructor(private serviciosService : ServiciosService, private formBuilder: FormBuilder)
  {
    
  } 

  editarDatosServicio(idservicio:number){
    let servicio : Servicios = new Servicios;

    servicio.idServicio =idservicio;
    //agregamos los datos del formulario a la tabla personas
   // inventario.idUbicacion=this.FGAgregarInventario.value.nombreempresa;
    servicio.nombreServicio =this.FGAgregarServicio.value.nombreservicio;
    servicio.cupoServicio=this.FGAgregarServicio.value.duracionservicio;
    servicio.duracionServicio =this.FGAgregarServicio.value.cuposervicio;
    
     
    
   //suscrubimos la guardada de los datos en la tabla personas
    this.serviciosService.Edit(servicio).subscribe(); 
    
  }
  
  cargarDatosServicio(servicio:Servicios){
    this.FGAgregarServicio.patchValue({
      nombreservicio:servicio.nombreServicio,
      duracionservicio:servicio.duracionServicio,
      cuposervicio:servicio.cupoServicio,
    });
  }

  crearServicio(idEmpresa:number){
    let servicio :Servicios = new Servicios;
    servicio.idEmpresa = idEmpresa;
    servicio.nombreServicio = this.FGAgregarServicio.value.nombreservicio;
    servicio.duracionServicio = this.FGAgregarServicio.value.duracionservicio;
    servicio.cupoServicio = this.FGAgregarServicio.value.cuposervicio;
      
    this.serviciosService.Create(servicio).subscribe();
  } 

  enviarDatos() : void
  {
    console.log(this.FGAgregarServicio.value); 
  } 
}
