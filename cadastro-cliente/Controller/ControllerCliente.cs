using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CadastroCliente.BD;
using CadastroCliente.Contratos;
using CadastroCliente.DTO;
using CadastroCliente.Enumerator;
using RestSharp;
using RestSharp.Serialization.Json;

namespace CadastroCliente.Controller
{
    public class ControllerCliente
    {
        public IFormCliente FormClienteView { get; set; }

        RepositorioCliente acs = new RepositorioCliente();

        public ControllerCliente()
        {
            FormClienteView = new FormCliente();

            this.DelegarEventos();

            this.CarregarComponentes();


        }
        public static IList Listar(Type tipo)
        {
            ArrayList lista = new ArrayList();
            if (tipo != null)
            {
                Array enumValores = Enum.GetValues(tipo);
                foreach (Enum valor in enumValores)
                {
                    lista.Add(new KeyValuePair<Enum, string>(valor, ObterDescricao(valor)));
                }
            }

            return lista;
        }

        public static string ObterDescricao(Enum valor)
        {
            FieldInfo fieldInfo = valor.GetType().GetField(valor.ToString());

            DescriptionAttribute[] atributos = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return atributos.Length > 0 ? atributos[0].Description ?? "Nulo" : valor.ToString();
        }


        private void BuscaCep(object sender, EventArgs e)
        {

            string cep = this.FormClienteView.TxtCEP.Text;

            try
            {
                if (Regex.Match(cep, @"\d+").Value.Length == 8)
                {
                    RestClient restClient = new RestClient(string.Format("https://viacep.com.br/ws/{0}/json/", cep));
                    RestRequest restRequest = new RestRequest(Method.GET);

                    IRestResponse restResponse = restClient.Execute(restRequest);

                    if (restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        MessageBox.Show("Houve um problema com sua requisição: " + restResponse.Content, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    else
                    {
                        DadosRetornoDTO dadosRetorno = new JsonDeserializer().Deserialize<DadosRetornoDTO>(restResponse);

                        this.FormClienteView.TxtCEP.Text = dadosRetorno.Cep;
                        this.FormClienteView.TxtEndereco.Text = dadosRetorno.Logradouro;
                        this.FormClienteView.TxtBairro.Text = dadosRetorno.Bairro;
                        this.FormClienteView.TxtCidade.Text = dadosRetorno.Localidade;
                        this.FormClienteView.TxtEstado.Text = dadosRetorno.Uf;
                    }
                }
                else
                {
                    MessageBox.Show("CEP não encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar API: " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarComponentes()
        {
      

            this.FormClienteView.DgvDados.DataSource = acs.Listar();

            if (acs.Listar().Count > 0)
                this.FormClienteView.LblHelp.Text = "*** Clique duas vezes no item da grid para Alterar/Excluir.";


            this.FormClienteView.CbmSexo.DataSource = Listar(typeof(ESexo));
            this.FormClienteView.CbmSexo.DisplayMember = "Value";
            this.FormClienteView.CbmSexo.ValueMember = "Key";

        }

        private void DelegarEventos()
        {
            FormClienteView.BtnSalvar.Click += BtnSalvar_Click;
            FormClienteView.BtnExcluir.Click += BtnExcluir_Click;
            FormClienteView.BtnCancelar.Click += BtnCancelar_Click;
            this.FormClienteView.DgvDados.DoubleClick += DgvDados_DoubleClick;

            this.FormClienteView.TxtCEP.Validated += BuscaCep;

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            
            MapeiaObjetoParaTela(null);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            ClienteDTO modelo = MapeiaTelaParaObjeto();

            if (ValidaCampos())
            {
                if (acs.Excluir(modelo))
                    MessageBox.Show("Dados Apagados com Sucesso!");

                CarregarComponentes();
            }

            MapeiaObjetoParaTela(null);
        }

        private void DgvDados_DoubleClick(object sender, EventArgs e)
        {
            ClienteDTO cliente = this.FormClienteView.DgvDados.CurrentRow.DataBoundItem as ClienteDTO;

            this.MapeiaObjetoParaTela(cliente);

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                ClienteDTO modelo = MapeiaTelaParaObjeto();

                if (acs.Salvar(modelo))
                    MessageBox.Show("Dados Salvos com Sucesso!");

                CarregarComponentes();
            }

            MapeiaObjetoParaTela(null);


        }

        private ClienteDTO MapeiaTelaParaObjeto()
        {
            return new ClienteDTO
            {
                Bairro = this.FormClienteView.TxtBairro.Text,
                CEP = Convert.ToInt32(this.FormClienteView.TxtCEP.Text),
                Cidade = this.FormClienteView.TxtCidade.Text,
                Complemento = this.FormClienteView.TxtComplemento.Text,
                DataNascimento = this.FormClienteView.DtpDataNascimento.Value,
                Endereco = this.FormClienteView.TxtEndereco.Text,
                Estado = this.FormClienteView.TxtEstado.Text,
                Id = !string.IsNullOrEmpty(this.FormClienteView.TxtId.Text) ?  Convert.ToInt32(this.FormClienteView.TxtId.Text) : 0,
                Nome = this.FormClienteView.TxtNome.Text,
                Numero = this.FormClienteView.TxtNumero.Text,
                Sexo = (ESexo)this.FormClienteView.CbmSexo.SelectedValue
            };

        }

        private void MapeiaObjetoParaTela(ClienteDTO cliente)
        {

            if (cliente is null)
            {
                this.FormClienteView.TxtId.Text = string.Empty;
                this.FormClienteView.TxtNome.Text = string.Empty;
                this.FormClienteView.DtpDataNascimento.Value = DateTime.Now;
                this.FormClienteView.CbmSexo.SelectedValue = ESexo.None;
                this.FormClienteView.TxtCEP.Text = string.Empty;
                this.FormClienteView.TxtEndereco.Text = string.Empty;
                this.FormClienteView.TxtNumero.Text = string.Empty;
                this.FormClienteView.TxtComplemento.Text = string.Empty;
                this.FormClienteView.TxtBairro.Text = string.Empty;
                this.FormClienteView.TxtCidade.Text = string.Empty;
                this.FormClienteView.TxtEstado.Text = string.Empty;
                
                
                
                
            }
            else
            {
                this.FormClienteView.TxtId.Text = cliente.Id.ToString();
                this.FormClienteView.TxtNome.Text = cliente.Nome;
                this.FormClienteView.DtpDataNascimento.Value = cliente.DataNascimento;
                this.FormClienteView.CbmSexo.SelectedValue = cliente.Sexo;
                this.FormClienteView.TxtCEP.Text = cliente.CEP.ToString();
                this.FormClienteView.TxtEndereco.Text = cliente.Endereco;
                this.FormClienteView.TxtNumero.Text = cliente.Numero;
                this.FormClienteView.TxtComplemento.Text = cliente.Complemento;
                this.FormClienteView.TxtBairro.Text = cliente.Bairro;
                this.FormClienteView.TxtCidade.Text = cliente.Cidade;
                this.FormClienteView.TxtEstado.Text = cliente.Estado;
            }
        }

        private bool ValidaCampos()
        {
            StringBuilder mensagem = new StringBuilder();

            if (string.IsNullOrEmpty(this.FormClienteView.TxtNome.Text))
                mensagem.Append("O campo NOME é obrigatório! \n");

            if (string.IsNullOrEmpty(this.FormClienteView.DtpDataNascimento.Value.ToString()))
                mensagem.Append("O campo DATA DE NASCIMENTO é obrigatório! \n");

            if (string.IsNullOrEmpty(this.FormClienteView.CbmSexo.SelectedValue?.ToString()))
                mensagem.Append("O campo SEXO é obrigatório! \n");



            if (string.IsNullOrEmpty(mensagem.ToString()))
                return true;

            else
            {
                MessageBox.Show(mensagem.ToString());
                return false;
            }

        }
    }
}
