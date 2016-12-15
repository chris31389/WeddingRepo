using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Wedding.Application;
using Wedding.Application.Adtos;
using Wedding.Domain.ReferenceDatas;
using Wedding.Domain.UserAccounts;
using Wedding.Persistence.Contexts;

namespace Wedding.TestApp
{
    public class Program
    {
        private static IList<WeddingEvent> _weddingEvents;
        private static IList<StarterChoice> _starterChoice;
        private static IList<MainChoice> _mainChoice;
        private static IList<DessertChoice> _dessertChoice;

        public static void Main(string[] args)
        {
            // Reset();

            StandardKernel kernel = new StandardKernel();
            NinjectInjection.Inject(kernel);

            IInviteService inviteService = kernel.Get<IInviteService>();
            IRsvpService rsvpService = kernel.Get<IRsvpService>();
            IMealChoiceService mealChoiceService = kernel.Get<IMealChoiceService>();

            Setup();
            
            // RunBadStuff();

            RunStuff(inviteService, rsvpService, mealChoiceService);
        }

        private static void Setup()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            string sqlConnectionString = configurationManager.GetSetting("SqlConnectionString");
            DbContextOptions<WeddingDbContext> contextOptions = new DbContextOptionsBuilder<WeddingDbContext>()
                // .UseInMemoryDatabase()
                .UseSqlServer(sqlConnectionString)
                .Options;
            using (WeddingDbContext context = new WeddingDbContext(contextOptions))
            {
                _weddingEvents = context.WeddingEvents.ToList();
                _starterChoice = context.StarterChoices.ToList();
                _mainChoice = context.MainChoices.ToList();
                _dessertChoice = context.DessertChoices.ToList();
            }
        }

        private static void RunBadStuff()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            string sqlConnectionString = configurationManager.GetSetting("SqlConnectionString");
            DbContextOptions<WeddingDbContext> contextOptions = new DbContextOptionsBuilder<WeddingDbContext>()
                // .UseInMemoryDatabase()
                .UseSqlServer(sqlConnectionString)
                .Options;

            using (WeddingDbContext context = new WeddingDbContext(contextOptions))
            {
                User user1 = new User("user001");
                context.Users.Add(user1);
                context.SaveChanges();

                foreach (User user in context.Users)
                {
                    Console.WriteLine($"username: {user.Username}");
                }
                
                foreach (WeddingEvent weddingEvent in context.WeddingEvents)
                {
                    Console.WriteLine($"weddingevent: {weddingEvent.Value}");
                }

                foreach (StarterChoice starterChoice in context.StarterChoices)
                {
                    Console.WriteLine($"starterChoice: {starterChoice.Value}, {starterChoice.SecondaryValue}");
                }

                foreach (MainChoice mainChoice in context.MainChoices)
                {
                    Console.WriteLine($"mainChoice: {mainChoice.Value}, {mainChoice.SecondaryValue}");
                }

                foreach (DessertChoice dessertChoice in context.DessertChoices)
                {
                    Console.WriteLine($"dessertChoice: {dessertChoice.Value}, {dessertChoice.SecondaryValue}");
                }

                /*InviteFactory inviteFactory = new InviteFactory(new InviteRepository(context), new UserRepository(context));
                inviteFactory.Create(user1.Id, new List<CreateInviteeDdto>
                {
                    new CreateInviteeDdto
                    {
                        Fullname = "Yasmin Giles",
                        IsAdult = true
                    }
                }, new List<WeddingEvent>
                {
                    WeddingEvent.Breakfast
                });*/
            }
        }

        private static void RunStuff(
            IInviteService inviteService,
            IRsvpService rsvpService,
            IMealChoiceService mealChoiceService
            )
        {
            List<CreateInviteeAdto> createInviteeAdtos = new List<CreateInviteeAdto>
            {
                new CreateInviteeAdto
                {
                    Fullname = "Yasmin Giles",
                    IsAdult = true
                }
            };

            InviteAdto inviteAdto = inviteService.Create(new CreateInviteAdto
            {
                Username = "user002",
                WeddingEventIds = _weddingEvents.Where(x => string.Equals(x.Value, "Breakfast")).Select(x => x.Id),
                CreateInviteeAdtos = createInviteeAdtos
            });

            Console.WriteLine($"Created invite {inviteAdto.Id} and user");

            foreach (InviteeAdto inviteeAdto in inviteAdto.InviteeAdtos)
            {
                Console.WriteLine($"Created invite for {inviteeAdto.Fullname}");
            }

            string email = "christopher_g_butler@hotmail.co.uk";
            List<CreateRsvpAdto> createRsvpAdtos = new List<CreateRsvpAdto>
            {
                new CreateRsvpAdto
                {
                    InviteeId = inviteAdto.InviteeAdtos.First().Id,
                    CanCome = true
                }
            };

            rsvpService.AddRsvp(inviteAdto.Id, email, createRsvpAdtos);

            List<CreateMealAdto> createMealAdtos = new List<CreateMealAdto>
            {
                new CreateMealAdto
                {
                    InviteeId = inviteAdto.InviteeAdtos.First().Id,
                    StarterChoiceId = _starterChoice.First(x => string.Equals(x.Value, "Duck")).Id,
                    MainChoiceId = _mainChoice.First(x => string.Equals(x.Value, "Lamb")).Id,
                    DessertChoiceId = _dessertChoice.First(x => string.Equals(x.Value, "Brulee")).Id,
                    DietaryRequirements = "No Cheese please!"
                }
            };

            mealChoiceService.AddMeal(inviteAdto.Id, createMealAdtos);
        }

        private static void Reset()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            string sqlConnectionString = configurationManager.GetSetting("SqlConnectionString");
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    // sqlCommand.CommandText = "EXEC sp_MSforeachtable @command1 = \"DROP TABLE ?\"";

                    sqlCommand.CommandText =
                        "DECLARE @DBName varchar(50) = 'TestDb' " +
                        "USE master " +
                        "EXEC('DROP DATABASE ' + @DBName) " +
                        "EXEC('CREATE DATABASE ' + @DBName)";
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Connection = sqlConnection;

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
