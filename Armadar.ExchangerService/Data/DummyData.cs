using Armadar.ExchangerService.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armadar.ExchangerService.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ExchangerContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                if (context.Exchanges != null && context.Exchanges.Any()) //checking if data are already created
                    return;

                var exchanges = GetExchanges().ToArray();
                context.Exchanges.AddRange(exchanges);
                context.SaveChanges();
            }
        }

        static List<Exchange> GetExchanges()
        {
            List<Exchange> r = new List<Exchange>();
            r.Add(new Exchange() { from = "PEN", to = "USD", operation = "D", dateRate = DateTime.Now, rate = (decimal)3.297 });
            r.Add(new Exchange() { from = "USD", to = "PER", operation = "M", dateRate = DateTime.Now, rate = (decimal)3.294 });
            return r;
        }
    }
}
