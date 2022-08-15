using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.SwiftTask.Models
{
    public record SwiftCustomerModel : BaseNopEntityModel
    {
        public SwiftCustomerModel()
        {

        }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string AgeRange { get; set; }

        public IList<SelectListItem> AgeRangeList { get; set; }
        public bool IsValid { get; set; }
    }
}
