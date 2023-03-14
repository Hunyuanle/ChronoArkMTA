using ChronoArkMod.ModData;
using ChronoArkMod.Plugin;
using GameDataEditor;
using Newtonsoft.Json;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using UnityEngine;
using TileTypes;
namespace ChronoArkMod
{
    public static class ModManager
    {
        public static List<string> EnabledMods = new List<string>();
        public static List<string> LoadedMods = new List<string>();
        private static Dictionary<string, ModInfo> Mods = new Dictionary<string, ModInfo>();
        public static List<string> AllModIDs => Mods.Keys.ToList();
        public static List<ModInfo> AllMods => Mods.Values.ToList();
        public static ModInfo getModInfo(string id)
        {
            Mods.TryGetValue(id, out var info);
            return info;
        }
        public class ModSettingSave
        {
            public List<string> enabled_Mods = new List<string>();
        }
        public static void Init()//Run after SteamManager and SaveManager initate, before gdata is loaded
        {
            configPath = Application.persistentDataPath + "/modsettings.json";
                       Mods = new Dictionary<string, ModInfo>();
            LoadedMods = new List<string>();
            EnabledMods = new List<string>();
            UpdateModList();
            //LoadModsAtVeryBegining();
            EnabledMods = Mods.Keys.ToList();
            SaveModSettings();
            LoadAllEnabledAtStarting();
            MakeSaveType();
        }
        public static void LoadAllEnabledAtStarting()//Run after official gdata is loaded
        {
            List<string> loadedmods = new List<string>();
            loadedmods.AddRange(LoadedMods);
            foreach (string Modid in loadedmods)
            {
                UnLoadMod(Mods[Modid]);
            }
            foreach (string Modid in EnabledMods)
            {
                LoadMod(Mods[Modid]);
            }
        }
        public static string configPath;
        public static void UpdateModList()
        {
            Mods.Clear();
            EnabledMods.Clear();
            ReadWorkShopMods();
            ReadLocalMods();
            if (File.Exists(configPath))
            {
                string text = File.ReadAllText(configPath);
                ModSettingSave save = JsonConvert.DeserializeObject<ModSettingSave>(text);
                EnabledMods.Clear();
                EnabledMods.AddRange(save.enabled_Mods);
                foreach(string modid in save.enabled_Mods)
                {
                    if (!Mods.ContainsKey(modid))
                    {
                        EnabledMods.Remove(modid);
                    }
                }
                


            }
            else
            {

            }
            ModManager.SaveModSettings();


        }
        public static string GetModRootFolder()
        {
            return Application.dataPath + "/StreamingAssets/Mod";
        }
        public static string GetWorkShopFolder()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
            string path = directoryInfo.FullName.PathFix().Replace("common/Chrono Ark/ChronoArk_Data", "workshop/content/1188930");
            Directory.CreateDirectory(path);
            return path;
        }
        private static string CheckDirectory(string path)
        {
            bool flag = !Directory.Exists(path);
            if (flag)
            {
                Directory.CreateDirectory(path);
            }
            return path.PathFix();
        }
        private const string mod_filename = "ChronoArkMod.json";
        private const string setting_filename = "settings.json";
        private static void ReadLocalMods()
        {
            string[] directories = Directory.GetDirectories(GetModRootFolder());
            foreach (string directory in directories)
            {
                string modConfigPath = Path.Combine(directory, mod_filename);
                string modSettingPath = Path.Combine(directory, setting_filename);
                bool flag = !File.Exists(modConfigPath);
                if (!flag)
                {
                    ModInfo modInfo = ReadModInfo(modConfigPath, modSettingPath);
                    if (modInfo != null)
                    {
                        if (modInfo.id.IsNullOrEmpty())
                        {
                            modInfo.id = (new DirectoryInfo(directory)).Name;
                        }
                        Mods[modInfo.id] = modInfo;
                        modInfo.DirectoryName = directory;
                    }
                }
            }

        }
        private static void LoadModsAtVeryBegining()
        {
            foreach (string Modid in EnabledMods)
            {
                Mods[Modid].LoadAtVeryBegining();
            }
        }
        private static bool IsItemStateActive(EItemState currItemState, EItemState checkingState)
        {
            return checkingState == (currItemState & checkingState);
        }
        public static void ReadWorkShopMods()
        {
            try
            {
                string[] directories = Directory.GetDirectories(GetWorkShopFolder());
                foreach (string directory in directories)
                {
                    string modConfigPath = Path.Combine(directory, mod_filename);
                    string modSettingPath = Path.Combine(directory, setting_filename);
                    bool flag = !File.Exists(modConfigPath);
                    if (!flag)
                    {
                        ModInfo modInfo = ReadModInfo(modConfigPath, modSettingPath);
                        if (modInfo != null)
                        {
                            if (modInfo.id.IsNullOrEmpty())
                            {
                                modInfo.id = (new DirectoryInfo(directory)).Name;
                            }
                            Mods[modInfo.id] = modInfo;
                            modInfo.DirectoryName = directory;
                        }
                    }
                }
            }
            catch { }
            

        }
        public static ModInfo ReadModInfo(string configPath, string modSettingsPath)
        {
            string fileText = File.ReadAllText(configPath);

            ModInfo modInfo = ModInfo.Deserialize(fileText);
            modInfo.DirectoryName = Path.GetDirectoryName(configPath);


            if (File.Exists(modSettingsPath))
            {
                string text = File.ReadAllText(modSettingsPath);
                modInfo.DeserializeSettingsToEntries(text);

            }
           

            return modInfo;
        }
        private static void LoadMod(ModInfo modInfo)
        {
            Debug.Log("Start loading mod " + modInfo.id);
            bool flag = ModManager.LoadedMods.Contains(modInfo.id);
            if (flag)
            {
                throw new Exception(string.Format("Mod named {0} is already loaded.", modInfo.id));
                
            }
            modInfo.Load();
            LoadedMods.Add(modInfo.id);
            foreach (ChronoArkPlugin plugin in modInfo.assemblyInfo.Plugins)
            {
                plugin.OnModLoaded();
            }
            Debug.Log(modInfo.id+" Loaded");
        }
        private static void UnLoadMod(ModInfo modInfo)
        {
            Debug.Log("Start unloading mod " + modInfo.id);
            
            modInfo.UnLoad();
            LoadedMods.Remove(modInfo.id);
            
           
        }
        public static bool IsModEnabled(string modId)
        {
            return ModManager.EnabledMods.Contains(modId);
        }
        public static void SetModEnabled(string modId, bool isEnabled)
        {
            if (isEnabled)
            {
                if (!ModManager.IsModEnabled(modId))
                {
                    Debug.LogWarning("Mod " + modId.ToString() + " is being enabled a second time.");
                }
                else
                {
                    ModManager.EnabledMods.Add(modId);
                }
            }
            else
            {
                ModManager.EnabledMods.Remove(modId);
            }
        }
        public static void CheckEnabled(out bool needReLoadAll,out bool needRestart,out bool invalid )
        {
            needReLoadAll = false;
            needRestart = false;
            foreach(string id in EnabledMods)
            {
                if (Mods[id].NeedRestartWhenEnabled)
                {
                    needRestart = true;
                }
                if (Mods[id].NeedReloadAllWhenEnabled)
                {
                    needReLoadAll = true;
                }
            }
            invalid= false;
            for(int i = 0; i < EnabledMods.Count; i++)
            {
                foreach(string dependency in Mods[EnabledMods[i]].Dependencies)
                {
                    bool NowModInvalid = true;
                    for(int j=0;j<i;j++)
                    {
                        if(dependency == EnabledMods[0])
                        {
                            NowModInvalid = false; break;
                        }
                    }
                    if (NowModInvalid)
                    {
                        invalid = true; break;
                    }
                }
                if (invalid)
                {
                    break;
                }
            }
        }
        public static void SaveModSettings()
        {
            ModSettingSave save = new ModSettingSave();
            save.enabled_Mods = EnabledMods;
            string text = JsonConvert.SerializeObject(save);
            File.WriteAllText(configPath, text);
            /*
            foreach (ModInfo modInfo in Mods.Values)
            {
                string modPath = Path.Combine(modInfo.DirectoryName,setting_filename);
                string setting =  modInfo.SerializeSettingsFromEntries();
                File.WriteAllText(modPath, setting);
            }*/
        }
        public static void ModStatChanged(bool needreloadall = false)
        {

            List<string> loadedmods = new List<string>();
            loadedmods.AddRange(LoadedMods);
            foreach(string Modid in loadedmods)
            {
                if (!EnabledMods.Contains(Modid)||needreloadall)
                {
                    UnLoadMod(Mods[Modid]);
                   
                }
            }
            foreach(string Modid in EnabledMods)
            {
                if(!loadedmods.Contains(Modid)||needreloadall)
                {
                    LoadMod(Mods[Modid]);
                }
            }

            try
            {
                UpdateModInfo();
            }
            catch { }


        }
        public static Type GetType(string NameSpacePrefix, string typename)
        {
            if (string.IsNullOrEmpty(typename))
            {
                return null;
            }
            Type t = typeof(SaveManager).Assembly.GetType(NameSpacePrefix + typename);
            if (t == null)
            {
                t = Type.GetType(typename);

            }
            return t;
        }
        public static Type GetType(string typename)
        {
            if (string.IsNullOrEmpty(typename))
            {
                return null;
            }
            return GetType("", typename);

          
        }
        public static void MakeSaveType()
        {
            List<Type> types = new List<Type>();
            types.AddRange(typeof(SaveManager).Assembly.GetTypes());
            foreach(string id in LoadedMods)
            {
                foreach(Assembly assembly in Mods[id].assemblyInfo.Assemblies.Values)
                {
                    types.AddRange(assembly.GetTypes());
                }
            }
            List<Type> list = (from t in types
                               where t.BaseType == typeof(Passive_Char) || t.BaseType == typeof(EquipBase) || t.BaseType == typeof(ItemEnchant) ||
                               t.BaseType == typeof(EquipCurse) || t.BaseType == typeof(BaseEventClass) || t.BaseType == typeof(TileType)
                               || t.BaseType == typeof(SpecialRule) || t.BaseType == typeof(Boss) || t.BaseType == typeof(Border) ||
                               t.BaseType == typeof(ItemEvent) || t.BaseType == typeof(BlockEvent) || t.BaseType == typeof(RandomEventBaseScript)
                               || t.BaseType == typeof(Stat) || t.BaseType == typeof(ItemBase)
                               select t).ToList<Type>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == "Buff" || list[i].Name == "EquipBase" || list[i].Name == "Skill_Extended")
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            typeof(SaveManager).GetField("PassiveCharTypes", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(SaveManager.savemanager, list.ToArray());
        }
        public static void UpdateModInfo()
        {
           
            foreach (string Modid in LoadedMods)
            {
                Mods[Modid].UpdateModInfo();
            }
            MakeSaveType();
            GDEDataManager.BuildDataKeysBySchemaList();
            SaveManager.savemanager.StartCoroutine(DataBaseInit());
        }
        public static IEnumerator<object> DataBaseInit()
        {
            PlayData.DataBaseInit();
            yield return null;
        }
    }
}
