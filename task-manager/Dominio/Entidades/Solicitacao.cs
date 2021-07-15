using QuickBuy.Dominio.Entidades;
using QuickBuy.Dominio.Enumerados;
using System;

namespace Dominio.Entidades
{
    public class Solicitacao : Entidade
    {

        public int Id { get; set; }

        public int Numero { get; set; }

        public string Descricao { get; set; }

        public DateTime Previsao { get; set; }

        public string Responsavel { get; set; }

        public string Status { get; set; }


        public override void Validate()
        {
            LimparMensagensValidacao();

            if (string.IsNullOrEmpty(Numero.ToString()))
                AdicionarMensagem("O campo Número é Obrigatório");
        }
    }
}
