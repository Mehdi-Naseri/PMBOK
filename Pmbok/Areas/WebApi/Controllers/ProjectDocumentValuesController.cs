using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Pmbok.DataAccessLayer.IUnitOfWork;
using Pmbok.DomainClasses.Models;
using Pmbok.ModelsOld;
using Pmbok.ServiceLayer.Interfaces;

namespace Pmbok.Areas.WebApi.Controllers
{
    public class ProjectDocumentValuesController : ApiController
    {
        private IUnitOfWorkPmbok _uow;
        private IProjectDocumentValueService _projectDocumentValueService;

        public ProjectDocumentValuesController(IUnitOfWorkPmbok uow,
            IProjectDocumentValueService projectDocumentValueService)
        {
            _uow = uow;
            _projectDocumentValueService = projectDocumentValueService;
        }

        // GET: api/ProjectDocumentValues
        public IHttpActionResult Get()
        {
            return Ok("OK Test");
            //return CreatedAtRoute("DefaultApi", new { id = projectDocumentValue.Id }, projectDocumentValue);
        }

        // GET: api/ProjectDocumentValues
        public IHttpActionResult GetProjectDocumentValue()
        {
            return Ok("OK Test");
            //return CreatedAtRoute("DefaultApi", new { id = projectDocumentValue.Id }, projectDocumentValue);
        }

        // POST: api/ProjectDocumentValues
        //[ResponseType(typeof(ProjectDocumentValue))]
        public IHttpActionResult PostProjectDocumentValue(string projectName, string projectDocumentName, string newProjectDocumentValue)
        {
            _projectDocumentValueService.AddValue(projectName, projectDocumentName, newProjectDocumentValue, User.Identity.Name);
            _uow.SaveChanges();
            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = projectDocumentValue.Id }, projectDocumentValue);
        }



        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            base.Dispose(disposing);
        }

    }
}