using System.Threading.Tasks;
using LefeWareSolutions.Payments.Models;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Mvc.ModelBinding;

namespace OrchardCore.Payments.Drivers
{
    public class PaymentPartDriver : ContentPartDisplayDriver<PaymentPart>
    {
        private readonly IStringLocalizer S;

        public PaymentPartDriver(IStringLocalizer<PaymentPartDriver> localizer)
        {
            S = localizer;
        }

        //public override IDisplayResult Display(PaymentPart part)
        //{
        //    return View("PaymentPart", part).Location("Detail", "Content");
        //}

        public override IDisplayResult Edit(PaymentPart part)
        {
            return Initialize<PaymentPartEditViewModel>("PaymentPart_Fields_Edit", m =>
            {
                m.Cost = part.Cost;
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(PaymentPart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(model, Prefix, t => t.Cost);

            await ValidateAsync(model, updater);

            return Edit(model);
        }

        private Task ValidateAsync(PaymentPart paymentPart, IUpdateModel updater)
        {
            if (paymentPart.Cost < 0)
            {
                updater.ModelState.AddModelError(Prefix, nameof(paymentPart.Cost), S["You must set price higher than 0"]);
            }

            return Task.CompletedTask;
        }
    }
}
