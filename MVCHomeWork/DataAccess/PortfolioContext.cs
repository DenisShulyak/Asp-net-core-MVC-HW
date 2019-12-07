using Microsoft.EntityFrameworkCore;
using MVCHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHomeWork.DataAccess
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<FileModel> Files { get; set; }
    }
}
