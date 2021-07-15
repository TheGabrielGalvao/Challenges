import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ISolicitacao } from './solicitacao';
import { Observable } from 'rxjs/Observable';

@Injectable({
  providedIn: 'root'
})
export class SolicitacaoService {

  private apiURL = this.baseUrl + "api/solicitacao";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  getSolicitacoes() : Observable<ISolicitacao[]>{
       return this.http.get<ISolicitacao[]>(this.apiURL);
  }

  getSolicitacao(idSolicitacao : string): Observable<ISolicitacao> {
    return this.http.get<ISolicitacao>(this.apiURL + '/' + idSolicitacao);
  }

  createSolicitacao(solicitacao : ISolicitacao) : Observable<ISolicitacao> {
    return this.http.post<ISolicitacao>(this.apiURL, solicitacao);
  }

  updateSolicitacao(solicitacao : ISolicitacao) : Observable<ISolicitacao> {
    return this.http.put<ISolicitacao>(this.apiURL + '/' + solicitacao.id.toString(), solicitacao);
  }

  deleteSolicitacao(idSolicitacao: string): Observable<ISolicitacao> {
    return this.http.delete<ISolicitacao>(this.apiURL + '/' + idSolicitacao.toString());
  }

}
