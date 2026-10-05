using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Model.Strategy
{
    public class CryptoPaymentStrategy:IPaymentStrategy
    {
        public string Name => "Крипта(комісія 0.5%)";
        public decimal ProcessPayment(decimal amount)
        {
            return amount * 1.005m;
        }
    }
}
