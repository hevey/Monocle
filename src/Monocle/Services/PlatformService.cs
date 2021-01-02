using System.Collections.Generic;
using Monocle.Models;

namespace Monocle.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly List<Platform> _platforms = new();
        
        public PlatformService()
        {
            _platforms.Add(new DbPlatform());
        }

        public List<Platform> ConfiguredPlatforms()
        {
            return _platforms;
        }

        public Platform? FindPlatform(int id)
        {
            return _platforms.Find(p => p.PlatformDetails().id == id);
        }

        public void PostMessage(Platform platform, Contact contact)
        {
            platform.PostMessage(contact);
        }
    }
}