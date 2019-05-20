using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pmbok.DomainClasses.Models;
using Pmbok.ViewModels.ViewModels;

namespace Pmbok.ServiceLayer.Interfaces
{
    public interface IProjectDocumentValueFilesService 
    {
        ProjectDocumentLatestValueFilesViewModel GetLatestValueFiles(string projectName);
    }
}
