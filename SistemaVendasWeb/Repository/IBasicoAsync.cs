using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Repository
{
    public interface IBasicoAsync<T>
    {
        Task CriarAsync(T t);
        Task AtualizarAsync(T t);
        Task ExcluirAsync(long id);
        Task<List<T>> BuscarTodosAsync();
        Task<T> BuscarPorIdAsync(long id);
    }
}
