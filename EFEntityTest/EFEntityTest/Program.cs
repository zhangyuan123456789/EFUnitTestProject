using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntityTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            DBFactory.Instance.CreateDBContext();
            //TestAddSameEntity();
            //TestcatchError();
            Console.ReadKey();

        }
        /// <summary>
        /// 测试重复添加实体
        /// </summary>
        public static int TestAddSameEntity()
        {
            //DBFactory.Instance.CreateDBContext();
            var entity = new MyTestModel() { Name = "zhangyuan", Age = "26" };
            var res = MyTestService.Instance.AddOne(entity);
            res = MyTestService.Instance.AddOne(entity);
            return res;
            //Console.WriteLine("Add Same Entity Test:add " + res + " entity Success!");
        }
        /// <summary>
        /// 测试捕捉到错误后继续操作有什么问题
        /// </summary>
        public static void TestcatchError()
        {
            try
            {
                var entity = new MyTestModel() { Name = "zhangyuan", Age = "26" };
                var res = MyTestService.Instance.AddOne(entity);
                res = MyTestService.Instance.AddOne(entity);
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Catch Error!");

            }
            MyTestService.Instance.AddOne(new MyTestModel() { Age="123",Name="123"});


        }
    }
}
