using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoArkMod.Plugin
{
    public abstract class ChronoArkPlugin
    {
       

       
        public abstract void Initialize();
        public abstract void Dispose();
        public virtual void OnModSettingUpdate()
        {
        }
        public virtual void OnModLoaded()
        {
        }


        public string ModId { get; internal set; }
        public ChronoArkPlugin()
        {
            Type type = base.GetType();
            Type typeFromHandle = typeof(PluginConfig);
            object[] customAttributes = type.GetCustomAttributes(typeFromHandle, false);
            bool flag = customAttributes.Length != 1;
            if (flag)
            {
                throw new Exception(" Plugin entry class must have the ChronoArkMod.Plugins.ChronoArkPlugin attribute.");
            }
            PluginConfig pluginConfig = (PluginConfig)customAttributes[0];
            this.PluginName = pluginConfig.Name;
            this.CreatorId = pluginConfig.CreatorId;
            this.PluginVersion = pluginConfig.Version;
        }
        public string GetGuid()
        {
            return "ChronoArkMod.Plugin." + this.CreatorId + "." + this.PluginName;
        }
        public readonly string PluginName;

        public readonly string CreatorId;

        public readonly string PluginVersion;
    }
}
