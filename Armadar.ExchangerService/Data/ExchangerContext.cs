using Armadar.ExchangerService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armadar.ExchangerService.Data
{
    public class ExchangerContext:DbContext
    {
        public ExchangerContext(DbContextOptions<ExchangerContext> options) : base(options)
        {
        }
        public DbSet<Exchange> Exchanges { get; set; }
    }
}
