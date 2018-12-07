using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyTestModel:EFEntity
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
