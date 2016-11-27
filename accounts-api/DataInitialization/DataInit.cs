using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using accounts_api.Models;
using accounts_api.Contexts;

namespace accounts_api.DataInitialization
{
    public class DataInit
    {
        public static void InitializeData(string jsonData, IServiceProvider serviceProvider)
        {
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(jsonData);
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AccountContext>();
                if (!context.Accounts.Any())
                {
                    context.AddRange(accounts);
                    context.SaveChanges();
                }
            }
        }
    }
}
