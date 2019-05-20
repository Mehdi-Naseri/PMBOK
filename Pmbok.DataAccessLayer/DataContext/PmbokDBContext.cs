using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pmbok.DataAccessLayer.IUnitOfWork;
using Microsoft.AspNet.Identity.EntityFramework;
using Identity.Models.Models;
using System.Data.Entity;
using Pmbok.DomainClasses.Models;

namespace Pmbok.DataAccessLayer.DataContext
{
    public class PmbokDBContext : IdentityDbContext<ApplicationUser>  , IUnitOfWorkPmbok
    {
        public PmbokDBContext()
            : base("name=PmbokConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //جهت ذخیره داده های فارسی در پایگاه داده اضافه شده است.
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            //جهت ذخیره جداول در شمای "پورتال" اضافه شده است.
            //modelBuilder.HasDefaultSchema("Pmbok");

            //جهت ذخیره جداول ایدنتیتی در شمای "آیدنتیتی" اضافه شده است.
            modelBuilder.HasDefaultSchema("Identity");
            base.OnModelCreating(modelBuilder);
        }

        public static PmbokDBContext Create()
        {
            return new PmbokDBContext();
        }

        #region IUnitOfWork Members
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        #endregion

        public System.Data.Entity.DbSet<Project> Projects { get; set; }
        public System.Data.Entity.DbSet<ProjectDocument> ProjectDocuments { get; set; }
        public System.Data.Entity.DbSet<ProjectDocumentValue> ProjectDocumentValues { get; set; }

        public System.Data.Entity.DbSet<ProjectDocumentFile> ProjectDocumentFiles { get; set; }
        public System.Data.Entity.DbSet<ProjectDocumentFileDeleted> ProjectDocumentFilesDeleted { get; set; }
        public System.Data.Entity.DbSet<Log> Logs { get; set; }
    }
}
