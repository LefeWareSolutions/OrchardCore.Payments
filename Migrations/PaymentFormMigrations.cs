using System;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace LefeWareSolutions.Payments
{
  public class PaymentFormMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public PaymentFormMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition("PaymentPart", part => part
                .Attachable()
                .WithDescription("Provides payment properties")
                .WithField("Currency", field => field
                    .OfType("TextField")
                    .WithDisplayName("Select the Currency")
                    .WithEditor("PredefinedList")
                    .WithSettings(new TextFieldPredefinedListEditorSettings()
                    {
                        Options = new ListValueOption[]
                        {
                            new ListValueOption(){Name = "Canadian", Value = "CAD"},
                            new ListValueOption(){Name = "US", Value = "USD"}
                        },
                        DefaultValue = "CAD",
                        Editor = EditorOption.Dropdown
                    })
                )
                .WithField("PaymentText", field => field
                    .OfType("HtmlField")
                    .WithSettings(new HtmlFieldSettings() { Hint= "Provide a text to display with payments" })
                    .WithDisplayName("Payment Text")
                    .WithEditor("Wysiwyg")
                )
            );

            _contentDefinitionManager.AlterTypeDefinition("PaymentForm", builder => builder
                .Creatable()
                .Draftable()
                .Versionable()
                .Listable()
                .WithPart("TitlePart", part => part.WithPosition("1"))
                .WithPart("PaymentPart", part => part.WithPosition("2"))
            );

            return 1;
        }
    }
}
