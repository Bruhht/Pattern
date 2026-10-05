using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Model.Observer
{
    internal class EmailNotifier:ITransactionObserver
    {
        public void OnNotificationReceived(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[EmailNotifier -> user@mail.com]: Відправлено сповіщення :{message}");
            Console.ResetColor();
        }
    }
}
