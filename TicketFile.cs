using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicketSystemClass
{
    public class TicketFile
    {
        public string ticketPath {get;set;}

        public TicketFile(string ticketFilePath)
        {
            ticketPath = ticketFilePath;
        }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    }
}