using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nop.Plugin.Misc.SwiftTask.Models;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Misc.SwiftTask.Validators
{
    public partial class SwiftCustomerValidator : BaseNopValidator<SwiftCustomerModel>
    {
        public SwiftCustomerValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("Field is Mandatory");
            RuleFor(x => x.AgeRange)
                .NotEmpty()
                .WithMessage("Field is Mandatory");
        }
    }
}
