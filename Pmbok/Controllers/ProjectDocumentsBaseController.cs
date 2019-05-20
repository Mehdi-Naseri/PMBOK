using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pmbok.ServiceLayer.Interfaces;
using Pmbok.DataAccessLayer.IUnitOfWork;
using Pmbok.DomainClasses.Models;
using Pmbok.ViewModels.ViewModels;
using Pmbok.Extentions.MapperConfigure.Extention;

namespace Pmbok.Controllers
{
    public class ProjectDocumentsBaseController : ProjectProcessesBaseController
    {
        //IProjectDocumentFileDeletedService _projectDocumentFileDeletedService;
        public ProjectDocumentsBaseController(IUnitOfWorkPmbok uow,
              IProjectDocumentValueService projectDocumentValueService,
              IProjectDocumentFileService projectDocumentFileService,
              IProjectDocumentValueFilesService projectDocumentValueFileService,
              IProjectDocumentFileDeletedService projectDocumentFileDeletedServic
              )

            : base(uow, projectDocumentValueService, projectDocumentFileService,
                 projectDocumentValueFileService, projectDocumentFileDeletedServic)
        {
        }

        //public PartialViewResult GetChangedValues(string projectName, string projectDocumentName)
        //{
        //    IEnumerable<ProjectDocumentValueViewModel> model = _projectDocumentValueService.GetChangedValues(projectName, projectDocumentName).MapModelToViewModel();
        //    return PartialView("_ChangedValues", model);
        //}

        public ActionResult GetChangedValues(string projectName, string projectDocumentName)
        {
           IEnumerable<ProjectDocumentValueViewModel> model = _projectDocumentValueService.GetChangedValues(projectName, projectDocumentName).MapModelToViewModel();
            return PartialView("~/Areas/Documents/Views/Shared/_ChangedValues.cshtml", model);
        }

        public PartialViewResult GetDeletedFiles(string projectName, string projectDocumentName)
        {
            IEnumerable<ProjectDocumentFileDeletedViewModel> model = _projectDocumentFileDeletedService.GetDeletedFiles(projectName, projectDocumentName).MapModelToViewModel();
            return PartialView("~/Areas/Documents/Views/Shared/_DeletedFiles.cshtml", model);
        }

        public FileContentResult DownloadDocumentFileDeleted(int id)
        {
            ProjectDocumentFileDeletedViewModel projectDocumentFileDeletedViewModel = _projectDocumentFileDeletedService.DownloadDocumentFile(id).MapModelToViewModel();
            byte[] fileData = projectDocumentFileDeletedViewModel.File;
            string fileName = projectDocumentFileDeletedViewModel.FileName;
            return File(fileData, "Text", fileName);
        }
    }
}