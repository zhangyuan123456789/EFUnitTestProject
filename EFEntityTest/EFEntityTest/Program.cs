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
            try
            {
                DBFactory.Instance.CreateDBContext();
                Console.WriteLine("数据库初始化成功\n");
            L1:
                {
                    var res = MyTestService.Instance.FindAll();
                    Console.WriteLine("查询到" + res.Count + "条记录\n");
                    Console.WriteLine("1、添加一条记录 2、清空所有记录 \n");
                    var key = Console.ReadKey();
                    if (key.KeyChar == '1')
                    {
                        var entity = new MyTestModel() { Name = "zhangyuan", Age = "26" };
                        var addres = MyTestService.Instance.AddOne(entity);
                        if (addres != 0)
                        {
                            Console.WriteLine("添加成功！\n");
                            goto L1;
                        }
                    }
                    else if (key.KeyChar == '2')
                    {
                        var all = MyTestService.Instance.FindAll();
                        foreach (var item in all)
                        {
                            MyTestService.Instance.Delete(item);
                        }
                        Console.WriteLine("删除成功！\n");
                        goto L1;
                    }
                    //else if (key.KeyChar == '3')
                    //{
                    //    goto L1;
                    //}
                }
               
                
                


                //TestAddSameEntity();
                //TestcatchError();
            }
            catch (Exception e)
            {
                Console.WriteLine("出现异常："+e.Message);
            }
            
            
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
