import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'


@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {

  apiUrl= 'https://localhost:44331/api/Employees';
 

  constructor(private http: HttpClient) { }

  getAllEmployees(){
    return this.http.get(this.apiUrl);
  }
  getEmployeesByID(Id: any){
    return this.http.get(this.apiUrl+'/'+Id);
  }
  deleteEmployeesByID(Id: any){
    return this.http.delete(this.apiUrl+'/'+Id);
  }
  createEmployees(data:any){
    return this.http.post(this.apiUrl, data);
  }
  updateEmployees(Id: any, data:any){
    return this.http.put<any>(this.apiUrl+'/'+Id, data);
  }
}
