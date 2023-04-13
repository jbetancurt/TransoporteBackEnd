import { Component, Input } from '@angular/core';
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
  @Input() idPersona = 0;
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

  cargarDatosPersona(persona:Personas, ciudad:Ciudades){
        
    this.FGAgregarPersonas.patchValue({
      nombrepersona:persona.nombrePersona,
      apellidopersona:persona.apellidoPersona,
      tipodocumentopersona:persona.idTipoDocumento.toString(),
      numerodocumentopersona:persona.documentoPersona,
      pais:ciudad.idPais.toString(),
      departamento:ciudad.codigoDepartamento,
      ciudad:persona.idCiudad.toString(),
      direccion:persona.direccionPersona,
      email:persona.emailPersona,
      telefono:persona.telefonoPersona,
    });
  }
  public AbrirInformacion(){
    this.personasService.Get(this.idPersona.toString()).subscribe({
      next:(datapersona:Personas) =>{
        this.ciudadesService.Get(datapersona.idCiudad.toString()).subscribe({
          next : (dataciudad:Ciudades) => {
            this.tiposDocumentosService.ListarTiposDocumentos().subscribe({
              next: (data : TiposDocumentos[]) => { 
                this.lstTiposDocumentos = data;
                this.seleccionarCiudad(dataciudad.codigoDepartamento);
                this.seleccionarDepartamento(dataciudad.idPais.toString());
                this.cargarDatosPersona(datapersona, dataciudad);                           
              },
              error: (err : string) => { console.error(err); }
            });
            
            
          }
        })
      } 
   })  
    this.paisesService.ListarPaises().subscribe({
      next: (data : Paises[]) => { 
        this.lstPaises = data;
              
      },
      error: (err : string) => { console.error(err); }
    });
    if (this.idPersona <=0){
      this.seleccionarDepartamento('44');
      this.seleccionarCiudad('05');
    }
  }
  ngOnInit() {
    this.AbrirInformacion();
    console.log(this.idPersona);
      
  }
  
  constructor(
    private personasService: PersonasService,
    private formBuilder: FormBuilder,
    private paisesService : PaisesService,
    private tiposDocumentosService : TiposDocumentosService,
    private ciudadesService : CiudadesService){
      
    //Aca estamos carcando los datos de los listados para asignar valores que dependen de otras tablas
      //this.idPersona=14;
      //console.log(this.idPersona.toString());
      
      

     
    
   
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

  editarDatosPersona(idpersona:number){
    let persona : Personas = new Personas;

    persona.idPersona=idpersona;
    //agregamos los datos del formulario a la tabla personas
    persona.nombrePersona=this.FGAgregarPersonas.value.nombrepersona;
    persona.apellidoPersona=this.FGAgregarPersonas.value.apellidopersona;
    persona.idTipoDocumento=this.FGAgregarPersonas.value.tipodocumentopersona;
    persona.documentoPersona=this.FGAgregarPersonas.value.numerodocumentopersona;
    persona.idCiudad=this.FGAgregarPersonas.value.ciudad;
    persona.direccionPersona=this.FGAgregarPersonas.value.direccion;
    persona.emailPersona=this.FGAgregarPersonas.value.email;
    persona.telefonoPersona=this.FGAgregarPersonas.value.telefono;
    console.log(persona.idTipoDocumento);
    
    
   //suscrubimos la guardada de los datos en la tabla personas
    this.personasService.Edit(persona).subscribe(); 
    
  }


  enviarDatos() : void{
    let fgPersona=this.FGAgregarPersonas.value;
    
    this.personasService.ConsultarPorDocumento(fgPersona.tipodocumentopersona, fgPersona.numerodocumentopersona ).subscribe({
      next : (datapersona:Personas) => {
       if(datapersona.idPersona<=0){
        
        this.crearPersona();
       }
       else if(datapersona.idPersona>0){
        this.editarDatosPersona(datapersona.idPersona);
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