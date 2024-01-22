using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSCounter.Config
{
    class Config
    {
        public static void init(BepInEx.Configuration.ConfigFile Config)
        {
            // init sections
            General.init(Config);
            PersistantCounter.init(Config);
        }
    }
}
