import { EmpregadoService } from './empregado.service';
import { Empregado } from './../model/empregado';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { TabelaEmpregadosComponent } from '../tabela-empregados/tabela-empregados.component';
import { ModalComponent } from '../modal/modal.component';


@Component({
  selector: 'app-empregados',
  templateUrl: './empregados.component.html',
  styleUrls: ['./empregados.component.css']
})
export class EmpregadosComponent implements OnInit {

  linhasEmpregados: string[] = []
  listaEmpregados: Empregado[] = []
  empregado: Empregado
  @ViewChild(TabelaEmpregadosComponent) viewChildTabela: TabelaEmpregadosComponent

  @ViewChild(ModalComponent) viewChildModal: ModalComponent

  exibirInputFile: boolean = true
  textoDoInput: string = "Selecione um arquivo txt"

  textoCabecalhoModal: string = "Formato de arquivo inválido"
  textoCorpoModal: string = "O arquivo deverá estar no formato texto com extensão txt"
  ocultarBotaPrimary: boolean = true

  constructor(private router: Router, private empregadoService: EmpregadoService) { }

  ngOnInit() {
  }

  onChange(event) {
    let file = event.target.files[0]

    if(this.verificaExtensaoTxt(file.name)){
      this.uploadDocument(file)
    }else{
      this.viewChildModal.abrirModal()
      event.target.files[0] = null
    }

  }

  verificaExtensaoTxt(nome){
    debugger
    let vetor: string[] = nome.split('.')
    let extensao: string = vetor.pop()
    if(extensao.toLocaleLowerCase() == 'txt'){
      return true
    }else{
      return false
    }
  }

  readFile(file: File) {
    var reader = new FileReader();
    reader.onload = () => {
      console.log(reader.result);
    };
    reader.readAsText(file);
  }

  uploadDocument(file) {

    let fileReader = new FileReader();
    fileReader.onloadend = (e) => {

      this.linhasEmpregados = fileReader.result.toString().split('\n');
      this.gerarListaDeEmpregados()

    };

    fileReader.readAsText(file);
  }

  gerarListaDeEmpregados() {

    for (var line = 0; line < this.linhasEmpregados.length; line++) {
      let linhaEmpregado = this.linhasEmpregados[line];
      let vetorEmpregado = linhaEmpregado.split('||')
      let empregado = new Empregado()
      if (vetorEmpregado[0].length > 0) {
        empregado.Matricula = vetorEmpregado[0]
        empregado.Nome = vetorEmpregado[1]
        this.listaEmpregados.push(empregado)
      }
    }

    this.exibirInputFile = !this.exibirInputFile
    this.viewChildTabela.exibirSpinner()
    this.viewChildTabela.salvarEmpregados(this.listaEmpregados)
  }

}
