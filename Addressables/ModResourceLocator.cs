using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.ResourceManagement.Util;
using UnityEngine.U2D;
using UnityEngine;
using UnityEngine.AddressableAssets.ResourceLocators;
using ChronoArkMod.ModData;
using Steamworks;
using GameDataEditor;
using System.Collections;

namespace ChronoArkMod.Addressable
{
    public class ModResourceLocator_Image:IResourceLocator
    {
        public string LocatorId
        {
            get
            {
                return nameof(ModResourceLocator_Image)+info.id;
            }
        }
        public virtual IEnumerable<object> Keys
        {
            get
            {
                return new object[0];
            }
        }
       
        public ModResourceLocator_Image(string id)
        {
            this.id = id;
            this.Seed = UnityEngine.Random.Range(0, int.MaxValue);
        }
        string id;
        int Seed;
        ModInfo info => ModManager.getModInfo(id);
        public bool Locate(object key, Type type, out IList<IResourceLocation> locations)
        {
            locations = new List<IResourceLocation>();
            if(key is string)
            {
                string path = (string)key;
               
                if (typeof(Sprite).IsAssignableFrom(type)||typeof(Texture2D).IsAssignableFrom(type))
                {
                    if(info.assetInfo.ModImageInfos.ContainsKey(path))
                    {
                        ResourceLocationBase loc = new ResourceLocationBase("ModImage", path+Seed, typeof(ModResourceProvider_Image).FullName + info.id, type);
                        loc.Data = info.assetInfo.ModImageInfos[path];
                        locations = new List<IResourceLocation> {loc };
                    
                        return true;
                    }
                    
                }
            }
            return false;
        }

       
    }
    public class ModResourceLocator_Object : IResourceLocator
    {
        public string LocatorId
        {
            get
            {
                return nameof(ModResourceLocator_Object) + info.id;
            }
        }
        public virtual IEnumerable<object> Keys
        {
            get
            {
                return new object[0];
            }
        }

        public ModResourceLocator_Object(string id)
        {
            this.id = id;
            this.Seed = UnityEngine.Random.Range(0, int.MaxValue);
        }
        string id;
        int Seed;
        ModInfo info => ModManager.getModInfo(id);
        public bool Locate(object key, Type type, out IList<IResourceLocation> locations)
        {
            locations = new List<IResourceLocation>();
            
            if (key is string)
            {
                
                string path = (string)key;
               
                if (info.assetInfo.ModObjectInfos.ContainsKey(path))
                {
                    ResourceLocationBase loc = new ResourceLocationBase("ModObject", path+Seed, typeof(ModResourceProvider_Object).FullName + info.id, type);
                    loc.Data = info.assetInfo.ModObjectInfos[path];
                    Type ty = loc.Data.GetType().GetGenericArguments()[0];
                    if(ty.IsAssignableFrom(type))
                    {
                        locations = new List<IResourceLocation> { loc };
                        return true;
                    }



                    return false;
                }
            }
            return false;
        }

        public static List<T> GetCustomList<T>(string key, string field, List<T> defaultVal) where T : IGDEData
        {
            List<T> list = defaultVal;
            try
            {
                Dictionary<string, object> dictionary;
                if(HasKeyField(key,field))
                //if (GDEDataManager.ModifiedData.TryGetValue(key, out dictionary) && dictionary.ContainsKey(field))
                {
                    list = new List<T>();
                    List<string> stringList = GDEDataManager.GetStringList(key, field, null);
                    if (stringList != null)
                    {
                        foreach (string text in stringList)
                        {
                            list.Add((T)((object)Activator.CreateInstance(typeof(T), new object[]
                            {
                        text
                            })));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
            return list;
        }
        public static bool HasKeyField(string key, string field)
        {
            Dictionary<string, object> dictionary;
            return GDEDataManager.ModifiedData.TryGetValue(key, out dictionary) && dictionary.ContainsKey(field);
        }
        

    }
}
