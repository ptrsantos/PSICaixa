import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalComponent } from './modal.component';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@NgModule({
  declarations: [
    ModalComponent
  ],
  exports: [
    ModalComponent
  ],
  imports: [
    CommonModule
  ],
  providers: [
    [BsModalRef],
    [BsModalService] 
  ]
})
export class ModalComponentModule { }
