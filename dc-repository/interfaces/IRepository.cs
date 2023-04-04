namespace dc_repository.interfaces
{
    public interface IRepository<T> : IDisposable
    {
        //dichiarazione vari metodi
        IQueryable<T> Query(); //interfaccia che ti permette di fare query
        Task<T> CreateAsync(T entity); //T è il tipo qualsiasi oggetto
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task CreateRangeAsync(IEnumerable<T> entities);
        Task DeleteRangeAsync(IEnumerable<T> entities);


    }
}
