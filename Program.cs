using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;
namespace TicketSystemClass
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string ticketFilePath = Directory.GetCurrentDirectory() + "\\tickets.csv";

            logger.Info("Program Started");

            Ticket ticket = new Ticket
            {
                ticketID = 1,
                summary = "This is a bug ticket",
                status = "Open",
                priority = "High",
                submit = "Drew Kjell",
                assigned = "Jane Doe",
                watching = new List<string> {"Drew Kjell", "John Smith", "Bill Jones"}
            };

            Console.WriteLine(ticket.Show());
            
            logger.Info("Program ended");
        }    
    }
}
