using System;
using System.Collections.Generic;
using LiteDB;
using Monocle.Shared.Models;

namespace Monocle.Shared.Services
{
    public class DbPlatform : Platform
    {
        public DbPlatform()
        {
            Details.id = 1;
            Details.name = "Database Platform";
        }
        public override (int id, string name) PlatformDetails()
        {
            return Details;
        }

        public override void PostMessage(Contact contact)
        {
            using var db = new LiteDatabase("../Data/Monocle.db");
            var col = db.GetCollection<Contact>("contacts");
            
            col.EnsureIndex(x => x.Id, true);

            col.Insert(contact);
        }

        public override List<Contact> GetMessages()
        {
            using var db = new LiteDatabase("../Data/Monocle.db");
            
            var contacts = db.GetCollection<Contact>("contacts");

            var query = contacts
                .Query()
                .OrderBy(x => x.Id)
                .Select(x => x)
                .ToList();

            return query;
        }
    }
}
