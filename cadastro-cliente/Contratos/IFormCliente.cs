using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroCliente.Contratos
{
    public interface IFormCliente
    {
        TextBox TxtId { get; }
        TextBox TxtNome { get; }
        DateTimePicker DtpDataNascimento { get; }
        ComboBox CbmSexo { get; }
        MaskedTextBox TxtCEP { get; }
        TextBox TxtEndereco { get; }
        TextBox TxtNumero { get; }
        TextBox TxtComplemento { get; }
        TextBox TxtBairro { get; }
        TextBox TxtEstado { get; }
        TextBox TxtCidade { get; }
        Form Formulario { get; }
        Button BtnSalvar { get; }
        Button BtnExcluir { get; }
        Button BtnCancelar { get; }

        Label LblHelp { get; }
        DataGridView DgvDados{ get; }
    }
}