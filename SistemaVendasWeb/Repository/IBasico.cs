using System.Collections.Generic;

namespace SistemaVendasWeb.Repository
{
    public interface IBasico<T>
    {
        void Criar(T t);
        void Atualizar(T t);
        void Excluir(long id);
        ICollection<T> BuscarTodos();
        T BuscarPorId(long id);
    }
}
