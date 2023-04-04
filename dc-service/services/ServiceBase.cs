using dc_repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_service.services
{
#nullable disable
    public class ServiceBase<T>
    {
        protected readonly IRepository<T> repository;

        //creato la dipendenza col nostro repository
        public ServiceBase(IRepository<T> repository) => this.repository = repository;
        
    }
}
