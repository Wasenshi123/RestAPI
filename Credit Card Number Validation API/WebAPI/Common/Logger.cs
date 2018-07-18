using System;
using System.Diagnostics;
using System.Reflection;

namespace Wasenshi.CreditCard.WebAPI.Common
{
    public class Logger : ILogger
    {
        enum Severity
        {
            Info,
            Error
        }

        public void LogError(Exception ex)
        {
            LogMessageToEventLog(Severity.Error, ex.ToString());
        }

        public void LogDebug(string message)
        {
            LogMessageToEventLog(Severity.Info, message);
        }

        private void LogMessageToEventLog(Severity severityLevel, string message)
        {
            EventLog eventLog = new EventLog("CreditCardApi") {Source = Assembly.GetExecutingAssembly().FullName };
            eventLog.WriteEntry($"{severityLevel}: {message}",
                severityLevel == Severity.Error ? EventLogEntryType.Error : EventLogEntryType.Information);
        }
    }
}