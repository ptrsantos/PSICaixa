import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
 import { EmpregadosModule } from './empregados/empregados.module';
 import { TabelaEmpregadosModule } from './tabela-empregados/tabela-empregados.module';
//import { TableParentModule } from './table-parent/table-parent.module';

@NgModule({
  declarations: [],
  exports: [
  ],
  imports: [
    // CommonModule,
     EmpregadosModule,
    // TabelaEmpregadosModule
  ]
})
export class DominioModule { }
