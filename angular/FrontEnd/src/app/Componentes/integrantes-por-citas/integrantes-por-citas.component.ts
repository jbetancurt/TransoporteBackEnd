import { Component } from '@angular/core';
import IntegrantesPorCitasService from './integrantes-por-citas.service';

@Component({
  selector: 'app-integrantes-por-citas',
  templateUrl: './integrantes-por-citas.component.html',
  styleUrls: ['./integrantes-por-citas.component.css']
})
export class IntegrantesPorCitasComponent 
{
  constructor(private integrantesPorCitasService : IntegrantesPorCitasService)
  {
    
  }
}
