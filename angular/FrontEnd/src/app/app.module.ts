import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

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
import { MatCardModule } from "@angular/material/card";
import { MatInputModule } from "@angular/material/input";
import { MatFormFieldModule } from "@angular/material/form-field";

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
    UsuariosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule,
    MatCardModule,
    MatInputModule,
    MatFormFieldModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
