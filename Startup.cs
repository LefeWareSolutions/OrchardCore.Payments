using LefeWareSolutions.Payments.Models;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.Payments.Drivers;

namespace LefeWareSolutions.Payments
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            //Migrations
            services.AddScoped<IDataMigration, PaymentFormMigrations>();

            //Parts
            services.AddContentPart<PaymentPart>()
                .UseDisplayDriver<PaymentPartDriver>();
        }
    }
}
