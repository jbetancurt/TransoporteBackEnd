import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Ubicaciones, UbicacionesService} from '../ubicaciones';
import {InventariosService} from '../inventarios';

@Component({
  selector: 'app-inventarios',
  templateUrl: './inventarios.component.html',
  styleUrls: ['./inventarios.component.css']
})
export class InventariosComponent
{
  lstUbicaciones: Ubicaciones[]=[];
  FGAgregarInventario : FormGroup = this.formBuilder.group({      
    codigoproducto:new FormControl('',Validators.required),
    nombreproducto:new FormControl('',Validators.required),
    cantidadinventario:new FormControl('',Validators.required),
    ubicacioninventario:new FormControl('',Validators.required),
  });
  constructor(private inventariosService : InventariosService,private ubicacionesService : UbicacionesService, private formBuilder: FormBuilder)
  {
    this.ubicacionesService.ListarUbicaciones().subscribe({
      next: (data : Ubicaciones[]) => { 
        this.lstUbicaciones = data;
               
      },
      error: (err : string) => { console.error(err); }
    });
  }
  
  
  
  enviarDatos() : void
  {
    console.log(this.FGAgregarInventario.value); 
  }
}
