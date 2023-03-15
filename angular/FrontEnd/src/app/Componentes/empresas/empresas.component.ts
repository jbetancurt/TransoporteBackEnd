import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CiudadesService, Ciudades,Departamentos } from '../ciudades';
import { Paises, PaisesService} from '../paises/';
import { Personas, PersonasService } from '../personas';
import { TiposDocumentos, TiposDocumentosService } from '../tipos-documentos';
import { TiposNegocios, TiposNegociosService } from '../tipos-negocios';
import { Ubicaciones, UbicacionesService } from '../ubicaciones';
import { Empresas } from './empresas.model';



import EmpresasService from './empresas.service';

@Component({
  selector: 'app-empresas',
  templateUrl: './empresas.component.html',
  styleUrls: ['./empresas.component.css']
})

export class EmpresasComponent 
{
  lstPaises: Paises[]=[];
  lstTiposDocumentos: TiposDocumentos[]=[];
  lstDepartamentos: Departamentos[]=[];
  lstCiudades: Ciudades[]=[];
  lstTipoNegocio: TiposNegocios[]=[];

  FGAgregarEmpresas : FormGroup = this.formBuilder.group({      
    nombreresponsable:new FormControl('',Validators.required),
    apellidoresponsable:new FormControl('',Validators.required),
    tipodocumentoresponsable:'1',
    numerodocumentoresponsable:'',
    nombreempresa: '',
    tipodocumentoempresa:'',
    numerodocumentoempresa:'',
    tipodenegocio:'',
    pais:'44',
    departamento:'',
    ciudad:'',
    direccion:'',
    email:new FormControl('',[
      Validators.required,
      Validators.email
    ]),
    telefono:'',
    rutaempresa:new FormControl('',Validators.required),
  });
  constructor(
    public  router: Router,
    private formBuilder: FormBuilder,
    private paisesService : PaisesService,
    private tiposNegociosService : TiposNegociosService,
    private tiposDocumentosService : TiposDocumentosService,
    private ciudadesService : CiudadesService,
    private personasService : PersonasService,
    private ubicacionesService : UbicacionesService,
    private empresasService : EmpresasService){
      this.tiposDocumentosService.ListarTiposDocumentos().subscribe({
        next: (data : TiposDocumentos[]) => { 
          this.lstTiposDocumentos = data;
                 
        },
        error: (err : string) => { console.error(err); }
      });


      this.tiposNegociosService.ListarTiposNegocios().subscribe({
        next: (data : TiposNegocios[]) => { 
          this.lstTipoNegocio = data;
                 
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

  crearEmpresas (idPersona : number){
       //al guardar los datos de la persona esta devuelve el id que lo utilizaremos para relacionarlo a la tabla
       //empresas donde este dato se captura para agregarlo como id persona o idresponsable en la tabla empresas 
       let empresa : Empresas = new Empresas;
       empresa.idPersonaResponsable = idPersona;
       empresa.idCiudad=this.FGAgregarEmpresas.value.ciudad;
       empresa.idTipoNegocio=this.FGAgregarEmpresas.value.tipodenegocio;
       empresa.idTipoDocumento=this.FGAgregarEmpresas.value.tipodocumentoempresa;
       empresa.documentoEmpresa=this.FGAgregarEmpresas.value.numerodocumentoempresa;
       empresa.razonSocialEmpresa=this.FGAgregarEmpresas.value.nombreempresa;
       empresa.direccionEmpresa=this.FGAgregarEmpresas.value.direccion;
       empresa.emailEmpresa=this.FGAgregarEmpresas.value.email;
       empresa.telefonoEmpresa=this.FGAgregarEmpresas.value.telefono;
       empresa.rutaEmpresa=this.FGAgregarEmpresas.value.rutaempresa;
       //suscribe la guardada de los adtos en la tabla empresa
       this.empresasService.Create(empresa).subscribe({
         next: (dataempresa:number) =>{
           // al guardar los datos de empresa el devuelve el id de la empresa guaradda este se utiliza para  
           // iniciar la guardada de los datos en la tabla ubicacion iniciando con el id empresa  
           this.crearUbicacion(dataempresa);
         }
       })  
  }

  crearUbicacion(idEmpresa:number){
    let ubicacion :Ubicaciones = new Ubicaciones;
    ubicacion.idEmpresa = idEmpresa;
    ubicacion.nombreUbicacion = this.FGAgregarEmpresas.value.nombreempresa;
    ubicacion.direccionUbicacion = this.FGAgregarEmpresas.value.direccion;
    ubicacion.telefonoUbicacion = this.FGAgregarEmpresas.value.telefono;
  
    this.ubicacionesService.Create(ubicacion).subscribe();
  } 

  crearPersona(){
    let persona : Personas = new Personas;

    
    //agregamos los datos del formulario a la tabla personas
    persona.nombrePersona=this.FGAgregarEmpresas.value.nombreresponsable;
    persona.apellidoPersona=this.FGAgregarEmpresas.value.apellidoresponsable;
    persona.idTipoDocumento=this.FGAgregarEmpresas.value.tipodocumentoresponsable;
    persona.documentoPersona=this.FGAgregarEmpresas.value.numerodocumentoresponsable;
    persona.idCiudad=this.FGAgregarEmpresas.value.ciudad;
    persona.direccionPersona=this.FGAgregarEmpresas.value.direccion;
    persona.emailPersona=this.FGAgregarEmpresas.value.email;
    persona.telefonoPersona=this.FGAgregarEmpresas.value.telefono;
    
   //suscrubimos la guardada de los datos en la tabla personas
    this.personasService.Create(persona).subscribe({
      next : (datapersona:number) => {
        this.crearEmpresas(datapersona);
      }
    }); 
    //console.log(this.FGAgregarEmpresas.value);
  }

  rutaEmpresaChange():void{
    console.log(this.FGAgregarEmpresas.value.rutaempresa);
    this.empresasService.ConsultarPorRutaEmpresa(this.FGAgregarEmpresas.value.rutaempresa).subscribe({
      next : (dataempresa:Empresas) => {
        console.log(dataempresa);
        if(dataempresa.rutaEmpresa == this.FGAgregarEmpresas.value.rutaempresa){
          this.FGAgregarEmpresas.controls["rutaempresa"].setErrors({rutainvalida:true});
          console.log(this.FGAgregarEmpresas.value.rutaempresa);
        }
        else{
          this.FGAgregarEmpresas.controls["rutaempresa"].setErrors(null);  
          //FGAgregarEmpresas.controls["rutaempresa"].errors?.rutainvalida        
        }
      }  
    })
    
  }

  enviarDatos() : void{
    this.empresasService.ConsultarPorDocumentoEmpresa(this.FGAgregarEmpresas.value.tipodocumentoempresa, this.FGAgregarEmpresas.value.numerodocumentoempresa).subscribe({
      next : (dataempresa:Empresas) =>{
        if(dataempresa.idEmpresa <= 0){
          this.personasService.ConsultarPorDocumento(this.FGAgregarEmpresas.value.tipodocumentoresponsable, this.FGAgregarEmpresas.value.numerodocumentoresponsable ).subscribe({
            next : (datapersona:Personas) => {
             if(datapersona.idPersona>0){
               this.crearEmpresas(datapersona.idPersona);
             }
             else{
               this.crearPersona();
             }
           }
         }); 
       
        }
        else if(dataempresa.rutaEmpresa){
          this.router.navigate([dataempresa.rutaEmpresa + '/administrar'])
        }
      }

    })
        
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

