import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Ubicaciones, UbicacionesService} from '../ubicaciones';
import {Inventarios, InventariosService} from '../inventarios';

@Component({
  selector: 'app-inventarios',
  templateUrl: './inventarios.component.html',
  styleUrls: ['./inventarios.component.css']
})
export class InventariosComponent
{
  @Input() idInventario = 0;
  lstUbicaciones: Ubicaciones[]=[];
  FGAgregarInventario : FormGroup = this.formBuilder.group({      
    codigoproducto:new FormControl('',Validators.required),
    nombreproducto:new FormControl('',Validators.required),
    cantidadinventario:new FormControl('',Validators.required),
  //  ubicacioninventario:new FormControl('',Validators.required),
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
  
  cargarDatosInventario(inventario:Inventarios){
    this.FGAgregarInventario.patchValue({
      codigoproducto: inventario.codigoProducto,
      nombreproducto:inventario.nombreProducto,
      cantidadinventario:inventario.cantidadProducto,
      
    });
  }

  editarDatosEmpresa(idinventario:number){
    let inventario : Inventarios = new Inventarios;

    inventario.idInventario=idinventario;
    //agregamos los datos del formulario a la tabla personas
   // inventario.idUbicacion=this.FGAgregarInventario.value.nombreempresa;
    inventario.codigoProducto=this.FGAgregarInventario.value.codigoproducto;
    inventario.nombreProducto=this.FGAgregarInventario.value.nombreproducto;
    inventario.cantidadProducto=this.FGAgregarInventario.value.cantidadinventario;
     
    
   //suscrubimos la guardada de los datos en la tabla personas
    this.inventariosService.Edit(inventario).subscribe(); 
    
  }

  crearInventario(idUbicacion:number){
    let inventario :Inventarios = new Inventarios;
    inventario.idUbicacion = idUbicacion;
    inventario.codigoProducto = this.FGAgregarInventario.value.codigoproducto;
    inventario.nombreProducto = this.FGAgregarInventario.value.nombreproducto;
    inventario.cantidadProducto = this.FGAgregarInventario.value.cantidadinventario;
      
    this.inventariosService.Create(inventario).subscribe();
  } 
  
  enviarDatos() : void
  {
    console.log(this.FGAgregarInventario.value); 
  }
}
