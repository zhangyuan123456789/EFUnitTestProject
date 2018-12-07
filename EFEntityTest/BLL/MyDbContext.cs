using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MyDbContext:BaseDbContext
    {
        public DbSet<MyTestModel> Users { get; set; }
        
        public MyDbContext(string connectionString, string dbType) : base(connectionString, dbType)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
