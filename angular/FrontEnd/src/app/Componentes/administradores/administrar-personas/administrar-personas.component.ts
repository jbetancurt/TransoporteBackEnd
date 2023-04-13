import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
//import { ActivatedRoute } from '@angular/router';
//import { Empresas } from '../../empresas';
import EmpresasService from '../../empresas/empresas.service';
import { PersonasModalComponent } from '../../modales/personas-modal/personas-modal.component';
import { Personas } from '../../personas';

@Component({
  selector: 'app-administrar-personas',
  templateUrl: './administrar-personas.component.html',
  styleUrls: ['./administrar-personas.component.css']
})
export class AdministrarPersonasComponent {  
  displayedColumns: string[] = ['nombre', 'apellido', 'direccion', 'editar', 'borrar'];
	@Input() idEmpresa = 0;
	lstPersonas : Personas[] = [];
  rutaempresa:string='';
  
  ngOnInit() {
    if (this.idEmpresa > 0) {
      this.ListarPersonas(this.idEmpresa.toString());
    }
  }
  
  constructor(
    private modalService: MatDialog,
    private empresasService : EmpresasService 
    //public _route: ActivatedRoute
    ){
      
      //consultar por ruta empresa y poner el idempresa dodne esta el 9 
    
 }

 ListarPersonas(idEmpresa:string){
  //console.log(1);
  
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
