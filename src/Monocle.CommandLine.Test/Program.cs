using System;
using System.Linq;
using LiteDB;
using Monocle.Models;

namespace Monocle.CommandLine.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new LiteDatabase("/Users/hevey/Development/Monocle/src/Monocle/Monocle.db");
            
            var contacts = db.GetCollection<Contact>("contacts");

            /*contacts.DeleteAll();*/

            var query = contacts
                .Query()
                .OrderBy(x => x.Id)
                .Select(x => new {x.Id, x.Message, x.SentTime})
                .ToList();
            
            foreach(var contact in query)
            {
                Console.WriteLine($"ID: {contact.Id}, Message: {contact.Message}, Sent Time: {contact.SentTime?.ToLocalTime()}");
            }
        }
    }
}