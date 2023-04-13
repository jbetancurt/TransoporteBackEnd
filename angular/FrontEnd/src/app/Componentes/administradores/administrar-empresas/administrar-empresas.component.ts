import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Empresas } from '../../empresas';
import EmpresasService from '../../empresas/empresas.service';
import { PersonasModalComponent } from '../../modales/personas-modal/personas-modal.component';
import { Personas } from '../../personas';

@Component({
  selector: 'app-administrar-empresas',
  templateUrl: './administrar-empresas.component.html',
  styleUrls: ['./administrar-empresas.component.css']
})
export class AdministrarEmpresasComponent {
  displayedColumns: string[] = ['nombre', 'apellido', 'direccion', 'editar'];
	idEmpresa:number=0;
  mostraradministrarpersona:boolean=false;
  mostraradministrarubicacion:boolean=false;
  mostraradministraragenda:boolean=false;
  mostraradministrarcitas:boolean=false;
	lstPersonas : Personas[] = [];
  rutaempresa:string='';
  
  ngOnInit() {
    
    this._route.params.subscribe(params => {
      this.rutaempresa = params['rutaempresa'];
      this.empresasService.ConsultarPorRutaEmpresa(this.rutaempresa).subscribe({
        next:(dataempresa:Empresas)=>{
          if (dataempresa.idEmpresa > 0) {
           // this.ListarPersonas(dataempresa.idEmpresa.toString());
           this.idEmpresa=dataempresa.idEmpresa;
          }
          
        }
      }); 
    });
            
  }
  
  constructor(
    private modalService: MatDialog,
    private empresasService : EmpresasService, 
    public _route: ActivatedRoute){
      
      //consultar por ruta empresa y poner el idempresa dodne esta el 9 
    
  }

OcultarTodos(){
  this.mostraradministrarpersona=false;
  this.mostraradministrarubicacion=false;
  this.mostraradministraragenda=false;
  this.mostraradministrarcitas=false;
}

 AdministrarPersona(){
  if(this.idEmpresa>0){
    this.OcultarTodos();
    this.mostraradministrarpersona=true;
  }  
 }

 AdministrarUbicacion(){
  if(this.idEmpresa>0){
    this.OcultarTodos();
    this.mostraradministrarubicacion=true;
  }  
 }


 ListarPersonas(idEmpresa:string){
  console.log(1);
  
  this.empresasService.ListarPersonasPorEmpresas(idEmpresa).subscribe({
    next : (datapersonas:Personas[])=>{
      this.lstPersonas=datapersonas;
    }
  })
 }

 AbrirModalPersona(idPersona:number){
  const dialogRef = this.modalService.open(PersonasModalComponent);
  console.log(idPersona);
  
  dialogRef.componentInstance.idPersona=idPersona;
  dialogRef.componentInstance.asignarid(idPersona);
  dialogRef.afterClosed().subscribe(result => {
    //console.log(`Dialog result: ${result}`);
  });
 }
}
