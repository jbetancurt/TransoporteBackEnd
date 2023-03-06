import { Component } from '@angular/core';
import { Citas } from './citas.model';
import CitasService from './citas.service';
import { environment } from 'src/environments/environment';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-citas',
  templateUrl: './citas.component.html',
  styleUrls: ['./citas.component.css']
})
export class CitasComponent {
  FGAgregarCitas : FormGroup = this.formBuilder.group({      
    
  });
  constructor(private formBuilder: FormBuilder,private citasService : CitasService)
  {
       
  }
  
  //listarcitas(idCita:string):Citas 
  //{
    // let _citas:Citas = new Citas;
    // this.citasService.Get(idCita).subscribe({
    //  next: (data : Citas) => {           
              
    //    _citas = data;
        
   //    },
   //   error: (err : string) => { console.error(err); }
 //   });
 //    return _citas;  
 // }
  
}
