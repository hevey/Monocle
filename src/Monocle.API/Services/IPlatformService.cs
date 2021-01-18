using System.Collections.Generic;
using Monocle.API.Models;

namespace Monocle.API.Services
{
    public interface IPlatformService
    {
        List<Platform> ConfiguredPlatforms();

        Platform? FindPlatform(int id);
        void PostMessage(Platform platform, Contact contact);
    }
}