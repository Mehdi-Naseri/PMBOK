using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Pmbok.DomainClasses.Models;
using Pmbok.DataAccessLayer.IUnitOfWork;
using Pmbok.ServiceLayer.Interfaces;
using Identity.ServiceLayer.EFServices;
using Pmbok.ViewModels.ViewModels;

using System.Web;

namespace Pmbok.ServiceLayer.EFServices
{
    public class EfProjectDocumentFileDeletedService : IProjectDocumentFileDeletedService
    {
        protected IUnitOfWorkPmbok _uow;
        protected IDbSet<ProjectDocumentFileDeleted> _pdeletedDbSet;

        public EfProjectDocumentFileDeletedService(IUnitOfWorkPmbok uow)
        {
            _uow = uow;
            _pdeletedDbSet = _uow.Set<ProjectDocumentFileDeleted>();
        }

        public IEnumerable<ProjectDocumentFileDeleted> GetDeletedFiles(string projectName, string projectDocumentName)
        {
            return _pdeletedDbSet.Where(a => a.Project.Name == projectName && a.ProjectDocument.DocumentName == projectDocumentName);
        }

        public ProjectDocumentFileDeleted DownloadDocumentFile(int id)
        {
            return _pdeletedDbSet.First(r => r.Id == id);
        }
    }
}
