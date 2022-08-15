using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Plugin.Misc.SwiftTask.Domain;
using Nop.Plugin.Misc.SwiftTask.Models;
using Nop.Plugin.Misc.SwiftTask.Service;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Misc.SwiftTask.Components
{
    [ViewComponent(Name = "SwiftCustomerView")]
    public class SwiftCustomerComponent : NopViewComponent
    {
        private readonly ISwiftCustomerService _swiftCustomerService;
        private readonly IWorkContext _workContext;

        public SwiftCustomerComponent(ISwiftCustomerService swiftCustomerService,
            IWorkContext workContext)
        {
            _swiftCustomerService = swiftCustomerService;
            _workContext = workContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            SwiftCustomerModel model = new SwiftCustomerModel();
            model.AgeRangeList = new List<SelectListItem>();
            model.AgeRangeList.Add(new SelectListItem("8-13 years", "8-13 years"));
            model.AgeRangeList.Add(new SelectListItem("13-21 years", "13-21 years"));
            model.AgeRangeList.Add(new SelectListItem("22-30 years", "22-30 years"));
            model.AgeRangeList.Add(new SelectListItem("30+ years", "30+ years"));
            return View("~/Plugins/Misc.SwiftTask/Views/SwiftCustomerView.cshtml",model);
        }
    }
}