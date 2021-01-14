using System;
using LiteDB;
using Monocle.Shared.Models;

namespace Monocle.API.Services
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
            using var db = new LiteDatabase("db/Monocle.API.db");
            var col = db.GetCollection<Contact>("contacts");
            
            col.EnsureIndex(x => x.Id, true);

            col.Insert(contact);
        }
    }
}