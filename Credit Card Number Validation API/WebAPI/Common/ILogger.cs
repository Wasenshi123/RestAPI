using System;

namespace Wasenshi.CreditCard.WebAPI.Common
{
    public interface ILogger
    {
        void LogError(Exception ex);
        void LogDebug(string message);
    }
}