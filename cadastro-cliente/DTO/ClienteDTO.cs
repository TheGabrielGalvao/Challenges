using CadastroCliente.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.DTO
{
    public class ClienteDTO
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string Nome { get; set; }

        [DisplayName("Data de Nascimento"), Description("Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        public ESexo Sexo { get; set; }
        public int CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
