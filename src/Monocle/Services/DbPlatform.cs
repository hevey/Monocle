using System;
using LiteDB;
using Monocle.Models;

namespace Monocle.Services
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
            using var db = new LiteDatabase("db/Monocle.db");
            var col = db.GetCollection<Contact>("contacts");
            
            col.EnsureIndex(x => x.Id, true);

            col.Insert(contact);
        }
    }
}