using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Wedding.AdminWebApp.Authorisation
{
    public class ApplicationUserCreate
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly List<string> _userNames = new List<string>
        {
            "test01",
            "user001",
            "user002"
        };

        public ApplicationUserCreate(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
/*
        public async Task Execute()
        {
            using (var dbContext = _serviceProvider.GetService<ApplicationUserDbContext>())
            {
                var sqlServerDatabase = dbContext.Database;
                if (sqlServerDatabase != null)
                {
                    // add some users
                    var userManager = _serviceProvider.GetService<UserManager<ApplicationUser>>();
                    ApplicationUser user = await userManager.FindByNameAsync("test01");// .FindByEmailAsync("test01@example.com");
                    if (user == null)
                    {
                        user = new ApplicationUser { UserName = "test01", Email = "test01@example.com" };
                        await userManager.CreateAsync(user, "Qwer!@#12345");
                    }
                }
            }
        }*/
        
        public async Task Execute()
        {
            using (var dbContext = _serviceProvider.GetService<ApplicationUserDbContext>())
            {
                var sqlServerDatabase = dbContext.Database;
                if (sqlServerDatabase != null)
                {
                    // add some users
                    var userManager = _serviceProvider.GetService<UserManager<ApplicationUser>>();

                    foreach (string userName in _userNames)
                    {
                        var password = userName;
                        ApplicationUser user = await userManager.FindByNameAsync(userName);
                        if (user == null)
                        {
                            user = new ApplicationUser { UserName = userName };
                            await userManager.CreateAsync(user, IdentityConstants.Password);
                        }
                    }
                }
            }
        }
    }
}