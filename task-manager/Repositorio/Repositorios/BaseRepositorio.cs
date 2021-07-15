using System.Collections.Generic;
using System.Linq;
using Dominio.Interfaces;
using Repositorio.Contexto;

namespace Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly AvaliacaoContexto AvaliacaoContexto;

        public BaseRepositorio(AvaliacaoContexto avaliacaoContexto)
        {
            AvaliacaoContexto = avaliacaoContexto;
        }

        

        public TEntity ObterPorId(int id)
        {
            return AvaliacaoContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return AvaliacaoContexto.Set<TEntity>().ToList();
        }

        public void Salvar(TEntity entity)
        {
            AvaliacaoContexto.Set<TEntity>().Update(entity);
            AvaliacaoContexto.SaveChanges();
        }

        public void Excluir(TEntity entity)
        {
            AvaliacaoContexto.Remove(entity);
            AvaliacaoContexto.SaveChanges();
        }

        public void Dispose()
        {
            AvaliacaoContexto.Dispose();
        }
    }
}
