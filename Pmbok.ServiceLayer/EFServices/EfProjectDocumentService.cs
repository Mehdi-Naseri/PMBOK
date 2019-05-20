using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pmbok.DomainClasses.Models;
using Pmbok.DataAccessLayer.IUnitOfWork;
using Pmbok.ServiceLayer.Interfaces;

namespace Pmbok.ServiceLayer.EFServices
{
    public class EfProjectDocumentService : _EfGenericService<ProjectDocument>, IProjectDocumentService
    {
        public EfProjectDocumentService(IUnitOfWorkPmbok uow)
            : base(uow)
        {

        }

        public bool Exist(string Name)
        {
            return _tEntities.Any(r => r.DocumentName == Name);
        }
    }
}
