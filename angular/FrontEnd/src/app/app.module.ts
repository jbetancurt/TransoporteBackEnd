import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from "./Modulos/material/material.module";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CitasComponent } from './Componentes/citas/citas.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CamposComplementosPersonasComponent } from './Componentes/campos-complementos-personas/campos-complementos-personas.component';
import { CitasPorLocacionesComponent } from './Componentes/citas-por-locaciones/citas-por-locaciones.component';
import { CitasPorProgramacionesDeServiciosComponent } from './Componentes/citas-por-programaciones-de-servicios/citas-por-programaciones-de-servicios.component';
import { CiudadesComponent } from './Componentes/ciudades/ciudades.component';
import { ComplementosPersonasComponent } from './Componentes/complementos-personas/complementos-personas.component';
import { ContactosEmpresasComponent } from './Componentes/contactos-empresas/contactos-empresas.component';
import { EmpresasComponent } from './Componentes/empresas/empresas.component';
import { IntegrantesPorCitasComponent } from './Componentes/integrantes-por-citas/integrantes-por-citas.component';
import { InventariosComponent } from './Componentes/inventarios/inventarios.component';
import { LocacionesComponent } from './Componentes/locaciones/locaciones.component';
import { PaisesComponent } from './Componentes/paises/paises.component';
import { PersonasComponent } from './Componentes/personas/personas.component';
import { ProgramacionesDeServiciosComponent } from './Componentes/programaciones-de-servicios/programaciones-de-servicios.component';
import { RolesComponent } from './Componentes/roles/roles.component';
import { RolesUsuariosComponent } from './Componentes/roles-usuarios/roles-usuarios.component';
import { ServiciosComponent } from './Componentes/servicios/servicios.component';
import { TiposDocumentosComponent } from './Componentes/tipos-documentos/tipos-documentos.component';
import { TiposNegociosComponent } from './Componentes/tipos-negocios/tipos-negocios.component';
import { UbicacionesComponent } from './Componentes/ubicaciones/ubicaciones.component';
import { UsuariosComponent } from './Componentes/usuarios/usuarios.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdministrarEmpresasComponent } from './Componentes/administradores/administrar-empresas/administrar-empresas.component';
import {PersonasPorEmpresasComponent} from "./Componentes/personas-por-empresas/personas-por-empresas.component";
import {RegistrosDeCambiosComponent} from "./Componentes/registros-de-cambios/registros-de-cambios.component";
import { PersonasModalComponent } from './Componentes/modales/personas-modal/personas-modal.component';
import { EmpresasModalComponent } from './Componentes/modales/empresas-modal/empresas-modal.component';
import { InventariosModalComponent } from './Componentes/modales/inventarios-modal/inventarios-modal.component';
import { LocacionesModalComponent } from './Componentes/modales/locaciones-modal/locaciones-modal.component';
import { ServiciosModalComponent } from './Componentes/modales/servicios-modal/servicios-modal.component';
import { UbicacionesModalComponent } from './Componentes/modales/ubicaciones-modal/ubicaciones-modal.component';
import { AdministrarPersonasComponent } from './Componentes/administradores/administrar-personas/administrar-personas.component';
import { AdministrarUbicacionesComponent } from './Componentes/administradores/administrar-ubicaciones/administrar-ubicaciones.component';
import { AdministrarProgramacionCitasComponent } from './Componentes/administradores/administrar-programacion-citas/administrar-programacion-citas.component';
import { AdministrarProgramacionAgendaComponent } from './Componentes/administradores/administrar-programacion-agenda/administrar-programacion-agenda.component';


@NgModule({
  declarations: [
    AppComponent,
    CitasComponent,
    CamposComplementosPersonasComponent,
    CitasPorLocacionesComponent,
    CitasPorProgramacionesDeServiciosComponent,
    CiudadesComponent,
    ComplementosPersonasComponent,
    ContactosEmpresasComponent,
    EmpresasComponent,
    IntegrantesPorCitasComponent,
    InventariosComponent,
    LocacionesComponent,
    PaisesComponent,
    PersonasComponent,
    ProgramacionesDeServiciosComponent,
    RolesComponent,
    RolesUsuariosComponent,
    ServiciosComponent,
    TiposDocumentosComponent,
    TiposNegociosComponent,
    UbicacionesComponent,
    UsuariosComponent,
    AdministrarEmpresasComponent,
    PersonasPorEmpresasComponent,
    RegistrosDeCambiosComponent,
    PersonasModalComponent,
    EmpresasModalComponent,
    InventariosModalComponent,
    LocacionesModalComponent,
    ServiciosModalComponent,
    UbicacionesModalComponent,
    AdministrarPersonasComponent,
    AdministrarUbicacionesComponent,
    AdministrarProgramacionCitasComponent,
    AdministrarProgramacionAgendaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule,
    MaterialModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
