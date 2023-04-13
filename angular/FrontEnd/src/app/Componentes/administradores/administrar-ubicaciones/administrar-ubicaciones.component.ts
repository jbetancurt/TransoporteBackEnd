import { Component, Input } from '@angular/core';
import { Ubicaciones } from '../../ubicaciones';
import { MatDialog } from '@angular/material/dialog';
import EmpresasService from '../../empresas/empresas.service';
import { UbicacionesModalComponent } from '../../modales/ubicaciones-modal/ubicaciones-modal.component';

@Component({
  selector: 'app-administrar-ubicaciones',
  templateUrl: './administrar-ubicaciones.component.html',
  styleUrls: ['./administrar-ubicaciones.component.css']
})
export class AdministrarUbicacionesComponent {
  displayedColumns: string[] = ['nombreubicacion', 'direccionubicacion', 'telefonoubicacion', 'observacionubicacion'];
	@Input() idEmpresa = 0;
	lstUbicaciones : Ubicaciones[] = [];
  rutaempresa:string='';
  
  ngOnInit() {
    if (this.idEmpresa > 0) {
      this.ListarUbicaciones(this.idEmpresa.toString());
    }
  }

  constructor(
    private modalService: MatDialog,
    private empresasService : EmpresasService 
    //public _route: ActivatedRoute
    ){
      
      //consultar por ruta empresa y poner el idempresa dodne esta el 9 
    
  }

  ListarUbicaciones(idEmpresa:string){
    this.empresasService.ListarUbicacionesPorEmpresas(idEmpresa).subscribe({
      next : (datapersonas:Ubicaciones[])=>{
        this.lstUbicaciones=datapersonas;
      }
    })
  }

  AbrirModalUbicacion(idUbicacion:number){
    const dialogRef = this.modalService.open(UbicacionesModalComponent);
    console.log(idUbicacion);
    
    dialogRef.componentInstance.idUbicacion=idUbicacion;
    dialogRef.componentInstance.asignarid(idUbicacion);
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

}

 

 

