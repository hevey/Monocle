using System.Collections.Generic;
using Monocle.Shared.Models;

namespace Monocle.Shared.Services
{
    public interface IPlatformService
    {
        List<Platform> ConfiguredPlatforms();

        Platform? FindPlatform(int id);
        void PostMessage(Platform platform, Contact contact);
        List<Contact> GetMessages(Platform platform);
    }
}