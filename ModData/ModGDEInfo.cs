using ChronoArkMod.ModData;
using ChronoArkMod.Plugin;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChronoArkMod.ModData
{
    public class ModGDEInfo
    {
        public ModInfo info;
        public Dictionary<string, object> gdatas = new Dictionary<string, object>();
        public List<string> Add = new List<string>();
        public List<string> Replace = new List<string>();
        public List<string> AddItemToList = new List<string>();
        public List<string> RemoveItemFromList = new List<string>();
        public List<string> Remove = new List<string>();
        public Dictionary<string,string> key_schema = new Dictionary<string, string>();
        public Dictionary<string,object> Removed= new Dictionary<string,object>();
        public enum LoadingType
        {
            Add, Replace, AddItemToList, RemoveItemFromList
        }
        
        public ModGDEInfo(ModInfo modinfo) 
        { 
            info= modinfo;
        }
        public void init()
        {
            Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata"));

            UnLoad();
            LoadAdd();
            LoadRemove();
            LoadReplace();
            LoadAddList();
            LoadRemoveList();
            //UpdateSchemaKeyDict();


        }
        public void UnLoad()
        {
            foreach(string key in Add)
            {
                if (GDEDataManager.masterData != null)
                {
                    GDEDataManager.masterData.Remove(key);
                }
               
            }
            foreach(string key in Removed.Keys)
            {
                GDEDataManager.masterData.TryAddOrUpdateValue(key, Removed[key]);
            }
            Removed.Clear();
            Add.Clear();
            Remove.Clear();
            Replace.Clear();
            AddItemToList.Clear();
            RemoveItemFromList.Clear();
            gdatas.Clear();
            key_schema.Clear();
        }
        public void UpdateSchemaKeyDict()
        {
            foreach (string key in Add)
            {

                string Schema = key_schema[key];
                if(GDEDataManager.Get(GDMConstants.SchemaPrefix +Schema, out Dictionary<string, object> defaultgdata))
                {
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    dict.Merge(defaultgdata);
                    dict.TryAddOrUpdateValue(GDMConstants.SchemaKey,Schema);
                    GDEDataManager.masterData.TryAddOrUpdateValue(key,dict);
                }

            }
            foreach(string key in Remove)
            {
                if (GDEDataManager.masterData.ContainsKey(key))
                {
                    Removed.TryAddOrUpdateValue(key, GDEDataManager.masterData[key]);
                }
                GDEDataManager.masterData.Remove(key);
            }
            
        }
        void LoadAdd()
        {
            Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata", "Add"));
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "gdata", "Add"));
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (FileInfo file in directoryInfo.GetFiles("*.json"))
            {
                string text = File.ReadAllText(file.FullName);
                dict.Merge(Json.Deserialize(text) as Dictionary<string, object>);
            }
            gdatas.Merge(dict);
            foreach(string key in dict.Keys)
            {
                try
                {
                    Add.Add(key);
                    key_schema.Add(key, (dict[key] as Dictionary<string, object>)["_gdeSchema"] as string);
                }
                catch
                {
                    UnityEngine.Debug.Log(key);
                }
            }
        }
        void LoadRemove()
        {
            Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata", "Remove"));
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "gdata", "Remove"));
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (FileInfo file in directoryInfo.GetFiles("*.json"))
            {
                string text = File.ReadAllText(file.FullName);
                dict.Merge(Json.Deserialize(text) as Dictionary<string, object>);
            }
            
            foreach (string key in dict.Keys)
            {
                Remove.Add(key);
            }
        }
        void LoadReplace()
        {
            Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata", "Replace"));
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "gdata", "Replace"));
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (FileInfo file in directoryInfo.GetFiles("*.json"))
            {
                string text = File.ReadAllText(file.FullName);
                dict.Merge(Json.Deserialize(text) as Dictionary<string, object>);
            }
            gdatas.Merge(dict);
            foreach (string key in dict.Keys)
            {
                Replace.Add(key);
                key_schema.Add(key, (dict[key] as Dictionary<string, object>)["_gdeSchema"] as string);

            }
        }
        void LoadAddList()
        {
            Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata", "AddItemToList"));
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "gdata", "AddItemToList"));
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (FileInfo file in directoryInfo.GetFiles("*.json"))
            {
                string text = File.ReadAllText(file.FullName);
                dict.Merge(Json.Deserialize(text) as Dictionary<string, object>);
            }
            gdatas.Merge(dict);
            foreach (string key in dict.Keys)
            {
                AddItemToList.Add(key);
                key_schema.Add(key, (dict[key] as Dictionary<string, object>)["_gdeSchema"] as string);
            }
        }
        void LoadRemoveList()
        {
            Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata", "RemoveItemFromList"));
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "gdata", "RemoveItemFromList"));
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (FileInfo file in directoryInfo.GetFiles("*.json"))
            {
                string text = File.ReadAllText(file.FullName);
                dict.Merge(Json.Deserialize(text) as Dictionary<string, object>);
            }
            gdatas.Merge(dict);
            foreach (string key in dict.Keys)
            {
                RemoveItemFromList.Add(key);
                key_schema.Add(key, (dict[key] as Dictionary<string, object>)["_gdeSchema"] as string);
            }
        }


        public static string GetStringAsset(string key, string field, string defaultVal)
        {
            string result = defaultVal;
            foreach (string modid in ModManager.LoadedMods)
            {
                ModInfo modinfo = ModManager.getModInfo(modid);
                
                result = modinfo.ModGdataGet(key, field, result) as string;
            }
            try
            {

                Dictionary<string, object> dictionary;
                object value;
                if (GDEDataManager.ModifiedData.TryGetValue(key, out dictionary) && dictionary.ContainsKey(field) && dictionary.TryGetValue(field, out value))
                {
                    result = value.ToString();
                }

            }
            catch (Exception exception)
            {
                UnityEngine.Debug.LogException(exception);
            }
            return result;
        }
        public static List<string> GetStringAssetList(string key, string field, List<string> defaultVal)
        {
            List<string> result = defaultVal;
            foreach (string modid in ModManager.LoadedMods)
            {
                ModInfo modinfo = ModManager.getModInfo(modid);

                result = modinfo.ModGdataGetList(key, field, result);
            }
            try
            {

                Dictionary<string, object> dictionary;
                object value;
                if (GDEDataManager.ModifiedData.TryGetValue(key, out dictionary) && dictionary.ContainsKey(field) && dictionary.TryGetValue(field, out value))
                {
                    result = value as List<string>;
                }

            }
            catch (Exception exception)
            {
                UnityEngine.Debug.LogException(exception);
            }
            return result;
        }




    }
}
