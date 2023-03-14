using ChronoArkMod.ModData;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography;
using UnityEngine;

namespace ChronoArkMod
{
    
    public static class Singleton<T>
    {
        private static T _instance;

        private static readonly object LockObject = new object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (LockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = Activator.CreateInstance<T>();
                        }
                    }
                }
                return _instance;
            }
        }
        public static void Destory()
        {
            _instance = default(T);
        }
    }
    public static class ModByCodes
    {
        


        

       
        public static string ModKey<Mod, GDE>() where Mod :ModDefinition where GDE : CustomGDE
        {

            return Singleton<Mod>.Instance.ModKey<GDE>();  
        }
        public static string ModKey<GDE>() where GDE : CustomGDE
        {
            return Singleton<GDE>.Instance.key;
        }
        
        
        



    }
    
    public abstract class ModDefinition
    {
        
        public string ModId { get; internal set; }
        public ModDefinition()
        {

        }
        public virtual IEnumerable<CustomGDE>  SetLoadingTargets()
        {
            Assembly assembly = this.GetType().Assembly;
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(CustomGDE).IsAssignableFrom(type) && !type.IsAbstract)
                {
                   yield return type.GetSingletonAs<CustomGDE>();
                }
            }
        }
        internal void LoadAll()
        {
            List<CustomGDE> customGDEs = SetLoadingTargets().ToList();
            foreach(CustomGDE customGDE in customGDEs)
            {
                customGDE.ReadJson();
            }
            foreach(CustomGDE customGDE1 in customGDEs)
            {
                customGDE1.SetAndLoad();
            }
        }
        public virtual string ModKey<GDE>() where GDE:CustomGDE
        {
            return ModId+":"+typeof(GDE).AssemblyQualifiedName;
        }
        
        internal string ModKey(Type type)
        {

            if (type.IsSubclassOf(typeof(CustomGDE)))
            {
                return typeof(ModDefinition).GetMethods().FirstOrDefault((MethodInfo method)=>(method.IsGenericMethod)).MakeGenericMethod(type).Invoke(this,null) as string;
            }
            else
            {
                throw new Exception("type is not CustomGDE");
            }
        }
        internal void UnLoad()
        {

            foreach (CustomGDE customGDE in SetLoadingTargets())
            {
                customGDE.Destroy();
            }
            GetType().DestorySingleton();
            
        }




    }







    public abstract class CustomGDE
    {
        internal Dictionary<string, object> gdata = new Dictionary<string, object>();
        public abstract ModDefinition myMod { get; }
        internal string Schema => GetSchema();
        public ModInfo modInfo => ModManager.getModInfo(myMod.ModId);
        public ModAssetInfo assetInfo => modInfo.assetInfo;
        internal abstract string GetSchema();
        public string key => Key();
        internal void ReadJson()
        {
            ModGDEInfo gdeinfo = modInfo.gdeinfo;
            if (gdeinfo.gdatas.ContainsKey(key))
            {
                gdata = gdeinfo.gdatas[key] as Dictionary<string, object>;
                ReadFromJson = true;
            }
            gdata.TryAddOrUpdateValue(GDMConstants.SchemaKey, Schema);
        }
        internal bool ReadFromJson = false;
        internal void SetAndLoad()
        {
            SetValue();
            ModGDEInfo gde = modInfo.gdeinfo;
            
            gde.gdatas[key] = gdata;
            ModGDEInfo.LoadingType loadingType= GetLoadingType();
            if (!ReadFromJson)
            {
                switch (loadingType)
                {
                    case ModGDEInfo.LoadingType.Add:
                        gde.Add.Add(key);
                        
                        break;
                    case ModGDEInfo.LoadingType.Replace:
                        gde.Replace.Add(key);
                        break;
                    case ModGDEInfo.LoadingType.AddItemToList:
                        gde.AddItemToList.Add(key);
                        break;
                    case ModGDEInfo.LoadingType.RemoveItemFromList:
                        gde.AddItemToList.Add(key);
                        break;


                }
                gde.key_schema[key] = Schema;
            }
           
           

        }
        public virtual string Key()
        {
            return myMod.ModKey(GetType());
        }
        public static string TypeName<T>() where T : Passive_Char
        {
            return typeof(T).AssemblyQualifiedName;
        }
        internal void Destroy()
        {
            gdata.Clear();
            GetType().DestorySingleton();
        }
        public abstract void SetValue();
        public abstract ModGDEInfo.LoadingType GetLoadingType();

        public CustomGDE()
        {
            
            
        }
        
    }
    public abstract class CustomGDE<Mod> : CustomGDE where Mod :ModDefinition
    {
        public override ModDefinition myMod => Singleton<Mod>.Instance;
        
        
       
        public string RegisterSpriteFromImageFile(string FilePath)
        {
            return assetInfo.ImageFromFile(FilePath);

        }

        public string RegisterSpriteFromAssetBundle(string AssetBundlePath, string FilePath)
        {
            return assetInfo.ImageFromAsset(AssetBundlePath, FilePath);

        }

        public string RegisterObjectFromAssetBundle<T>(string AssetBundlePath, string FilePath) where T : UnityEngine.Object
        {
            return assetInfo.ObjectFromAsset<T>(AssetBundlePath, FilePath);

        }
        public static string ModKey<T>() where T : CustomGDE<Mod>
        {
            return ModByCodes.ModKey<Mod, T>();
        }
        
       

    }
}

