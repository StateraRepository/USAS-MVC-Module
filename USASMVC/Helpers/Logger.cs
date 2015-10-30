using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace USASMVC.Helpers
{
    public static class Logger
    {
        public static void LogError(string errorType, string errorMessage)
        {

            string sLog = "Application";

            if (!EventLog.SourceExists(errorType))
                EventLog.CreateEventSource(errorType, sLog);

            EventLog.WriteEntry(errorType, errorMessage, EventLogEntryType.Error);
        }

    }
}