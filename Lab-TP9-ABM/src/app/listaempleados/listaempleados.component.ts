import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { EmpleadosService } from '../service/empleados.service';
import { AgregarempleadoComponent } from '../agregarempleado/agregarempleado.component';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-listaempleados',
  templateUrl: './listaempleados.component.html',
  styleUrls: ['./listaempleados.component.css']
})
export class ListaempleadosComponent implements OnInit {

employeedata: any;

  constructor(private service: EmpleadosService) {
    this.getAll();
   }

  ngOnInit(): void {
  }

  getAll() {
    this.service.getAllEmployees().subscribe(resp => {
      this.employeedata = resp;
    });
  }

  delete(Id: any){
    if(confirm("Estas seguro de borrar este registro?")){
      this.service.deleteEmployeesByID(Id).subscribe(resp=>{
        this.getAll();    
        this.confirmDelete(Id); 
      })   
    }
  }
  confirmDelete(Id: any){
    this.service.getEmployeesByID(Id).subscribe(resp => {
      this.employeedata = resp;
      if(this.employeedata.error === "HttpErrorResponse"){
        alert('Registro eliminado correctamente')       
     }else{
      alert('Error: no se ha podido eliminar el registro')
      }
    })
    
  }
}

// HttpErrorResponse