using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MyTestService:MyBaseService<MyTestModel, MyTestService>
    {
        public void FindAllTestModels()
        {

        }
        public int AddOne(MyTestModel one)
        {
            return base.Add(one);
        }
    }
}
