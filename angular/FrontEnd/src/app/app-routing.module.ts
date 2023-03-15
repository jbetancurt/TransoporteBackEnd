import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdministrarEmpresasComponent } from './Componentes/administradores/administrar-empresas/administrar-empresas.component';
import { CitasComponent } from './Componentes/citas';
import { EmpresasComponent } from './Componentes/empresas';
import { InventariosComponent } from './Componentes/inventarios';
import { PersonasComponent } from './Componentes/personas';
import { UbicacionesComponent } from './Componentes/ubicaciones';

const routes: Routes = [
  { path: '', component : CitasComponent, pathMatch: 'full' },
  { path: 'empresas', component: EmpresasComponent },
  { path: 'personas', component: PersonasComponent },
  { path: 'ubicaciones', component: UbicacionesComponent },
  { path: 'inventarios', component: InventariosComponent },
  { path: ':rutaempresa/administrar', component: AdministrarEmpresasComponent }
]; 
//EmpresasComponent
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
