using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pmbok.ServiceLayer.Interfaces;
using Pmbok.DataAccessLayer.IUnitOfWork;
using Pmbok.DomainClasses.Models;
using Pmbok.ViewModels.ViewModels;

using Pmbok.Controllers;

namespace Pmbok.Areas.Documents.Controllers
{
    public class ExternalDocumentsController : ProjectDocumentsController
    {
        public ExternalDocumentsController(IUnitOfWorkPmbok uow,
        IProjectDocumentValueService projectDocumentValueService,
        IProjectDocumentFileService projectDocumentFileService,
        IProjectDocumentValueFilesService projectDocumentValueFileService,
        IProjectDocumentFileDeletedService projectDocumentFileDeletedServic)
            : base(uow, projectDocumentValueService, projectDocumentFileService,
                 projectDocumentValueFileService, projectDocumentFileDeletedServic)
        {
        }
    }
}