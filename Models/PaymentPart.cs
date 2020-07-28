using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace LefeWareSolutions.Payments.Models
{
    public class PaymentPart : ContentPart
    {
        public decimal Cost { get; set; }
        public TextField Currency { get; set; }
        public HtmlField PaymentText { get; set; }
    }
}
