using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDbContext : DbContext
    {        
        private string _connectionString;
        private string _dbType;
        public BaseDbContext(string connectionString, string dbType)
        {
            _connectionString = connectionString;
            _dbType = dbType;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                //if (string.Compare("Sqlite", _dbType, System.StringComparison.OrdinalIgnoreCase) == 0)
                //{
                //    optionsBuilder.UseSqlite(_connectionString);
                //}
                //else if (string.Compare("SqlServer", _dbType, System.StringComparison.OrdinalIgnoreCase) == 0)
                //{
                //    optionsBuilder.UseSqlServer(_connectionString, b => b.UseRowNumberForPaging());
                //}
                if (string.Compare("SqlServerCompact", _dbType, System.StringComparison.OrdinalIgnoreCase) == 0)
                {

                    optionsBuilder.UseSqlCe(_connectionString);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("加载数据库出错", ex);
            }
        }
    }
}
