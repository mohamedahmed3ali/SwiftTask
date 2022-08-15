using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Messages;
using Nop.Plugin.Misc.SwiftTask.Domain;
using Nop.Plugin.Misc.SwiftTask.Models;
using Nop.Plugin.Misc.SwiftTask.Service;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Models.DataTables;
using Nop.Web.Framework.Models.Extensions;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Sendinblue.Controllers
{

    [Area(AreaNames.Admin)]
    public class SwiftCustomerController : BasePluginController
    {
        #region Fields

        private readonly IEmailAccountService _emailAccountService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger _logger;
        private readonly IMessageTemplateService _messageTemplateService;
        private readonly IMessageTokenProvider _messageTokenProvider;
        private readonly INotificationService _notificationService;
        private readonly ISettingService _settingService;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IStoreService _storeService;
        private readonly ISwiftCustomerService _swiftCustomerService;
        private readonly IWorkContext _workContext;
        private readonly MessageTemplatesSettings _messageTemplatesSettings;

        #endregion

        #region Ctor

        public SwiftCustomerController(IEmailAccountService emailAccountService,
            IGenericAttributeService genericAttributeService,
            ILocalizationService localizationService,
            ILogger logger,
            IMessageTemplateService messageTemplateService,
            IMessageTokenProvider messageTokenProvider,
            INotificationService notificationService,
            ISettingService settingService,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IWorkContext workContext,
            MessageTemplatesSettings messageTemplatesSettings,
            ISwiftCustomerService swiftCustomerService)
        {
            _emailAccountService = emailAccountService;
            _genericAttributeService = genericAttributeService;
            _localizationService = localizationService;
            _logger = logger;
            _messageTemplateService = messageTemplateService;
            _messageTokenProvider = messageTokenProvider;
            _notificationService = notificationService;
            _settingService = settingService;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _storeService = storeService;
            _workContext = workContext;
            _messageTemplatesSettings = messageTemplatesSettings;
            _swiftCustomerService = swiftCustomerService;
        }

        #endregion

        #region Methods

        [HttpPost, ActionName("SaveCustomer")]
        public async Task<IActionResult> SaveCustomerAsync(SwiftCustomerModel model)
        {
            SwiftCustomerEntity entity = new SwiftCustomerEntity();
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    entity.CustomerName = model.CustomerName;
                    entity.IsValid = model.IsValid;
                    entity.AgeRange = model.AgeRange;
                }
                _swiftCustomerService.Log(entity);
                return Ok();
            }
            else
            {
                return Json("Failed");
            }
            
            
        }

        public string OpenModelPopup()
        {
            //can send some data also.  
            return "<h1>This is Modal Popup Window</h1>";
        }
        [HttpGet]
        public async Task<IActionResult> Configure()
        {
            return View("~/Plugins/Misc.SwiftTask/Views/Configure.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> GetSwiftCustomersList()
        {
            try
            {
                DataTablesModel model = new DataTablesModel { Data = _swiftCustomerService.GetAllSwiftCustomers() };
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}