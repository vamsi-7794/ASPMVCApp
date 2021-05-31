using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPMVCApp.Models;

namespace ASPMVCApp.Data
{
    public class DbCon:DbContext
    {
        public DbCon(DbContextOptions<DbCon>options):base(options)
        {
            
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<ApplicationType>ApplicationType { get; set; }

       
    }
}
