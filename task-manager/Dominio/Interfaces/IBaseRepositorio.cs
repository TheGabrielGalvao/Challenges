using System;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
    public interface IBaseRepositorio<TEntity> : IDisposable where TEntity : class
    {
        void Salvar(TEntity entity);

        TEntity ObterPorId(int id);

        IEnumerable<TEntity> ObterTodos();

        void Excluir(TEntity entity);
    }
}
