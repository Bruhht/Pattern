using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Model.Decorator
{
    public interface INotifier
    {
        string FormatMessage(string transactionId, decimal amount);
    }
    public class BasicNotifier:INotifier
    {
        public virtual string FormatMessage(string transactionId, decimal amount)
        {
            return $"Транзакція [{transactionId}] на суму: {amount:F2} UAH";
        }
    }
    public abstract class NotifierDecorator : INotifier
    {
        protected INotifier _notifier;
        protected NotifierDecorator(INotifier notifier) {
            _notifier = notifier;
        }
        public virtual string FormatMessage(string transactionId, decimal amount)
        {
            return _notifier.FormatMessage(transactionId, amount);
        }
    }
}
