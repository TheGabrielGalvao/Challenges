using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Config;

namespace Repositorio.Contexto
{
    public class AvaliacaoContexto : DbContext
    {
        public DbSet<Solicitacao> Solicitacoes { get; set; }

        public AvaliacaoContexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SolicitacaoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
