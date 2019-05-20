﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pmbok.ServiceLayer.Interfaces;
using Pmbok.DataAccessLayer.IUnitOfWork;
using Pmbok.ViewModels.ViewModels;
using Pmbok.Controllers;

namespace Pmbok.Areas.ProjectIntegrationManagement.Controllers
{
    public class DirectandManageProjectWorkController : ProjectProcessesBaseController
    {
        public DirectandManageProjectWorkController(IUnitOfWorkPmbok uow,
IProjectDocumentValueService projectDocumentValueService,
IProjectDocumentFileService projectDocumentFileService,
IProjectDocumentValueFilesService projectDocumentValueFileService)
            :base(uow, projectDocumentValueService,projectDocumentFileService,
                 projectDocumentValueFileService)
        {
        }
    }
}