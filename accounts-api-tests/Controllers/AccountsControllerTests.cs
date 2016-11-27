using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using accounts_api.Contexts;
using accounts_api.Controllers;
using accounts_api.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace accounts_api_tests.Controllers
{
    public class AccountsControllerTests
    {
        private AccountContext _context;

        [Fact]
        public void CanGetAccounts()
        {
            _context = CreateAndFillContext();
            using (var controller = new AccountsController(_context))
            {
                var results = controller.Get();
                Assert.Equal(3, results.Count());
            }
        }

        private AccountContext CreateAndFillContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountContext>();
            optionsBuilder.UseInMemoryDatabase();

            var context = new AccountContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Accounts.AddRange(InitializeAccounts());
            context.SaveChanges();
            return context;

        }
        private List<Account> InitializeAccounts()
        {
            var accounts = new List<Account>
            {
                new Account
                { 
                    Name = "HelloCompany",
                    Status = AccountStatus.Created,
                    CreationDate = DateTime.Now.AddDays(-3),
                    Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            FirstName = "Hello",
                            LastName = "World",
                            EmailAddress = "hello.world@invalid.com",
                            PhoneNumber = "00 33 6 12 34 56 78"
                        },
                        new Contact
                        {
                            FirstName = "GoodBye",
                            LastName = "World",
                            EmailAddress = "goodbye.world@invalid.com",
                            PhoneNumber = "00 33 6 12 34 56 78"
                        }
                    }
                },
                new Account
                { 
                    Name = "H2G2",
                    Status = AccountStatus.Active,
                    CreationDate = DateTime.Now.AddMonths(-3),
                    Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            FirstName = "the answer to life",
                            LastName = "the universe and everything",
                            EmailAddress = "theanswer@lifetheuniverseandeverything.com",
                            PhoneNumber = "0123456987"
                        },
                        new Contact
                        {
                            FirstName = "42",
                            LastName = "Answser",
                            EmailAddress = "answer42@h2g2.com",
                            PhoneNumber = "0987654321"
                        }
                    }
                },
                new Account
                { 
                    Name = "Arrakis",
                    Status = AccountStatus.Closed,
                    CreationDate = DateTime.Now.AddYears(-2)
                }
            };
            return accounts;
        }
    }
}
