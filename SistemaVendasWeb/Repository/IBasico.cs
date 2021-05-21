using System.Collections.Generic;

namespace SistemaVendasWeb.Repository
{
    interface IBasico <T>
    {
        long Id { get; }
        void Incluir();
        T Alterar();
        void Excluir();
        ICollection<T> Listar();
        T SelecionarPorIr(int id);
    }
}
