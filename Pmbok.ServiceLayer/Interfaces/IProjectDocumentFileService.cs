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
    public interface IProjectDocumentFileService : _IGenericService<ProjectDocumentFile>
    {
        void UploadDocumentFile(string projectName, string projectDocumentName, HttpPostedFileBase file, string username);
        void UploadDocumentFiles(string projectName, string projectDocumentName,IEnumerable<HttpPostedFileBase> files, string username);
        void DeleteDocumentFile(string projectName, string projectDocumentName, string file, string username);

        void DeleteDocumentFileById(int id);
        ProjectDocumentFile DownloadDocumentFile(int id);

        bool Exist(int id);
    }
}
