using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoArkMod.Plugin
{
    public class PluginConfig : Attribute
    {
        public PluginConfig(string pluginName, string creatorId, string pluginVersion)
        {
            this.Name = pluginName;
            this.CreatorId = creatorId;
            this.Version = pluginVersion;
        }
        public string Name;
        public string CreatorId;
        public string Version;
    }
}
