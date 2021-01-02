using System.Collections.Generic;
using Monocle.Models;

namespace Monocle.Services
{
    public interface IPlatformService
    {
        List<Platform> ConfiguredPlatforms();

        Platform? FindPlatform(int id);
        void PostMessage(Platform platform, Contact contact);
    }
}