using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MyBaseService<T, S> : DAL<T> where T : EFEntity where S : new()
    {
        private static S _instance;
        private static readonly object SynObject = new object();

        public static S Instance
        {
            get
            {
                //if (null == _instance)
                //{
                //    lock (SynObject)
                //    {
                //        if (null == _instance)
                //        {
                            _instance = new S();
                //        }
                //    }
                //}
                return _instance;
            }
        }
        public MyBaseService()
        {
            {
                _context = new MyDbContext(DBConfig.DBConnectionString, DBConfig.DBType);
                //_context.Database.EnsureCreated();
            }
        }
    }
}
