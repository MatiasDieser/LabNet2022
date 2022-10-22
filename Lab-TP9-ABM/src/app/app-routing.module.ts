import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EmpleadosComponent } from './empleados/empleados.component';
import { ListaempleadosComponent } from './listaempleados/listaempleados.component';
import { AgregarempleadoComponent } from './agregarempleado/agregarempleado.component';
import { flush } from '@angular/core/testing';

const routes: Routes= [
  {path:'', component:HomeComponent},
  {path:'empleados', component:EmpleadosComponent, children:[
    {path: '', component: ListaempleadosComponent},
    {path:'agregar', component: AgregarempleadoComponent},
    {path:'editar/:id', component: AgregarempleadoComponent}
  ]},
  {path:'**', component: HomeComponent}
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
