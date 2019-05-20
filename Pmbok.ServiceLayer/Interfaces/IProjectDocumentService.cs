using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pmbok.DomainClasses.Models;

namespace Pmbok.ServiceLayer.Interfaces
{
    public interface IProjectDocumentService : _IGenericService<ProjectDocument>
    {
        bool Exist(string Name);
    }
}
