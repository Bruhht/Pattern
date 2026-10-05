using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Model.Decorator
{
    internal class FeeDecorator:NotifierDecorator
    {
        decimal _serviceFee;
        public FeeDecorator(INotifier notifier, decimal serviceFee = 10m) : base(notifier) {
            _serviceFee = serviceFee;
        }
        public override string FormatMessage(string transactionId, decimal amount)
        {
            decimal totalWithFee= amount + _serviceFee;
            string baseMsg = base.FormatMessage(transactionId, totalWithFee);
            return $"{baseMsg} (вкл. сервісний збір: {_serviceFee:F2} UAH)";
        }
    }
}
