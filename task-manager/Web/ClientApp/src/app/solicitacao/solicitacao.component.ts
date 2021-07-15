import { Component, OnInit } from '@angular/core';
import { ISolicitacao } from './solicitacao';
import {SolicitacaoService } from './solicitacao.service';


@Component({
  selector: 'app-solicitacao',
  templateUrl: './solicitacao.component.html',
  styleUrls: ['./solicitacao.component.css']
})
export class SolicitacaoComponent implements OnInit {

   solicitacoes : ISolicitacao[];


  constructor( private solicitacaoService : SolicitacaoService) { }

  ngOnInit() {
    this.carregarDados();
  }

  delete(solicitacao: ISolicitacao) {
    this.solicitacaoService.deleteSolicitacao(solicitacao.id.toString())
      .subscribe(solicitacao => this.carregarDados()),
      error => console.error(error);
  }

  carregarDados() {
    this.solicitacaoService.getSolicitacoes()
      .subscribe(solicitacaoWebAPI => this.solicitacoes = solicitacaoWebAPI),
      error => console.error(error);
  }

}
