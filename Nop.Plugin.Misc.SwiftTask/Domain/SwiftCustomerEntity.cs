using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace Nop.Plugin.Misc.SwiftTask.Domain
{
    public class SwiftCustomerEntity : BaseEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsValid { get; set; }
        public string AgeRange { get; set; }
    }
}
