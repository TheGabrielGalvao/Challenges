import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SolicitacaoService } from '../solicitacao.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ISolicitacao } from '../solicitacao';


@Component({
  selector: 'app-solicitacao-form',
  templateUrl: './solicitacao-form.component.html',
  styleUrls: ['./solicitacao-form.component.css']
})
export class SolicitacaoFormComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private solicitacaoService: SolicitacaoService,
    private router: Router, private activatedRoute: ActivatedRoute) { }

  formGroup: FormGroup;
  modoEdicao: boolean = false;
  idSolicitacao: number;
 


  ngOnInit() {
    this.formGroup = this.fb.group({
      numero: '',
      descricao: '',
      previsao: '',
      responsavel: '',
      status: ''
    });

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicao = true;
      this.idSolicitacao = params["id"];
      

      this.solicitacaoService.getSolicitacao(this.idSolicitacao.toString())
        .subscribe(solicitacaoWS => this.carregarFormulario(solicitacaoWS),
          error => console.error(error));
    });

  }


  carregarFormulario(solicitacao: ISolicitacao) {
    this.formGroup.patchValue({
      numero: solicitacao.numero,
      descricao: solicitacao.descricao,
      previsao: solicitacao.previsao,
      responsavel: solicitacao.responsavel,
      status: solicitacao.status
    });
  }


  save() {
    let solicitacao: ISolicitacao = Object.assign({}, this.formGroup.value);

    if (this.modoEdicao) {
      solicitacao.id = this.idSolicitacao;
      this.solicitacaoService.updateSolicitacao(solicitacao)
        .subscribe(solicitacao => this.OnSaveSuccess()),
        error => console.error(error);
    }
    else {
      this.solicitacaoService.createSolicitacao(solicitacao)
        .subscribe(solicitacao => this.OnSaveSuccess()),
        error => console.error(error);
    }

  }

  OnSaveSuccess() {
    this.router.navigate(["/solicitacao"])
  }

}
