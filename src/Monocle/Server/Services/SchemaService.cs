using LiteDB;
using Monocle.Shared.Models;

namespace Monocle.Server.Services
{
    public class SchemaService
    {
        public SchemaService()
        {
            using var db = new LiteDatabase("../Data/Monocle.db");
            var col = db.GetCollection<Schema>("schema");
            
            col.EnsureIndex(x => x.Id, true);
            col.EnsureIndex(x => x.Version);
        }
    }
}