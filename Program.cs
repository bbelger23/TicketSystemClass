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

            TicketFile ticketFile = new TicketFile(ticketFilePath);

            string option = "";
            do{
                Console.WriteLine("1. Add Ticket");
                Console.WriteLine("2. Display Tickets");
                Console.WriteLine("Press any key to quit");

                option = Console.ReadLine();
                
            } while (option == "1" || option == "2");

            logger.Info("Program ended");
        }    
    }
}
