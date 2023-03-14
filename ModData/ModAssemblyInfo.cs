using ChronoArkMod.ModData;
using ChronoArkMod.Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChronoArkMod.ModData
{
   
    public class ModAssemblyInfo
    {
        public ModInfo info;
        public Dictionary<string, Assembly> Assemblies = new Dictionary<string, Assembly>();
        public List<ChronoArkPlugin> Plugins = new List<ChronoArkPlugin>();
        public List<ModDefinition> ModDefinitions = new List<ModDefinition>();


        public ModAssemblyInfo(ModInfo modInfo)
        {
            info = modInfo;
            
        }
        public void UnLoad()
        {
            foreach(ChronoArkPlugin plugin in Plugins)
            {
                plugin.Dispose();
                UnityEngine.Debug.Log("Plugin from " + info.id + "[" + plugin.PluginName + "] Disposed");
            }
            foreach(ModDefinition mod in ModDefinitions)
            {
                mod.UnLoad();
            }
            ModDefinitions.Clear();
            Plugins.Clear();
            Assemblies.Clear();

        }
        public void LoadModDef()
        {
            foreach(ModDefinition mod in ModDefinitions)
            {
                mod.LoadAll();
            }
        }
        public void init()
        {
            UnLoad();
            Directory.CreateDirectory(Path.Combine(info.DirectoryName, "Assemblies"));
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "Assemblies"));
            foreach (FileInfo file in directoryInfo.GetFiles("*.dll"))
            {
                Assembly assembly = Assembly.LoadFrom(file.FullName);
                Assemblies.Add(file.Name, assembly);
                foreach(Type type in assembly.GetTypes())
                {
                    if (typeof(ChronoArkPlugin).IsAssignableFrom(type))
                    {
                        ChronoArkPlugin plugin = (ChronoArkPlugin)Activator.CreateInstance(type);
                        if (plugin != null)
                        {
                            plugin.Initialize();
                            plugin.ModId = info.id;
                            UnityEngine.Debug.Log("Plugin from " + info.id + "[" + plugin.PluginName + "] Initialized");
                        }
                        Plugins.Add(plugin);

                    }
                    if ((typeof(ModDefinition).IsAssignableFrom(type)))
                    {
                        ModDefinition mod = type.GetSingletonAs<ModDefinition>();
                        if(mod!=null)
                        {
                            mod.ModId = info.id;

                        }
                        ModDefinitions.Add(mod);
                    }
                }
            }
            //UpdateSaveManager PassiveCharTypes
            
        }
        
    }
}
