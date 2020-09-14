import { Component, OnInit, Output, ViewChild, TemplateRef, ElementRef, Input } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap';

const modalOptions: ModalOptions = {backdrop: 'static', class: 'modal-lg'}

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent  implements OnInit {
  
  exibir: boolean
  @ViewChild('template')
  private elementRef: TemplateRef<any>

  @Input() textoCabecalhoModal: string
  @Input() textoCorpoModal: string
  @Input() ocultarBotaPrimary: boolean
  @Output() enivarAcaoExcluirEmpregado = new EventEmitter()

 
  constructor(public modalRef: BsModalRef, private modalService: BsModalService) {

  }
  
  ngOnInit() {
    this.alterarExibicao()
  }

  
  abrirModal(){
    console.log('elementRef: ', this.elementRef)
    this.modalRef = this.modalService.show(this.elementRef, modalOptions)
    console.log('modalReg: ', this.modalRef)
  }

  alterarExibicao(){
    if(this.modalRef.hide)
      this.exibir = false
    else  
      this.exibir = true
  }

  fecharModal(){
    this.modalRef.hide()
  }

  confirmarExclusao(event){
    this.fecharModal()
    this.enivarAcaoExcluirEmpregado.next(event)
  }

}
