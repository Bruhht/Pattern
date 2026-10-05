using System;
using Pattern.Model.Decorator;
using Pattern.Model.Strategy;
using Pattern.Viewmodel;

namespace Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== СИСТЕМА ОБРОБКИ ТРАНЗАКЦІЙ (MVVM + PATTERNS) ===\n");

            var vm = new MainViewModel();

            Console.WriteLine("--- Крок 1: Базова транзакція ---");
            vm.ProcessTransaction("TX-101", 1000m);

            Console.WriteLine("\n--- Крок 2: Нарощування Decorator (FeeDecorator + EncryptionDecorator) ---");
            INotifier decoratedPipeline = new EncryptionDecorator(
                new FeeDecorator(new BasicNotifier(), serviceFee: 25.0m)
            );
            vm.SetNotifierPipeline(decoratedPipeline);
            vm.ProcessTransaction("TX-102", 1000m);

            Console.WriteLine("\n--- Крок 3: Зміна Strategy на CryptoPaymentStrategy ---");
            vm.ChangeStrategy(new CryptoPaymentStrategy());
            vm.ProcessTransaction("TX-103", 1000m);

            Console.WriteLine("\nВсі операції успішно виконані!");
        }
    }
}