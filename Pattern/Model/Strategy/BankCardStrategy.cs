using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Model.Strategy
{
    public class BankCardStrategy:IPaymentStrategy
    {
        public string Name => "Банківська карта(комісія 1%)";
        public decimal ProcessPayment(decimal amount) {
            return amount * 1.015m;
        }
    }
}
