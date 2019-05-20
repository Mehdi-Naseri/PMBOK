using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pmbok.DomainClasses.Models;

namespace Pmbok.ServiceLayer.Interfaces
{
    public interface IProjectService : _IGenericService<Project>
    {
        bool Exist(string Name);
    }
}
