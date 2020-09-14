import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabelaEmpregadosComponent } from './tabela-empregados.component';

import { MatInputModule, MatPaginatorModule, MatProgressSpinnerModule, 
         MatSortModule, MatExpansionModule, MatFormFieldModule, MatIconModule, 
         MatTableModule, MatButtonModule, MatCardModule } from "@angular/material";
         
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import {MatDialogModule} from '@angular/material/dialog'

import { NgxSpinnerModule } from "ngx-spinner";
import { ModalComponentModule } from '../modal/modal.component.module';


@NgModule({
  declarations: [
    TabelaEmpregadosComponent
  ],
  exports: [
    TabelaEmpregadosComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatProgressSpinnerModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    NgxSpinnerModule,
    MatDialogModule,
    ModalComponentModule
  ]
})
export class TabelaEmpregadosModule { }
