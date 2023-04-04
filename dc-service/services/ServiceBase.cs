using dc_repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_service.services
{
#nullable disable
    /// <summary>
    /// classe super del service che implementa la depence
    /// </summary>
    /// <typeparam name="T">oggetto entità</typeparam>
    public class ServiceBase<T>
    {
        /// <summary>
        /// interfaccia IRepository
        /// </summary>
        protected readonly IRepository<T> repository;

        /// <summary>
        /// costruttore della classe super che prende in input l'interfaccia repository
        /// creata la dipendenza col nostro repository
        /// </summary>
        /// <param name="repository"><see cref="IRepository{T}"/></param>
        public ServiceBase(IRepository<T> repository) => this.repository = repository;
        
    }
}
