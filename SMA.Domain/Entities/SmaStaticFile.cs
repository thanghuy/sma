using SMA.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Domain.Entities
{
    public class SmaStaticFile : BaseEntitites
    {
        public string Name { get; set; }
        public int UseCount { get; set; }
    }
}
