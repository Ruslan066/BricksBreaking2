using BricksBreaking2Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksBreaking2Core.Service
{
    public class BricksBreaking2DbContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }
        public DbSet<DataBase> DBScores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BricksBreaking2;Trusted_Connection=True;");
        }
    }

}
