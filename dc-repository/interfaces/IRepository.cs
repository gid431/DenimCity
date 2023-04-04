namespace dc_repository.interfaces
{
    /// <summary>
    /// interfaccia del repository che eradita da IDisposable
    /// </summary>
    /// <typeparam name="T">oggetto di entità</typeparam>
    public interface IRepository<T> : IDisposable
    {
        /// <summary>
        /// query che interroga una collezione di dati
        /// </summary>
        /// <returns>oggetto Querable</returns>
        //dichiarazione vari metodi
        IQueryable<T> Query(); //interfaccia che ti permette di fare query
        /// <summary>
        /// funzione che aggiunge l'entità al db
        /// </summary>
        /// <param name="entity">oggetto di entità</param>
        /// <returns>entità creata</returns>
        Task<T> CreateAsync(T entity); //T è il tipo qualsiasi oggetto
        /// <summary>
        /// funzione che aggiorna l'entità al db
        /// </summary>
        /// <param name="entity">oggetto, istanza contenente entità</param>
        /// <returns>entità aggiornata</returns>
        Task<T> UpdateAsync(T entity);
        /// <summary>
        /// funzione che elimina l'entità in db
        /// </summary>
        /// <param name="entity">oggetto di entità</param>
        /// <returns>entità eliminata</returns>
        Task DeleteAsync(T entity);
        /// <summary>
        /// funzione che aggiorna una collezione di entità
        /// </summary>
        /// <param name="entities">collezione di entità</param>
        Task UpdateRangeAsync(IEnumerable<T> entities);
        /// <summary>
        /// collezione che aggiorna una collezione di entità
        /// </summary>
        /// <param name="entities">collezione di entità</param>
        Task CreateRangeAsync(IEnumerable<T> entities);
        /// <summary>
        /// funzione che elimina una collezione di entità
        /// </summary>
        /// <param name="entities">collezione di entità</param>
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
