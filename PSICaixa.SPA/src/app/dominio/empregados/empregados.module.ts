import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmpregadosComponent } from './empregados.component';
import { EmpregadoService } from './empregado.service';
import { HttpClientModule } from '@angular/common/http'
import { TabelaEmpregadosModule } from '../tabela-empregados/tabela-empregados.module';
import { ModalComponentModule } from '../modal/modal.component.module';

@NgModule({
  declarations: [
    EmpregadosComponent
  ],
  exports: [
    EmpregadosComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    TabelaEmpregadosModule,
    ModalComponentModule
  ],
  providers: [EmpregadoService]
})
export class EmpregadosModule { }
