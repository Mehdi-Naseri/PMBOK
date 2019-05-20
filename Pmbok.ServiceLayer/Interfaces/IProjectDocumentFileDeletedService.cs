using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pmbok.DomainClasses.Models;
using Pmbok.ViewModels.ViewModels;

using System.Web;

namespace Pmbok.ServiceLayer.Interfaces
{
    public interface IProjectDocumentFileDeletedService
    {
        IEnumerable<ProjectDocumentFileDeleted> GetDeletedFiles(string projectName, string projectDocumentName);

        ProjectDocumentFileDeleted DownloadDocumentFile(int id);
    }
}
