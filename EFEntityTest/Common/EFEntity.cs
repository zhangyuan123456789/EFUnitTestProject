using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class EFEntity
    {
        [Browsable(false)]
        [Key]
        public Guid ID { get; set; }
    }
}
