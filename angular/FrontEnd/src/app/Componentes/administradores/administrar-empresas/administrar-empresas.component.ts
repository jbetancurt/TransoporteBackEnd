import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-administrar-empresas',
  templateUrl: './administrar-empresas.component.html',
  styleUrls: ['./administrar-empresas.component.css']
})
export class AdministrarEmpresasComponent {
  rutaempresa:string='';
  constructor(public _route: ActivatedRoute){
    this._route.params.subscribe(params => {
      this.rutaempresa = params['rutaempresa'];
      
    });
  }

}
