using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//جهت فعال سازی و دسترسی به بخش اکانت
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
//using Pseez.VisitRegistration.DomainClasses.Models.Identity;

//جهت ارتباط با پایگاه داده
using Pmbok.DataAccessLayer.DataContext;
using Pmbok.DataAccessLayer.Migrations;
using Identity.Models.Models;
using System.Data.Entity;

namespace Pmbok.DataAccessLayer.Migrations
{
    public class SeedIdentity
    {
        private PmbokDBContext _pmbokDBContext = new PmbokDBContext();

        public void CreateAdminUserAndRole()
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_pmbokDBContext));
            //Create User "Admin" if it is not existed.
            if (userManager.FindByName("Admin") == null)
            {
                var user = new ApplicationUser() { UserName = "Admin"/*, Email = "Admin@Pseez.ir"*/ };
                userManager.Create(user, "Pass#1");
                //userManager.Create(user, "Visit-Pseez#1");
            }
            //Create Role "Admin" if it is not existed.
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_pmbokDBContext));
            if (roleManager.FindByName("Admin") == null)
            {
                IdentityRole identityRole = new IdentityRole("Admin");
                roleManager.Create(identityRole);
            }
            //Add Admin user to Admin Role
            string identityUserId = _pmbokDBContext.Users.First(x => x.UserName == "Admin").Id;
            userManager.AddToRole(identityUserId, "Admin");
        }

        public void AddRoles()
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_pmbokDBContext));
            string[] roleNames = { "ProjectsAdmin" };
            foreach (string roleName in roleNames)
            {
                if (roleManager.FindByName(roleName) == null)
                {
                    IdentityRole identityRole = new IdentityRole(roleName);
                    roleManager.Create(identityRole);
                }
            }
        }
    }
}
