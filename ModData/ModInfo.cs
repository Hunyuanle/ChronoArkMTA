using System;
using System.Collections.Generic;
using ChronoArkMod.ModData.Settings;
using System.IO;
using System.Reflection;
using GameDataEditor;
using UnityEngine;
using ChronoArkMod.Plugin;
using I2.Loc.SimpleJSON;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Steamworks;

namespace ChronoArkMod.ModData
{
    public class ModInfo : IEquatable<ModInfo>
    {
        public string Author;
        public string Version;
        public string Description;
        public string id;
        public string Cover;
        public string CoverKey;
        public string DefaultAssetBundlePath;
        public List<string> TagList;
        public List<string> Dependencies;
        public List<SettingEntry> ModSettingEntries;
        public string DirectoryName;
        public string Title;
        public Dictionary<string, object> settings;
        public bool NeedRestartWhenSettingChanged;
        public bool NeedReloadAllWhenEnabled;
        public bool NeedRestartWhenEnabled;
        public static ModInfo Deserialize(string text)
        {
            ModInfo modInfo = new ModInfo();
            Dictionary<string, object> info_dict = Json.Deserialize(text) as Dictionary<string,object>;
            info_dict.TryGetString("id", out  modInfo.id);
            info_dict.TryGetString("Title", out modInfo.Title);
            info_dict.TryGetString("Author",out modInfo.Author);
            info_dict.TryGetString("Description",out modInfo.Description);
            info_dict.TryGetString("Version", out modInfo.Version);
            info_dict.TryGetString("Cover", out modInfo.Cover);
            info_dict.TryGetString("DefaultAssetBundlePath", out modInfo.DefaultAssetBundlePath);
            info_dict.TryGetStringList("TagList",out modInfo.TagList);
            info_dict.TryGetStringList("Dependencies", out modInfo.Dependencies);
            info_dict.TryGetBool("NeedRestartWhenSettingChanged", out modInfo.NeedRestartWhenSettingChanged);
            info_dict.TryGetBool("NeedReloadAllWhenEnabled", out modInfo.NeedReloadAllWhenEnabled);
            info_dict.TryGetBool("NeedRestartWhenEnabled", out modInfo.NeedRestartWhenEnabled);          
            info_dict.TryGetList("ModSettingEntries", out List<object> entry_infos);
            if(entry_infos == null)
            {
                return modInfo;
            }
            foreach(object entry_info in entry_infos)
            {
                Dictionary<string, object> entry_info_dict  = entry_info as Dictionary<string, object>;
                entry_info_dict.TryGetString("SettingType", out string SettingType);
                entry_info_dict.TryGetString("SettingKey", out string SettingKey);
                entry_info_dict.TryGetString("DisplayName",out string DisplayName);
                entry_info_dict.TryGetString("Description",out string Description);
                switch(SettingType)
                {
                    case "ToggleSetting":
                        entry_info_dict.TryGetBool("InitValue", out bool InitValue);
                        modInfo.ModSettingEntries.Add(new ToggleSetting(SettingKey,DisplayName,Description,InitValue,modInfo.id));
                        break;
                    case "SliderSetting":
                        entry_info_dict.TryGetInt("InitValue", out int InitValue2);
                        entry_info_dict.TryGetInt("Max",out int Max);
                        entry_info_dict.TryGetInt("Min",out int Min);
                        entry_info_dict.TryGetInt("StepSize", out int StepSize);
                        modInfo.ModSettingEntries.Add(new SliderSetting(SettingKey, DisplayName,Description, InitValue2, Max, Min, StepSize,modInfo.id));
                        break;
                    case "DropdownSetting":
                        entry_info_dict.TryGetInt("InitValue", out int InitValue3);
                        entry_info_dict.TryGetStringList("Options",out List<string> Options);
                        modInfo.ModSettingEntries.Add(new DropdownSetting(SettingKey, DisplayName, Description, InitValue3,modInfo.id,Options.ToArray()));
                        break;
                    case "InputFieldSetting":
                        entry_info_dict.TryGetString("InitValue", out string InitValue4);
                        modInfo.ModSettingEntries.Add(new InputFieldSetting(SettingKey, DisplayName, Description, InitValue4, modInfo.id));
                        break;
                }
            }
            return modInfo;
        }
        public void DeserializeSettingsToEntries(string textsettings)
        {
            settings = Json.Deserialize(textsettings) as Dictionary<string,object>;
            foreach(SettingEntry settingEntry in ModSettingEntries)
            {
                settingEntry.RestoreFromModSettings(settings);
            }
        }
        public string SerializeSettingsFromEntries()
        {
            foreach (SettingEntry settingEntry in ModSettingEntries)
            {
                settingEntry.SaveToModSettings(settings);
            }
            return Json.Serialize(settings);
        }



        public ModInfo()
        {
            this.ModSettingEntries = new List<SettingEntry>();
            this.Dependencies = new List<string>();
            this.TagList = new List<string>();
            this.settings = new Dictionary<string, object>();
        }
        ModAssetInfo _assetInfo;
        public ModAssetInfo assetInfo
        {
            get
            {
                if (_assetInfo == null)
                {
                    _assetInfo = new ModAssetInfo(this);
                }
                return _assetInfo;
            }
        }
        ModGDEInfo _gdeinfo;
        public ModGDEInfo gdeinfo
        {
            get
            {
                if (_gdeinfo == null)
                {
                    _gdeinfo= new ModGDEInfo(this);
                }
                return _gdeinfo;
            }
        }
        ModAudioInfo _audioinfo;
        public ModAudioInfo audioinfo
        {
            get
            {
                if (_audioinfo == null)
                {
                    _audioinfo = new ModAudioInfo(this);
                }
                return _audioinfo;
            }
        }
        ModAssemblyInfo _assemblyInfo;
        public ModAssemblyInfo assemblyInfo
        {
            get
            {
               if(_assemblyInfo == null)
               {
                    _assemblyInfo= new ModAssemblyInfo(this);
               }
               return _assemblyInfo;
            }
        }
        ModLocalizationInfo _localizationInfo;
        public ModLocalizationInfo localizationInfo
        {
            get
            {
                if (_localizationInfo == null)
                {
                    _localizationInfo= new ModLocalizationInfo(this);
                }
                return _localizationInfo;
            }
        }
        public void LoadAtVeryBegining()
        {
            assemblyInfo.init();
            assetInfo.init();
        }
        public void Load()
        {
            if (assemblyInfo.Assemblies.Count == 0)
            {
                LoadAtVeryBegining();
            }
            LoadGDE();
            audioinfo.init();
        }
        public void LoadGDE()
        {
            gdeinfo.init();
            assemblyInfo.LoadModDef();
            localizationInfo.init();
        }
        public void UnLoad()
        {
            assetInfo.UnLoad();
            gdeinfo.UnLoad();
            assemblyInfo.UnLoad();
            localizationInfo.UnLoad();
            audioinfo.UnLoad();


        }
        public void UpdateModInfo()
        {
            gdeinfo.UpdateSchemaKeyDict();
            localizationInfo.LocalizationUpdate();
        }
        public T Loadgdata<T>(string key,T value,T result)
        {
            try
            {
                if (gdeinfo.Add.Contains(key)||gdeinfo.Replace.Contains(key))
                {
                    return value;
                }
                
                return result;
            }
            catch
            {
                UnityEngine.Debug.Log(string.Format("Error {0} {1} {2}",key,value,result ));
                return result;
            }
           
        }
        public List<T> LoadgdataList<T>(string key,List<T> value, List<T> oldresult)
        {
            try
            {
                if (gdeinfo.Add.Contains(key) || gdeinfo.Replace.Contains(key))
                {
                    return value;
                }
                if (gdeinfo.AddItemToList.Contains(key))
                {
                    foreach (T item in value)
                    {
                        oldresult.Add(item);
                    }
                    return oldresult;
                }
                if (gdeinfo.AddItemToList.Contains(key))
                {
                    foreach (T item in value)
                    {
                        oldresult.Remove(item);
                    }
                    return oldresult;
                }
                return oldresult;
            }
            catch
            {
                UnityEngine.Debug.Log(string.Format("Error {0} {1} {2}", key, value, oldresult));
                return oldresult;
            }

        }
        public List<T> ModGdataGetList<T>(string key, string field, List<T> oldresult)
        {
            List<T> value = new List<T>();
            try
            {
                if (gdeinfo.gdatas.ContainsKey(key))
                {
                    Dictionary<string, object> dict = gdeinfo.gdatas[key] as Dictionary<string, object>;
                    if (dict.ContainsKey(field))
                    {
                        if(((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<object>)!= null){
                            value = ((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<object>).ConvertAll((object x) => (T)x);
                        }
                        else
                        {
                            value = (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<T>;
                        }
                        
                        for (int i = 0; i < value.Count; i++)
                        {
                            value[i] = ChangeModValue(value[i]);
                        }
                        (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = value;
                        return LoadgdataList(key, value, oldresult);


                    }

                }
            }
            catch { }
            return oldresult;

        }
        public bool GetBool(string key, string field, bool defaultVal)
        {
            bool result = defaultVal;
            try
            {

            
                object value;
                if (gdeinfo.gdatas.TryGetFromKeyField(key,field,out value))
                {
                    result = Convert.ToBoolean(value);
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            return result;
        }
       
        public float GetFloat(string key, string field, float defaultVal)
        {
            float result = defaultVal;
            try
            {
                object value;
                if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out value))
                {
                    result = float.Parse(value.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            return result;
        }
        public int GetInt(string key, string field, int defaultVal)
        {
            int result = defaultVal;
            try
            {
                object value;
                if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out value))
                {
                    result = Convert.ToInt32(value);
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            return result;
        }
        public  List<int> GetIntList(string key, string field, List<int> defaultVal = null)
        {
            List<int> result = defaultVal;
            try
            {
                object obj;
                if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out obj))
                {
                    
                    List<int> newresult = (obj as List<object>).ConvertAll<int>((object obj2) => Convert.ToInt32(obj2));
                    result = LoadgdataList(key, newresult, result);
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            return result;
        }
        public string GetString(string key, string field, string defaultVal)
        {
            string result = defaultVal;
            try
            {
                object obj;
                if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out obj) && obj != null)
                {
                    result = obj.ToString();
                    if (UpdateModTypeName(ref result))
                    {
                        (gdeinfo.gdatas[key] as Dictionary<string,object>)[field] = result;
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            return result;
        }
        public bool UpdateModTypeName(ref string value)
        {
           
            if (value.Contains(".") && !value.Contains("PublicKeyToken="))
            {
                foreach (Assembly assembly in assemblyInfo.Assemblies.Values)
                {
                    Type type = assembly.GetType(value);
                    if (type != null)
                    {
                        value = type.AssemblyQualifiedName;
                        return true;
                    }
                }
            }
            return false;
        }
        public List<string> GetStringList(string key, string field, List<string> defaultVal = null)
        {
            List<string> result = defaultVal;
            try
            {
                object obj;
                if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out obj))
                {

                    if(obj != null)
                    {
                        List<string> newresult = new List<string>();
                        if (obj as List<object> != null)
                        {
                            newresult = (obj as List<object>).ConvertAll<string>((object obj2) => obj2.ToString()); ;
                            

                        }
                        if(obj as List<string> != null)
                        {
                            newresult = (obj as List<string>);
                        }
                        bool needchange = false;
                        for (int i = 0; i < newresult.Count; i++)
                        {
                            string temp = newresult[i];
                            if (UpdateModTypeName(ref temp))
                            {
                                newresult[i] = temp;
                                needchange = true;
                            }
                        }
                        if (needchange)
                        {
                            (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = newresult;
                        }
                        result = LoadgdataList(key, newresult, result);
                        
                    }
                    
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            return result;
        }
        public  List<List<string>> GetStringTwoDList(string key, string field, List<List<string>> defaultVal = null)
        {
            List<List<string>> result = defaultVal;
            try
            {
                object obj;
                if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out obj))
                {
                    List<object> temp = (obj as List<object>);
                    List<List<string>> value2 = new List<List<string>>();
                    foreach (object obj2 in result)
                    {
                        List<string> item = (obj2 as List<object>).ConvertAll<string>((object obj3) => obj3.ToString());
                        value2.Add(item);
                    }
                    return value2;
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            return result;
        }
        public Vector2 GetVector2(string key, string field, Vector2 defaultVal)
        {
            Vector2 result = defaultVal;
            try
            {
                object obj;
                if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out obj))
                {
                    Dictionary<string, object> dictionary2 = obj as Dictionary<string, object>;
                    if (dictionary2 != null)
                    {
                        result.x = Convert.ToSingle(dictionary2["x"]);
                        result.y = Convert.ToSingle(dictionary2["y"]);
                    }
                    if(obj is Vector2)
                    {
                        result = (Vector2)obj;
                    }

                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            return result;
        }
        public Vector3 GetVector3(string key, string field, Vector3 defaultVal)
        {
            Vector3 result = defaultVal;
            try
            {
                object obj;
                if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out obj))
                {
                    if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out obj))
                    {
                        Dictionary<string, object> dictionary2 = obj as Dictionary<string, object>;
                        if (dictionary2 != null)
                        {
                            result.x = Convert.ToSingle(dictionary2["x"]);
                            result.y = Convert.ToSingle(dictionary2["y"]);
                            result.z = Convert.ToSingle(dictionary2["z"]);
                        }
                        if (obj is Vector3)
                        {
                            result = (Vector3)obj;
                        }

                    }
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            return result;
        }
        public List<Vector3> GetVector3List(string key, string field, List<Vector3> defaultVal = null)
        {
            List<Vector3> result = defaultVal;
            try
            {
                object obj;
                if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out obj))
                {
                    List<Vector3> newresult =  new List<Vector3>();
                    foreach (object obj2 in obj as List<object>)
                    {
                        Dictionary<string, object> dictionary2 = obj2 as Dictionary<string, object>;
                        Vector3 item = default(Vector3);
                        if (dictionary2 != null)
                        {
                            dictionary2.TryGetFloat("x", out item.x, "");
                            dictionary2.TryGetFloat("y", out item.y, "");
                            dictionary2.TryGetFloat("z", out item.z, "");
                        }
                        if (obj2 is Vector3)
                        {
                            item = (Vector3)obj2;
                        }
                        newresult.Add(item);
                    }
                    result = LoadgdataList(key, newresult, result);
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            return result;
        }
        public static List<string> GetSpriteListPath(string key, string field,List<string> defaultVal)
        {
            List<string> result = defaultVal;
            foreach (string modid in ModManager.LoadedMods)
            {
                ModInfo modinfo = ModManager.getModInfo(modid);

                result = modinfo.ModGdataGetList(key, field, result);
            }
            return result;
        }
        public static string GetSpritePath(string key, string field, string defaultVal)
        {
            string result = defaultVal;
            foreach (string modid in ModManager.LoadedMods)
            {
                ModInfo modinfo = ModManager.getModInfo(modid);

                result = modinfo.ModSpriteGet(key, field, result);
            }
            return result;

        }
        public string ModSpriteGet(string key, string field, string oldresult)
        {
            string value;
            try
            {
                if (gdeinfo.gdatas.ContainsKey(key))
                {
                    Dictionary<string, object> dict = gdeinfo.gdatas[key] as Dictionary<string, object>;
                    if (dict.ContainsKey(field))
                    {
                        value = (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as string;
                        bool isSkill = false;
                        if (field == "Image_1" || field == "Image_2")
                        {
                            isSkill = true;
                        }
                        value = ChangeModValueSprite(value, isSkill);
                        (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = value;
                        value = Loadgdata(key, value, oldresult);
                        return value;
                    }

                }
            }
            catch { }
            return oldresult;

        }
        public List<string> ModSpriteListGet(string key, string field, List<string> oldresult)
        {
            List<string> value = new List<string>();
            try
            {
                if (gdeinfo.gdatas.ContainsKey(key))
                {
                    Dictionary<string, object> dict = gdeinfo.gdatas[key] as Dictionary<string, object>;
                    if (dict.ContainsKey(field))
                    {
                        if (((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<object>) != null)
                        {
                            value = ((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<object>).ConvertAll((object x) => x.ToString());
                        }
                        else
                        {
                            value = (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<string>;
                        }

                        for (int i = 0; i < value.Count; i++)
                        {
                            value[i] = ChangeModValueSprite(value[i]);
                        }
                        (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = value;
                        return LoadgdataList(key, value, oldresult);


                    }

                }
            }
            catch { }
            return oldresult;

        }
        public static List<string> GetGameObjectListPath(string key, string field, List<string> defaultVal)
        {
            List<string> result = defaultVal;
            foreach (string modid in ModManager.LoadedMods)
            {
                ModInfo modinfo = ModManager.getModInfo(modid);

                result = modinfo.ModGdataGetList(key, field, result);
            }
            return result;
        }
        public static string GetGameObjectPath(string key, string field, string defaultVal)
        {
            string result = defaultVal;
            foreach (string modid in ModManager.LoadedMods)
            {
                ModInfo modinfo = ModManager.getModInfo(modid);

                result = modinfo.ModGameObjectGet(key, field, result);
            }
            return result;

        }
        public string ModGameObjectGet(string key, string field, string oldresult)
        {
            string value;
            try
            {
                if (gdeinfo.gdatas.ContainsKey(key))
                {
                    Dictionary<string, object> dict = gdeinfo.gdatas[key] as Dictionary<string, object>;
                    if (dict.ContainsKey(field))
                    {
                        value = (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as string;
                        bool isSkill = false;
                        if (field == "Image_1" || field == "Image_2")
                        {
                            isSkill = true;
                        }
                        value = ChangeModValueGameObject(value);
                        (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = value;
                        value = Loadgdata(key, value, oldresult);
                        return value;
                    }

                }
            }
            catch { }
            return oldresult;

        }
        public List<string> ModGameObjectListGet(string key, string field, List<string> oldresult)
        {
            List<string> value = new List<string>();
            try
            {
                if (gdeinfo.gdatas.ContainsKey(key))
                {
                    Dictionary<string, object> dict = gdeinfo.gdatas[key] as Dictionary<string, object>;
                    if (dict.ContainsKey(field))
                    {
                        if (((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<object>) != null)
                        {
                            value = ((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<object>).ConvertAll((object x) => x.ToString());
                        }
                        else
                        {
                            value = (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<string>;
                        }

                        for (int i = 0; i < value.Count; i++)
                        {
                            value[i] = ChangeModValueGameObject(value[i]);
                        }
                        (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = value;
                        return LoadgdataList(key, value, oldresult);


                    }

                }
            }
            catch { }
            return oldresult;

        }
        public string ChangeModValueSprite(string value, bool isSkill = false)
        {

            try
            {

                string temp = value;


                if (temp.EndsWith(".png"))
                {
                    if (File.Exists(Path.Combine(assetInfo.AssetDirectory, temp)))
                    {
                        temp = assetInfo.ImageFromFile(temp);
                    }
                    else
                    {
                        if (!DefaultAssetBundlePath.IsNullOrEmpty())
                        {
                            temp = assetInfo.ImageFromAsset(DefaultAssetBundlePath, temp);
                        }


                    }
                    if (isSkill)
                    {
                        temp = assetInfo.SkillImageResize(temp);
                    }
                }

                return temp;
            }
            catch { }
            return value;

        }
        public string ChangeModValueGameObject(string value)
        {

            try
            {

                string temp = value;


                if (temp.EndsWith(".prefab"))
                {
                    if (!DefaultAssetBundlePath.IsNullOrEmpty())
                        temp = assetInfo.ObjectFromAsset<GameObject>(DefaultAssetBundlePath, temp);
                }

                return temp;
            }
            catch { }
            return value;

        }
        public T ModGdataGet<T>(string key, string field, T oldresult)
        {
            T value;
            try
            {
                if (gdeinfo.gdatas.ContainsKey(key))
                {
                    Dictionary<string, object> dict = gdeinfo.gdatas[key] as Dictionary<string, object>;
                    if (dict.ContainsKey(field))
                    {
                        value = (T)(gdeinfo.gdatas[key] as Dictionary<string, object>)[field];
                        bool isSkill = false;
                        if (field == "Image_1" || field == "Image_2")
                        {
                            isSkill = true;
                        }
                        value = ChangeModValue<T>(value, isSkill);
                        (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = value;
                        value = Loadgdata<T>(key, value, oldresult);
                        return value;
                    }

                }
            }
            catch { }
            return oldresult;

        }
        
        
        public T ChangeModValue<T>(T value, bool isSkill = false)
        {
            if (typeof(T) != typeof(string)){
                return value;
            }
            try
            {
                if (!(value is string))
                {
                    return value;
                }
                string temp = value as string;
                
                
                if (temp.EndsWith(".png"))
                {
                    if (File.Exists(Path.Combine(assetInfo.AssetDirectory, temp)))
                    {
                        temp = assetInfo.ImageFromFile(temp);
                    }
                    else
                    {
                        if (!DefaultAssetBundlePath.IsNullOrEmpty())
                        {
                            temp = assetInfo.ImageFromAsset(DefaultAssetBundlePath, temp);
                        }
                       

                    }
                    if (isSkill)
                    {
                        temp = assetInfo.SkillImageResize(temp);
                    }
                }

                else if (temp.EndsWith(".prefab"))
                {
                    if (!DefaultAssetBundlePath.IsNullOrEmpty())
                        temp = assetInfo.ObjectFromAsset<GameObject>(DefaultAssetBundlePath, temp);
                }
                
                return (T)(temp as object);
            }
            catch { }
            return value;

        }
        public void Upload()
        {
        }


        public bool Equals(ModInfo other)
        {
            return this.id.Equals(other.id);
        }


        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public string GetVersionString()
        {
            return Version;
        }

       


    }
}


