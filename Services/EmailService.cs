using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Services
{
    public static class EmailService
    {
        public static void SendEmail(Contact contact)
        {
            Console.WriteLine($"Mailing contact {contact.Name ?? string.Empty}");
        }

        public static void SendEmail(string address)
        {
            Console.WriteLine($"Mailing contact {address ?? string.Empty}");
        }
    }
}
