import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmpregadosComponent } from './dominio/empregados/empregados.component';
import { TabelaEmpregadosComponent } from './dominio/tabela-empregados/tabela-empregados.component';

const routes: Routes = [
  {path: 'Home', component: EmpregadosComponent, data: {title: "Home"}},
  {path: '', pathMatch: 'full', redirectTo: 'Home' },
  {path: 'RelacaoEmpregados', component: TabelaEmpregadosComponent, data: {title: "Relação de Empregados"}},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
