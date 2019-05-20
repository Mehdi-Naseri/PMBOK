using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pmbok.ServiceLayer.Interfaces;
using Pmbok.DataAccessLayer.IUnitOfWork;
using Pmbok.ViewModels.ViewModels;
using Pmbok.Controllers;

namespace Pmbok.Areas.ProjectProcurementManagement.Controllers
{
    public class PlanProcurementManagementController : ProjectProcessesBaseController
    {
        public PlanProcurementManagementController(IUnitOfWorkPmbok uow,
IProjectDocumentValueService projectDocumentValueService,
IProjectDocumentFileService projectDocumentFileService,
IProjectDocumentValueFilesService projectDocumentValueFileService)
            :base(uow, projectDocumentValueService,projectDocumentFileService,
                 projectDocumentValueFileService)
        {
        }
    }
}