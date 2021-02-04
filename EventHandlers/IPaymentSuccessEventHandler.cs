using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCore.PaymentForm.IEventHandlers
{
    public interface IPaymentSuccessEventHandler
    {
        public Task PaymentSuccess(string paymentId, string paymentType, Dictionary<string, string> metadata);
    }
}
