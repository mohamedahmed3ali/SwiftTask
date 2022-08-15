using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Misc.SwiftTask
{
    public class SwiftTaskPlugin : BasePlugin, IMiscPlugin, IWidgetPlugin
    {

        private readonly IWebHelper _webHelper;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;

        public SwiftTaskPlugin(
            IActionContextAccessor actionContextAccessor,
            IUrlHelperFactory urlHelperFactory)
        {
            _actionContextAccessor = actionContextAccessor;
            _urlHelperFactory = urlHelperFactory;
        }

        public bool HideInWidgetList => true;

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "SwiftCustomerView";
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { AdminWidgetZones.DashboardTop });
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext).RouteUrl("Plugin.Misc.SwiftTask.Configure");
        }

        public override async Task InstallAsync()
        {
            //Logic during installation goes here...

            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            //Logic during uninstallation goes here...

            await base.UninstallAsync();
        }
    }
}