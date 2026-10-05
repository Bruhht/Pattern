using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Model.Observer
{
    public interface ITransactionObserver
    {
        void OnNotificationReceived(string message);
    }
    internal class MarketNotifier
    {
        List<ITransactionObserver> _observers = new();

        public void Attach(ITransactionObserver observer) => _observers.Add(observer);
        public void Detach(ITransactionObserver observer) => _observers.Remove(observer);

        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.OnNotificationReceived(message);
            }
        }
    }
}
