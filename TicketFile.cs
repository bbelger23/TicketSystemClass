using System;
using NLog.Web;
using System.IO;

namespace TicketSystemClass
{
    public class TicketFile
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    }
}