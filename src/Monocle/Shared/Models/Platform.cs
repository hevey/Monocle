using System.Collections.Generic;

namespace Monocle.Shared.Models
{
    public abstract class Platform
    {
        protected (int id, string name) Details = new();
        public abstract (int id, string name) PlatformDetails();
        public abstract void PostMessage(Contact contact);
        public abstract List<Contact> GetMessages();
    }
}