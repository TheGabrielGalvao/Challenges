using Dominio.Entidades;
using Dominio.Interfaces;
using Repositorio.Contexto;

namespace Repositorio.Repositorios
{
    public class SolicitacaoRepositorio : BaseRepositorio<Solicitacao>, ISolicitacaoRepositorio
    {
        public SolicitacaoRepositorio(AvaliacaoContexto avaliacaoContexto) : base(avaliacaoContexto)
        {
        }
    }
}
