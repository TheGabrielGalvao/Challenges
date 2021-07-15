using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Enumerator
{
    public enum ESexo
    {
        [Description("Indefinido")]
        None = 0,

        [Description("Masculino")]
        Masculino = 1,

        [Description("Feminino")]
        Feminino = 2
    }
}
