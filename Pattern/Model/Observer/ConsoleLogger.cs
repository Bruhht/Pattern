using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Model.Observer
{
    internal class ConsoleLogger:ITransactionObserver
    {
        public void OnNotificationReceived(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[ConsoleLogger]:{message}");
            Console.ResetColor();
        }
    }
}
