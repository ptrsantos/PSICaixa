import { Empregado } from './../model/empregado';
import { Component, OnInit, ViewChild, Input, ChangeDetectorRef, TemplateRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router, ActivatedRoute } from '@angular/router';
import { MatExpansionPanel } from '@angular/material/expansion';
import { DominioService } from '../dominio.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-tabela-empregados',
  templateUrl: './tabela-empregados.component.html',
  styleUrls: ['./tabela-empregados.component.css'],
  viewProviders: [MatExpansionPanel]
})
export class TabelaEmpregadosComponent implements OnInit {

  //@Input() listaDeEmpregadosDeInput: Empregado[]
  listaDeEmpregados: Empregado[]
  panelOpenState = false;
  displayedColumns: string[] = ['Id', 'Matricula', 'Nome', 'Acao'];
  dataSource: any = new MatTableDataSource<Empregado>();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  tamanhoDaLista: number
  paginaAtual: number = 1
  tamanhoDaPaginaAtual: number

  ocultarTabela: boolean = true
  ocultarBotoes: boolean = false

  @ViewChild(ModalComponent) viewChildModal: ModalComponent

  textoCabecalhoModal: string = "Confirmar Exclusão"
  textoCorpoModal: string = "Você tem certeza que deseja excluir o empregado? Essa operação é irreversível."
  ocultarBotaPrimary: boolean = false
  idEmpregadoSelecionado: any

  constructor(private changeDetectorRefs: ChangeDetectorRef,
    private dominioService: DominioService,
    private spinnerService: NgxSpinnerService,
  ) { }

  ngOnInit() {
    this.incializarTebela()
  }

  salvarEmpregados(empregados: Empregado[]) {
    this.tamanhoDaLista = empregados.length
    this.dominioService.salvarEmpregados(empregados).subscribe(response => {
      this.obterDadosIniciais()
    })
  }

  obterDadosIniciais() {

    this.dominioService.obterEmpregados('1', '5').subscribe(response => {

      this.tamanhoDaPaginaAtual = 5

      this.listaDeEmpregados = []
      this.listaDeEmpregados = response;
      this.listaDeEmpregados.length = this.tamanhoDaLista;
      this.refresh()
      this.ocultarTabela = false
      this.ocultarSpinner()

    })

  }

  obterProximosDados() {

    this.dominioService.obterEmpregados(this.paginaAtual.toString(), this.tamanhoDaPaginaAtual.toString()).subscribe(response => {

      let indice = (this.paginaAtual - 1) * this.tamanhoDaPaginaAtual
      this.listaDeEmpregados = []
      this.listaDeEmpregados.length = this.tamanhoDaLista
      let retorno = response
      this.listaDeEmpregados.splice(indice, retorno.length, ...retorno)
      this.refresh()
      this.spinnerService.hide()

    })

  }

  pageChanged(event) {

    this.spinnerService.show()

    let pagina = event.pageIndex;
    let tamanho = event.pageSize;
    let paginaAnterior = event.previousPageIndex;
    //let tamanhoAnterior = tamanho * pagina;

    this.paginaAtual = pagina - paginaAnterior

    if (pagina > paginaAnterior) {
      this.paginaAtual = pagina + 1
    } else {
      this.paginaAtual = pagina + 1
    }

    this.tamanhoDaPaginaAtual = event.pageSize

    this.obterProximosDados();
  }

  refresh() {
    this.incializarTebela()
    this.changeDetectorRefs.detectChanges();
  }

  incializarTebela() {
    this.panelOpenState = false;
    this.displayedColumns = ['Id', 'Matricula', 'Nome', 'Acao'];
    this.dataSource = new MatTableDataSource<Empregado>(this.listaDeEmpregados);
    this.dataSource.paginator = this.paginator;
  }


  exibirSpinner() {
    this.spinnerService.show()
  }

  ocultarSpinner() {
    this.spinnerService.hide()
  }

  acaoExcluir(row) {
    console.log("Id = +", row.Id)
    this.idEmpregadoSelecionado = row.Id.toString()
    this.viewChildModal.abrirModal()
  }

  confirmarExclusaoEmpregado() {

    this.spinnerService.show()
    this.dominioService.ExcluirEmpregado(this.idEmpregadoSelecionado, this.paginaAtual.toString(), this.tamanhoDaPaginaAtual.toString()).subscribe(response => {
      debugger
      this.tamanhoDaLista = this.tamanhoDaLista - 1
      let indice = (this.paginaAtual - 1) * this.tamanhoDaPaginaAtual
      this.listaDeEmpregados = []
      this.listaDeEmpregados.length = this.tamanhoDaLista
      let retorno = response
      this.listaDeEmpregados.splice(indice, retorno.length, ...retorno)
      this.refresh()
      //this.ocultarBotoes = !this.ocultarBotoes
      this.spinnerService.hide()
    })
  }

}
