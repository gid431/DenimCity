using dc_repository.Context;
using dc_repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_repository.repositories
{
    public abstract class Repository<T> : IRepository<T>
        //astratta: non sei obbligato a sottoscrivere le funzioni da cui vai ad ereditare
        //la classe astratta non implementa i metodi ed obbligherà però le classi che la erediteranno ad implementarli
        //la classe astratta ha la funzione di scrivere metodi e proprietà, di essere ereditata, ma mai di essere chiamata con un oggetto

    {
        private readonly DcContext Context;

        //costruttore
        public Repository(DcContext context) => this.Context = context;

        public abstract Task CreateRangeAsync(IEnumerable<T> entities);

        public abstract Task<T> CreateAsync(T entity);

        public abstract Task DeleteAsync(T entity);

        public abstract Task DeleteRangeAsync(IEnumerable<T> entities);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing) Context?.Dispose();
        }

        public abstract IQueryable<T> Query();

        public abstract Task<T> UpdateAsync(T entity);

        public abstract Task UpdateRangeAsync(IEnumerable<T> entities);

        
    }
}
