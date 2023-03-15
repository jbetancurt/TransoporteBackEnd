import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Ciudades, CiudadesService, Departamentos } from '../ciudades';
import { Paises, PaisesService } from '../paises';
import { TiposDocumentos, TiposDocumentosService } from '../tipos-documentos';
import { Personas, PersonasService } from '../personas';


@Component({
  selector: 'app-personas',
  templateUrl: './personas.component.html',
  styleUrls: ['./personas.component.css']
})
export class PersonasComponent
{
  lstPaises: Paises[]=[];
  lstTiposDocumentos: TiposDocumentos[]=[];
  lstDepartamentos: Departamentos[]=[];
  lstCiudades: Ciudades[]=[];

  FGAgregarPersonas : FormGroup = this.formBuilder.group({      
    nombrepersona:new FormControl('',Validators.required),
    apellidopersona:new FormControl('',Validators.required),
    tipodocumentopersona:'1',
    numerodocumentopersona:'',
    pais:'44',
    departamento:'',
    ciudad:'',
    direccion:'',
    email:new FormControl('',[
      Validators.required,
      Validators.email
    ]),
    telefono:'',
  });

  constructor(
    private personasService: PersonasService,
    private formBuilder: FormBuilder,
    private paisesService : PaisesService,
    private tiposDocumentosService : TiposDocumentosService,
    private ciudadesService : CiudadesService){
      this.tiposDocumentosService.ListarTiposDocumentos().subscribe({
        next: (data : TiposDocumentos[]) => { 
          this.lstTiposDocumentos = data;
                 
        },
        error: (err : string) => { console.error(err); }
      });
    
      this.paisesService.ListarPaises().subscribe({
      next: (data : Paises[]) => { 
        this.lstPaises = data;
               
      },
      error: (err : string) => { console.error(err); }
    });
    this.seleccionarDepartamento('44');
    this.seleccionarCiudad('05');
   
  }

  crearPersona(){
    let persona : Personas = new Personas;

    
    //agregamos los datos del formulario a la tabla personas
    persona.nombrePersona=this.FGAgregarPersonas.value.nombrepersona;
    persona.apellidoPersona=this.FGAgregarPersonas.value.apellidopersona;
    persona.idTipoDocumento=this.FGAgregarPersonas.value.tipodocumentopersona;
    persona.documentoPersona=this.FGAgregarPersonas.value.numerodocumentopersona;
    persona.idCiudad=this.FGAgregarPersonas.value.ciudad;
    persona.direccionPersona=this.FGAgregarPersonas.value.direccion;
    persona.emailPersona=this.FGAgregarPersonas.value.email;
    persona.telefonoPersona=this.FGAgregarPersonas.value.telefono;
    console.log(persona);
    
   //suscrubimos la guardada de los datos en la tabla personas
    this.personasService.Create(persona).subscribe(); 
    
  }


  enviarDatos() : void{
    let fgPersona=this.FGAgregarPersonas.value;
    
    this.personasService.ConsultarPorDocumento(fgPersona.tipodocumentopersona, fgPersona.numerodocumentopersona ).subscribe({
      next : (datapersona:Personas) => {
       if(datapersona.idPersona<=0){
        
        this.crearPersona();
       }
       
      }
    }); 

    
  }

 seleccionarDepartamento(idPais:string) 
 {
    this.ciudadesService.ListarDepartamentos(idPais).subscribe(
    {
      next: (data : Departamentos[]) => 
      { 
        this.lstDepartamentos = data;
             
      },
      error: (err : string) => { console.error(err); }
    });
 }
 
 seleccionarCiudad(codigoDepartamento:string) 
 {
    this.ciudadesService.ListarCiudades(codigoDepartamento).subscribe(
    {
      next: (data : Ciudades[]) => 
      { 
        this.lstCiudades = data;
               
      },
      error: (err : string) => { console.error(err); }
    });
 }
}