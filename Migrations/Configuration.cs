namespace FlyBuy.Migrations
{
    using FlyBuy.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FlyBuy.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FlyBuy.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);


            const string Name = "admin@TIK.al";
            const string Password = "Password";
            const string roleName = "Admin";

            var role = roleManager.FindByName(roleName);

            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            var user = userManager.FindByName(Name);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = Name,
                    Email = Name
                };

                var result = userManager.Create(user, Password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
            //Create users role
            const string userRoleName = "Users";
            role = roleManager.FindByName(userRoleName);
            if (role == null)
            {
                role = new IdentityRole(userRoleName);
                var roleresult = roleManager.Create(role);
            }
        }
    }
}
