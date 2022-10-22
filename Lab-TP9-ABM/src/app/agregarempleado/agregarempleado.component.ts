import { Component, OnInit } from '@angular/core';
import { EmpleadosService } from '../service/empleados.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-agregarempleado',
  templateUrl: './agregarempleado.component.html',
  styleUrls: ['./agregarempleado.component.css']
})

export class AgregarempleadoComponent implements OnInit {

  saveResp: any;
  messageclass = '';
  message = '';
  editRegister: any;
  employeeID: any;
  

  constructor(private service: EmpleadosService, private route: ActivatedRoute) {
    this.employeeID = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {

  }


  employeeForm = new FormGroup({
    id: new FormControl({ value: '', disabled: true }),
    firstName: new FormControl('', Validators.compose([Validators.required, Validators.maxLength(25), Validators.pattern('^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$')])),
    lastName: new FormControl('', Validators.compose([Validators.required, Validators.maxLength(25), Validators.pattern('^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$')])),
    title: new FormControl('', Validators.maxLength(25))
  });


  UpdateEmployees(Id: any) {
    
    if (this.employeeID != null && this.employeeForm.valid) {
      this.service.getEmployeesByID(this.employeeID).subscribe(resp => {
        this.editRegister = resp;
        this.employeeForm.controls['id'].setValue(this.employeeID);
        this.employeeForm.controls['firstName'].setValue(this.editRegister.firstName);
        this.employeeForm.controls['lastName'].setValue(this.editRegister.lastName);
        this.employeeForm.controls['title'].setValue(this.editRegister.title);

      });
      this.service.updateEmployees(this.employeeID, this.employeeForm.value).subscribe(res => {
        this.saveResp = res;
        this.message = "Registro guardado correctamente";
        this.messageclass = 'success';
      });
    }
    else {
      this.message = "Error: el registro posee campos que no han sido validados";
      this.messageclass = 'error';
    }
  }

  SaveEmployee() {
    if (this.employeeForm.valid && this.employeeID === null) {
      this.service.createEmployees(this.employeeForm.value).subscribe(resp => {
        this.saveResp = resp;
        this.message = "Registro guardado correctamente";
        this.messageclass = 'success';
      });

    }
    else {
      this.message = "Error: el registro posee campos que no han sido validados";
      this.messageclass = 'error';
    }
  }


  get firstName() {
    return this.employeeForm.controls.firstName;
  }
  get lastName() {
    return this.employeeForm.controls.lastName;
  }
  get title() {
    return this.employeeForm.controls.title;
  }
}
