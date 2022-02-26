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
            // user options
            do{
                Console.WriteLine("1. Add Ticket");
                Console.WriteLine("2. Display Tickets");
                Console.WriteLine("Press any key to quit");

                option = Console.ReadLine();

                if (option == "1")
                {
                    // add ticket
                    Ticket ticket = new Ticket();
                    // user adds summary
                    Console.WriteLine("Enter ticket summary");
                    ticket.summary = Console.ReadLine();
                    // user adds status of ticket
                    Console.WriteLine("Enter ticket status");
                    ticket.status = Console.ReadLine();
                    // user adds priority of ticket
                    Console.WriteLine("Enter ticket priority");
                    ticket.priority = Console.ReadLine();
                    // user adds who submitted the ticket
                    Console.WriteLine("Enter ticket submitter");
                    ticket.submit = Console.ReadLine();
                    // user adds who the ticket is assigned to
                    Console.WriteLine("Enter who ticket is assigned to");
                    ticket.assigned = Console.ReadLine();
                    // user adds who is watching the ticket
                    string input;
                    do
                    {
                        Console.WriteLine("Enter who is watching ticket (or done to quit)");
                        input = Console.ReadLine();
                        if (input != "done" && input.Length > 0)
                        {
                            ticket.watching.Add(input);
                        }
                    } while (input != "done");
                    if (ticket.watching.Count == 0)
                    {
                        ticket.watching.Add("(No one is watching the ticket)");
                    }

                    ticketFile.AddTicket(ticket);

                } else if (option == "2")
                {
                    // display all tickets
                    foreach(Ticket t in ticketFile.Tickets)
                    {
                        Console.WriteLine(t.Show());
                    }
                }

            } while (option == "1" || option == "2");

            logger.Info("Program ended");
        }    
    }
}
