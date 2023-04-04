using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_service.interfaces
{
#nullable disable
    public interface IService<T, K>
    {
        //numero di pagine da mostrare
        //quanti record deve prendere per pagina 
        List<T> Pagination(int numeroPagine, int recordPagine);
        Task<T> GetById(K id); //k: tipo generico

        //metodi di create e update perchè service dovrà chiamare repository
        Task<T> CreateAsync(T entity); //dato che è asincronico, metti Task
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(K id);
        Task CreateRangeAsync(List<T> entities);
        Task UpdateRangeAsync(List<T> entities);
        Task DeleteRangeAsync(List<T> entities);

    }
}
