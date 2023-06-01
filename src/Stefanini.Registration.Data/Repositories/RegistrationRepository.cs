using Stefanini.Registration.Data.Repositories.Abstractions;
using Stefanini.Registration.Domain.Dtos;
using Stefanini.Registration.Domain.Entities;
using Stefanini.Registration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Registration.Data.Repositories
{
    public class RegistrationRepository : RepositoryBase<Domain.Entities.Registration>, IRegistrationRepository
    {
        public RegistrationRepository(StefaniniRegistrationContext dataContext) : base(dataContext)
        {
        }

        
    }
}
