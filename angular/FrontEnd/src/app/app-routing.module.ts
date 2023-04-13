import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdministrarEmpresasComponent } from './Componentes/administradores/administrar-empresas/administrar-empresas.component';
import { CitasComponent } from './Componentes/citas';
import { EmpresasComponent } from './Componentes/empresas';
import { InventariosComponent } from './Componentes/inventarios';
import { PersonasComponent } from './Componentes/personas';
import { UbicacionesComponent } from './Componentes/ubicaciones';
import { LocacionesComponent } from './Componentes/locaciones';
import { ServiciosComponent } from './Componentes/servicios';
import { PersonasPorEmpresasComponent } from './Componentes/personas-por-empresas';
import { AdministrarPersonasComponent } from './Componentes/administradores/administrar-personas/administrar-personas.component';

const routes: Routes = [
  { path: '', component : CitasComponent, pathMatch: 'full' },
  { path: 'empresas', component: EmpresasComponent },
  { path: 'personas', component: PersonasComponent },
  { path: 'ubicaciones', component: UbicacionesComponent },
  { path: 'locaciones', component: LocacionesComponent },
  { path: 'inventarios', component: InventariosComponent },
  { path: 'servicios', component: ServiciosComponent },
  { path: 'personas-por-empresas', component: PersonasPorEmpresasComponent },
  { path: ':rutaempresa/administrarempresa', component: AdministrarEmpresasComponent },
  { path: ':rutaempresa/administrarpersona', component: AdministrarPersonasComponent }
]; 
//EmpresasComponent
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
