using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DBFactory
    {
       
        private static DBFactory _instance;
        private static readonly object SynObject = new object();

        private DBFactory() { }
        public static DBFactory Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (SynObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new DBFactory();
                        }
                    }
                }
                return _instance;
            }
        }
        public void CreateDBContext()
        {
            DBConfig.DBConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            DBConfig.DBType = ConfigurationManager.AppSettings["DBType"];
            var isSuccess= new MyDbContext(DBConfig.DBConnectionString, DBConfig.DBType).Database.EnsureCreated();
        }
    }
}
