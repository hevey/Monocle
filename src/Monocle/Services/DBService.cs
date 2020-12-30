using System;
using LiteDB;
using Monocle.Models;

namespace Monocle.Services
{
    public class DBService : IDBService
    {
        public void PostMessage(Contact contact)
        {
            using var db = new LiteDatabase("Monocle.db");
            var col = db.GetCollection<Contact>("contacts");
            
            col.EnsureIndex(x => x.Id, true);

            col.Insert(contact);
        }
    }
}