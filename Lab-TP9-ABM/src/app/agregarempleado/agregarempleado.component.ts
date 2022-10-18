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
    if (this.employeeID != null && this.employeeID != 0) {
      this.UpdateEmployees(this.employeeID);
    }
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
    this.service.getEmployeesByID(Id).subscribe(resp => {
      this.editRegister = resp;
      if (this.editRegister != null) {
        this.employeeForm = new FormGroup({
          id: new FormControl(this.editRegister.id),
          firstName: new FormControl(this.editRegister.firstName,Validators.compose([Validators.required, Validators.maxLength(25), Validators.pattern('^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$')])),
          lastName: new FormControl(this.editRegister.lastName,Validators.compose([Validators.required, Validators.maxLength(25), Validators.pattern('^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$')])),
          title: new FormControl(this.editRegister.title,Validators.maxLength(25))
        });
      }
    })
  }

  SaveEmployee() {
    if (this.employeeForm.valid && this.employeeID === null) {
      this.service.createEmployees(this.employeeForm.value).subscribe(resp => {
        this.saveResp = resp;
        this.message = "Registro guardado correctamente";
        this.messageclass = 'success';
      });

    } if (this.employeeID != null) {
      this.UpdateEmployees(this.employeeID);
      this.message = "Registro guardado correctamente";
        this.messageclass = 'success';
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
