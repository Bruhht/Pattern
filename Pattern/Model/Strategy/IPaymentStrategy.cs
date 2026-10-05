using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Model.Strategy
{
    public interface IPaymentStrategy
    {
        string Name { get; }
        decimal ProcessPayment(decimal amount);
    }
}
