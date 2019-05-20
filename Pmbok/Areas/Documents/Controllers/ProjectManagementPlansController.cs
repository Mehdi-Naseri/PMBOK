﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

using Pmbok.ServiceLayer.Interfaces;
using Pmbok.DataAccessLayer.IUnitOfWork;
using Pmbok.ViewModels.ViewModels;
using Pmbok.Controllers;

namespace Pmbok.Areas.Documents.Controllers
{
    public class ProjectManagementPlansController : ProjectDocumentsController
    {
        public ProjectManagementPlansController(IUnitOfWorkPmbok uow,
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