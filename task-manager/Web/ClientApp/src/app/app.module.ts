import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SolicitacaoComponent } from './solicitacao/solicitacao.component';
import { SolicitacaoService } from './solicitacao/solicitacao.service';
import { SolicitacaoFormComponent } from './solicitacao/solicitacao-form/solicitacao-form.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SolicitacaoComponent,
    SolicitacaoFormComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: SolicitacaoComponent, pathMatch: 'full' },
      { path: 'solicitacao', component: SolicitacaoComponent },
      { path: 'solicitacao-incluir', component: SolicitacaoFormComponent },
      { path: 'solicitacao-editar/:id', component: SolicitacaoFormComponent },
    ])
  ],
  providers: [SolicitacaoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
