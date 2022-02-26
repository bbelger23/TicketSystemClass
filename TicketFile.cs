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
        public List<Ticket> Tickets {get;set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TicketFile(string ticketFilePath)
        {
            ticketPath = ticketFilePath;
            Tickets = new List<Ticket>();

            try
            {
                StreamReader sr = new StreamReader(ticketPath);

                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Ticket ticket = new Ticket();
                    string line = sr.ReadLine();

                    string[] ticketDetails = line.Split(',');
                    ticket.ticketID = UInt64.Parse(ticketDetails[0]);
                    ticket.summary = ticketDetails[1];
                    ticket.status = ticketDetails[2];
                    ticket.priority = ticketDetails[3];
                    ticket.submit = ticketDetails[4];
                    ticket.assigned = ticketDetails[5];
                    ticket.watching = ticketDetails[6].Split('|').ToList();

                   Tickets.Add(ticket); 
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        
    }
}