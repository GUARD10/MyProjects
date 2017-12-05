using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestApp;

namespace WebDateApp.Context
{
    public class DateTimeContext : DbContext
    {
        public DbSet<DateTimeModel> DTModels { get; set; }
        public DateTimeContext(DbContextOptions<DateTimeContext> options)
            : base(options)
        {
        }
    }
}
