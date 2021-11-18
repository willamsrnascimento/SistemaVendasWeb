using SistemaVendasWeb.Models;
using SistemaVendasWeb.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Repository
{
    public interface IFuncionarioRepository : IBasicoAsync<Funcionario>
    {
        Task<List<Funcionario>> BuscarPorFiltroAsync(Filtros sFiltro, string txtProcurar);
    }
}
