using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pmbok.DomainClasses.Models;
using Pmbok.ViewModels.ViewModels;

namespace Pmbok.ServiceLayer.Interfaces
{
    public interface IProjectDocumentValueService : _IGenericService<ProjectDocumentValue>
    {
        bool Exist(string projectName, string projectDocumentName, string newProjectDocumentValue);

        void AddValue(string projectName, string projectDocumentName, string newProjectDocumentValue,string userName);

        ProjectDocumentLatestValueViewModel GetLatestValues(string projectName);

        IEnumerable<ProjectDocumentValue> GetChangedValues(string projectName, string projectDocumentName);
    }
}
