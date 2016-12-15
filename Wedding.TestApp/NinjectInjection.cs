using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;
using Wedding.Application;
using Wedding.Common;
using Wedding.Domain.Invites;
using Wedding.Persistence.Contexts;
using Wedding.Persistence.Repositories;

namespace Wedding.TestApp
{
    public static class NinjectInjection
    {
        public static void Inject(IKernel kernel)
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IConfigurationManager>().To<ConfigurationManager>().InSingletonScope();

            IConfigurationManager configurationManager = kernel.Get<IConfigurationManager>();
            string sqlConnectionString = configurationManager.GetSetting("SqlConnectionString");
            DbContextOptions<WeddingDbContext> dbContextOptions = new DbContextOptionsBuilder<WeddingDbContext>()
                .UseSqlServer(sqlConnectionString)
                .Options;

            // This needs to be changed to InRequestScope for web api projects
            kernel.Bind<WeddingDbContext>()
                .To<WeddingDbContext>()
                .InSingletonScope()
                .WithConstructorArgument(dbContextOptions)
                .OnDeactivation(x => x.Dispose());
            
            kernel.Bind<ISession>().To<Session>().InRequestScope().OnDeactivation(x => x.Dispose());
            kernel.Bind<IMealValidator>().To<MealValidator>();

            //This will bind all interfaces which have implementing classes with the same name (e.g: IFoo -> Foo, IBar -> Bar, etc...)
            kernel.Bind(x =>
                x.FromAssemblyContaining<InviteRepository>()
                .SelectAllClasses()
                .Where(y => y.Name.EndsWith("Repository", StringComparison.Ordinal))
                .BindDefaultInterface()
                .Configure(z => z.InRequestScope())
            );
            
            //This will bind all interfaces which have implementing classes with the same name (e.g: IFoo -> Foo, IBar -> Bar, etc...)
            kernel.Bind(x =>
                x.FromAssemblyContaining<InviteFactory>()
                .SelectAllClasses()
                .Where(y => y.Name.EndsWith("Factory", StringComparison.Ordinal))
                .BindDefaultInterface()
                .Configure(z => z.InRequestScope())
            );

            //This will bind all interfaces which have implementing classes with the same name (e.g: IFoo -> Foo, IBar -> Bar, etc...)
            kernel.Bind(x =>
                x.FromAssemblyContaining<SessionFactory>()
                .SelectAllClasses()
                .Where(y => y.Name.EndsWith("Factory", StringComparison.Ordinal))
                .BindDefaultInterface()
                .Configure(z => z.InRequestScope())
            );

            //This will bind all interfaces which have implementing classes with the same name (e.g: IFoo -> Foo, IBar -> Bar, etc...)
            kernel.Bind(x =>
                x.FromAssemblyContaining<InviteService>()
                .SelectAllClasses()
                .Where(y => y.Name.EndsWith("Service", StringComparison.Ordinal))
                .BindDefaultInterface()
                .Configure(z => z.InRequestScope())
            );
        }
    }
}
