using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Model.Decorator
{
    public class EncryptionDecorator:NotifierDecorator
    {
        public EncryptionDecorator(INotifier notifier):base(notifier) { }
        public override string FormatMessage(string transactionId,decimal amount)
        {
            string encryptedId = Convert.ToBase64String(Encoding.UTF8.GetBytes(transactionId));
            return $"[Encrypted] " + base.FormatMessage(encryptedId, amount);
        }
    }
}
