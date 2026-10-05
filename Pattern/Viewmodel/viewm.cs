using System;
using System.Collections.ObjectModel;
using Pattern.Model.Decorator;
using Pattern.Model.Observer;
using Pattern.Model.Strategy;

namespace Pattern.Viewmodel
{
    public class MainViewModel : ITransactionObserver
    {
        private readonly MarketNotifier _marketNotifier;

        public ObservableCollection<string> Logs { get; } = new();
        public IPaymentStrategy CurrentStrategy { get; set; }
        public INotifier CurrentNotifier { get; set; }

        public MainViewModel()
        {
            _marketNotifier = new MarketNotifier();

            _marketNotifier.Attach(new ConsoleLogger());
            _marketNotifier.Attach(new EmailNotifier());
            _marketNotifier.Attach(this);

            CurrentStrategy = new BankCardStrategy();
            CurrentNotifier = new BasicNotifier();
        }

        public void ChangeStrategy(IPaymentStrategy newStrategy)
        {
            CurrentStrategy = newStrategy;
            Console.WriteLine($"\n[ViewModel] Змінено стратегію на: {newStrategy.Name}");
        }

        public void SetNotifierPipeline(INotifier notifier)
        {
            CurrentNotifier = notifier;
            Console.WriteLine("\n[ViewModel] Оновлено конфігурацію декораторів.");
        }

        public void ProcessTransaction(string txId, decimal rawAmount)
        {
            decimal totalAmount = CurrentStrategy.ProcessPayment(rawAmount);

            string formattedMessage = CurrentNotifier.FormatMessage(txId, totalAmount);

            _marketNotifier.Notify(formattedMessage);
        }

        public void OnNotificationReceived(string message)
        {
            Logs.Add(message);
        }
    }
}