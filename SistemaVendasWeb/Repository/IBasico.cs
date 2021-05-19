using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Repository
{
    interface IBasico <T>
    {
        long Id { get; }
        void Incluir();
        T Alterar(T t);
        void Excluir();
        List<T> Listar();
        T SelecionarPorIr(int id);
    }
}
