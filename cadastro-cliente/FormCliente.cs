using CadastroCliente.BD;
using CadastroCliente.Contratos;
using CadastroCliente.Controller;
using CadastroCliente.DTO;
using CadastroCliente.Enumerator;
using MySql.Data.MySqlClient;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CadastroCliente
{
    public partial class FormCliente : Form, IFormCliente
    {
       
        ClienteDTO dto = new ClienteDTO();
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;

        string strSQL;

        public Form Formulario { get { return this; } }


        public TextBox TxtId { get { return this.txtId; } }
        public TextBox TxtNome { get { return this.txtNome; } }
        public DateTimePicker DtpDataNascimento { get { return this.dtpDataNascimento; } }
        public ComboBox CbmSexo { get { return this.cbmSexo; } }
        public MaskedTextBox TxtCEP { get { return this.txtCEP; } }
        public TextBox TxtEndereco { get { return this.txtEndereco; } }
        public TextBox TxtNumero { get { return this.txtNumero; } }
        public TextBox TxtComplemento { get { return this.txtComplemento; } }
        public TextBox TxtBairro { get { return this.txtBairro; } }
        public TextBox TxtEstado { get { return this.txtEstado; } }
        public TextBox TxtCidade { get { return this.txtCidade; } }

        public Button BtnSalvar { get { return this.btnSalvar; } }

        public Button BtnExcluir { get { return this.btnExcluir; } }

        public Button BtnCancelar { get { return this.btnCancelar; } }

        public DataGridView DgvDados { get { return this.dgvDados; } }

        public Label LblHelp { get { return this.lblHelp; } }

        public FormCliente()
        {
            InitializeComponent();

        }

    }
}

