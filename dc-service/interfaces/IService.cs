using dc_repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_service.interfaces
{
#nullable disable
    /// <summary>
    /// interfaccia che gestisce la logica business
    /// </summary>
    /// <typeparam name="T">oggetto entità</typeparam>
    /// <typeparam name="K">chiave primaria gell'oggetto entità</typeparam>
    public interface IService<T, K>
    {
        /// <summary>
        /// ritorna una collezione ordinata e impaginata dell'oggetto entità
        /// metodi di create e update perchè service dovrà chiamare repository
        /// </summary>
        /// <param name="numeroPagine">identifica il numero di pagine da mostrare di tipo intero</param>
        /// <param name="filtro">identifica filtro di ricerca di tipo string</param>
        /// <param name="recordPagine">identifica quanti record deve prendere per pagina</param>
        /// <returns>ritorna una collezione impaginata di oggetti</returns>
        Task<List<T>> Pagination(int numeroPagine, string filtro, int recordPagine = 10);
        /// <summary>
        /// recupera l'oggetto entità
        /// </summary>
        /// <param name="id">chiave primaria dell'entità</param>
        /// <returns>oggetto dell'entità</returns>
        Task<List<T>> GetAll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(K id);
        /// <summary>
        /// 
        /// k: tipo generico
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T entity); //dato che è asincronico, metti Task
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(K id);
        Task CreateRangeAsync(List<T> entities);
        Task UpdateRangeAsync(List<T> entities);
        Task DeleteRangeAsync(List<T> entities);

    }
}
