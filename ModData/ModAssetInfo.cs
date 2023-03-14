using ChronoArkMod.ModData;
using ChronoArkMod.Template;
using GameDataEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using ChronoArkMod.Addressable;
using System.ComponentModel;

namespace ChronoArkMod.ModData
{
    public static class AssetManager
    {
        public static Texture2D ModTexture2D(string key)
        {
            return AddressableLoadManager.LoadAsyncCompletion<Texture2D>(key,AddressableLoadManager.ManageType.None);


        }
        public static GameObject Load(string path)
        {
            return AddressableLoadManager.LoadAsyncCompletion<GameObject>(path, AddressableLoadManager.ManageType.None);

        }
        public static T LoadObject<T>(string path) where T : UnityEngine.Object
        {
            return AddressableLoadManager.LoadAsyncCompletion<T>(path, AddressableLoadManager.ManageType.None);
        }
        public static Sprite ModSprite(string key)
        {
            return AddressableLoadManager.LoadAsyncCompletion<Sprite>(key, AddressableLoadManager.ManageType.None);


        }
        
       
    }
    public static class AssetGeneratingTools
    {
        public static Color[] blacks = new Color[280 * 440];
        
        public static GameObject Makeface(string ImageKey, Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
        {
            GameObject face_ori = AddressableLoadManager.LoadAsyncCompletion<GameObject>("CharImagePrefebs/Face/Face_Johan", AddressableLoadManager.ManageType.None);
            GameObject face = UnityEngine.Object.Instantiate(face_ori);
            Image face_img = face.GetComponent<Image>();
            face_img.sprite = AssetManager.ModSprite(ImageKey);
            RectTransform face_rect = face.GetComponent<RectTransform>();
            face_rect.offsetMax = offsetMax;
            face_rect.offsetMin = offsetMin;
            face_rect.pivot = pivot;
            
            return face;
           
        }
        public static GameObject MakeBattleChar(string ImageKey, Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
        {
            GameObject char_ori = AddressableLoadManager.LoadAsyncCompletion<GameObject>("CharImagePrefebs/JohanBattle", AddressableLoadManager.ManageType.None);
            GameObject char_new = UnityEngine.Object.Instantiate(char_ori);
            Image char_img = char_new.GetComponent<Image>();
            char_img.sprite = AssetManager.ModSprite(ImageKey);
            RectTransform char_rect = char_img.GetComponent<RectTransform>();
            char_rect.offsetMax = offsetMax;
            char_rect.offsetMin = offsetMin;
            char_rect.pivot = pivot;
            return char_new;
        }
        public static Texture2D LoadTexture(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            fs.Seek(0, SeekOrigin.Begin);
            byte[] bys = new byte[fs.Length];
            try
            {
                fs.Read(bys, 0, bys.Length);
            }
            catch (Exception e)
            {
                UnityEngine.Debug.Log(e);
            }
            fs.Close();
            Texture2D texture = new Texture2D(4096, 4096, TextureFormat.ARGB32, false);
            texture.LoadImage(bys);
            texture.Apply();
            return texture;
        }

        public static Sprite SkillImageResizeGet(string path)
        {

            try
            {
                Texture2D ori_tex = AssetManager.ModTexture2D(path);
                if (ori_tex == null)
                {
                    return null;
                }
                int width = 440;
                int height = 280;
                int ori_width = ori_tex.width;
                int ori_height = ori_tex.height;
                int dx = (width - ori_width) / 2;
                int dy = (height - ori_height) / 2;
                if ((dx > 0 && dy > 0) || (dx == 0 && dy > 0) || (dx > 0 && dy == 0))
                {
                    if (blacks[0] == null)
                    {
                        for (int i = 0; i < blacks.Length; i++)
                        {
                            blacks[0] = new Color(0, 0, 0, 0);
                        }
                    }
                    Texture2D new_tex = new Texture2D(width, height);

                    Color[] colors = ori_tex.GetPixels();
                    new_tex.SetPixels(blacks);
                    new_tex.SetPixels(dx, dy, ori_width, ori_height, colors);





                    new_tex.Apply();

                    ori_tex = new_tex;
                }

                Sprite sp = Misc.CreatSprite(ori_tex);
                return sp;
            }
            catch
            {
                return AssetManager.ModSprite(path);
            }


          
        }
    }
    public class ModAssetInfo
    {
        public ModInfo modinfo;
        public string AssetDirectory;
        public ModAssetInfo(ModInfo modInfo) 
        {
            modinfo = modInfo;
            AssetDirectory = Path.Combine(modInfo.DirectoryName, "Assets");
            
        }
        public string SkillImageResize(string path)
        {
            return ChangeToSkillImage(path);
        }
        
        public Dictionary<string, ModImageInfo> ModImageInfos = new Dictionary<string, ModImageInfo>();
        public Dictionary<string, Sprite> IDtoSprite = new Dictionary<string, Sprite>();
        public Dictionary<string, AssetBundle> PathToAssetBundle = new Dictionary<string, AssetBundle>();
        public Dictionary<string, ModObjectInfo> ModObjectInfos = new Dictionary<string, ModObjectInfo>();
        public Dictionary<string, UnityEngine.Object> IDtoObject = new Dictionary<string, UnityEngine.Object>();
        public ModResourceLocator_Image _ImageLocator;
        public ModResourceLocator_Image ImageLocator
        {
            get
            {
                if(_ImageLocator==null)
                {
                    _ImageLocator = new ModResourceLocator_Image(modinfo.id);
                }
                return _ImageLocator;
            }
            set { _ImageLocator= value; }
        }
        public ModResourceProvider_Image _ImageProvider;
        public ModResourceProvider_Image ImageProvider
        {
            get
            {
                if (_ImageProvider == null)
                {
                    _ImageProvider = new ModResourceProvider_Image(modinfo.id);
                }
                return _ImageProvider;
            }
            set { _ImageProvider = value; }
        }
        public ModResourceLocator_Object _ObjectLocator;
        public ModResourceLocator_Object ObjectLocator
        {
            get
            {
                if (_ObjectLocator == null)
                {
                    _ObjectLocator = new ModResourceLocator_Object(modinfo.id);
                }
                return _ObjectLocator;
            }
            set { _ObjectLocator = value; }
        }
        public ModResourceProvider_Object _ObjectProvider;
        public ModResourceProvider_Object ObjectProvider
        {
            get
            {
                if (_ObjectProvider == null)
                {
                    _ObjectProvider = new ModResourceProvider_Object(modinfo.id);
                }
                return _ObjectProvider;
            }
            set { _ObjectProvider = value; }
        }
        public void init()
        {
            Directory.CreateDirectory(AssetDirectory);
            Addressables.AddResourceLocator(ImageLocator);
            Addressables.AddResourceLocator(ObjectLocator);
            Addressables.ResourceManager.ResourceProviders.Add(ImageProvider);
            Addressables.ResourceManager.ResourceProviders.Add(ObjectProvider);
        }
        public void UnLoad()
        {
            List<string> list = new List<string>();
            foreach(string key in ModImageInfos.Keys)
            {
                if (ModImageInfos[key].infoType == ImageAssetType.CodeConstructed)
                {
                    list.Add(key);
                }
            }
            foreach(string key in list)
            {
                ModImageInfos.Remove(key);
            }
            list.Clear();
            foreach (string key in ModObjectInfos.Keys)
            {
                if (ModObjectInfos[key].infoType== ObjectAssetType.CodeConstructed)
                {
                    list.Add(key);
                }
            }
            foreach (string key in list)
            {
                ModObjectInfos.Remove(key);
            }
            foreach (UnityEngine.Object @object in IDtoObject.Values)
            {
                UnityEngine.Object.Destroy(@object);
            }
            foreach (Sprite sprite in IDtoSprite.Values)
            {
                UnityEngine.Object.Destroy(sprite);
            }
            foreach(AssetBundle assetBundle in PathToAssetBundle.Values)
            {
                assetBundle.Unload(true);
            }
            IDtoObject.Clear();
            IDtoSprite.Clear();
            PathToAssetBundle.Clear();
            Addressables.RemoveResourceLocator(ImageLocator);
            Addressables.RemoveResourceLocator(ObjectLocator);
            Addressables.ResourceManager.ResourceProviders.Remove(ImageProvider);
            Addressables.ResourceManager.ResourceProviders.Remove(ObjectProvider);
            ImageLocator = null;
            ImageProvider= null;
            ObjectLocator= null;
            ObjectProvider= null;
        }
        public AssetBundle GetAssetBundle(string path)
        {
            path = path.Replace("\\", "/");
            if (PathToAssetBundle.ContainsKey(path))
            {
                return PathToAssetBundle[path];
            }
            else
            {
                AssetBundle assetBundle = null;
                try
                {
                    assetBundle = AssetBundle.LoadFromFile(Path.Combine(AssetDirectory ,path));
                    PathToAssetBundle.Add(path, assetBundle);
                }
                catch
                {

                }


                return assetBundle;
            }
        }
        public T LoadFromAsset<T>(string AssetPath, string FilePath) where T : UnityEngine.Object
        {

            return GetAssetBundle(AssetPath).LoadAsset<T>(FilePath);
        }

        public enum ObjectAssetType
        {
            FromAssetBundle, CodeConstructed, FaceGameObject, BattleCharGameObject
        }
        public string ConstructObjectByCode<T>(T gameObject) where T : UnityEngine.Object
        {
            ModObjectInfo<T> info = new ModObjectInfo<T>(modinfo);
            info.ID = gameObject.GetHashCode().ToString();
            info.infoType = ObjectAssetType.CodeConstructed;
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            info.ID = (info.ID.GetHashCode()+info.modinfo.GetHashCode()).GetHashCode().ToString();
            if (!info.Registered)
            {
                ModObjectInfos.Add(info.ID, info);
                IDtoObject.Add(info.ID, gameObject);

            }
            return info.ID;

        }
        public string FaceGameObject(string ImageKey, Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
        {
            ModObjectInfo<GameObject> info = new ModObjectInfo<GameObject>(modinfo);
            info.ImageKey = ImageKey;
            info.offsetMax = offsetMax;
            info.offsetMin = offsetMin;
            info.pivot = pivot;
            info.infoType = ObjectAssetType.FaceGameObject;
            info.ID = (info.ImageKey.GetHashCode() + info.infoType.GetHashCode()).GetHashCode().ToString();
            info.ID = (info.ID.GetHashCode() + info.modinfo.GetHashCode()).GetHashCode().ToString();
            if (!info.Registered)
            {
                ModObjectInfos.Add(info.ID, info);
            }
            return info.ID;
        }
        public string BattleCharGameObject(string ImageKey, Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
        {
            ModObjectInfo<GameObject> info = new ModObjectInfo<GameObject>(modinfo);
            info.ImageKey = ImageKey;
            info.offsetMax = offsetMax;
            info.offsetMin = offsetMin;
            info.pivot = pivot;
            info.infoType = ObjectAssetType.BattleCharGameObject;
            info.ID = (info.ImageKey.GetHashCode() + info.infoType.GetHashCode()).GetHashCode().ToString();
            info.ID = (info.ID.GetHashCode() + info.modinfo.GetHashCode()).GetHashCode().ToString();
            if (!info.Registered)
            {
                ModObjectInfos.Add(info.ID, info);
            }
            return info.ID;
        }
        public string ObjectFromAsset<T>(string AssetBundlePath, string FilePath) where T : UnityEngine.Object
        {
            ModObjectInfo<T> info = new ModObjectInfo<T>(modinfo);
            info.AssetPath = AssetBundlePath.Replace("\\", "/");
            info.infoType = ObjectAssetType.FromAssetBundle;
            info.FilePath = FilePath.Replace("\\", "/");
            info.ID = (info.AssetPath + info.FilePath).GetHashCode().ToString();
            info.ID = (info.ID.GetHashCode() + info.modinfo.GetHashCode()).GetHashCode().ToString();
            if (!info.Registered)
            {
                if (File.Exists((Path.Combine(AssetFolder, info.AssetPath))))
                {
                    AssetBundle assetBundle = GetAssetBundle(info.AssetPath);
                    if (assetBundle != null)
                    {
                        if (assetBundle.Contains(info.FilePath))
                        {
                            ModObjectInfos.Add(info.ID, info);
                            return info.ID;
                        }

                    }
                }

                return "";

            }
            return info.ID;
        }
       
        public abstract class ModObjectInfo
        {
            public ModObjectInfo(ModInfo info)
            {
                modinfo = info;
            }
            public ObjectAssetType infoType;
            public string ID;
            public string FilePath;
            public string AssetPath;
            public string ImageKey;
            public Vector2 offsetMax;
            public Vector2 offsetMin;
            public Vector2 pivot;
            public ModInfo modinfo;
            public abstract object Get();
           

        }
        public class ModObjectInfo<T> : ModObjectInfo where T : UnityEngine.Object
        {
            public ModObjectInfo(ModInfo info) : base(info)
            {
            }
            public override string ToString()
            {
                string res = ID +" "+ modinfo.id + " " +typeof(T)+" "+ infoType.ToString() + " ";
                switch (infoType)
                {
                    case ObjectAssetType.FromAssetBundle:
                        return res + " " + AssetPath + " " + FilePath;
                    case ObjectAssetType.CodeConstructed:
                        return res + " " + ID;
                    case ObjectAssetType.BattleCharGameObject:
                        return res + " " + ImageKey +" "+  offsetMax + " " + offsetMin + " " + pivot;
                    case ObjectAssetType.FaceGameObject:
                        return res + " " + ImageKey + " " + offsetMax + " " + offsetMin + " " + pivot;
                    default:return null;

                }
            }
            public override object Get()
            {
                return Get<T>();
            }
            public T Get<T2>()
            {
                switch (infoType)
                {
                    case ObjectAssetType.FromAssetBundle:
                        if (modinfo.assetInfo.IDtoObject.ContainsKey(ID))
                        {
                            if (modinfo.assetInfo.IDtoObject[ID] is T)
                            {
                                return modinfo.assetInfo.IDtoObject[ID] as T;
                            }

                        }
                        if (typeof(T) == typeof(Sprite))
                        {
                            Sprite sprite = modinfo.assetInfo.GetAssetBundle(AssetPath).LoadAsset<Sprite>(FilePath);
                            if (sprite == null)
                            {
                                Texture2D texture = modinfo.assetInfo.GetAssetBundle(AssetPath).LoadAsset<Texture2D>(FilePath);
                                if (texture != null)
                                {
                                    sprite = Misc.CreatSprite(texture);
                                }
                                modinfo.assetInfo.IDtoObject.Add(ID, sprite);

                            }
                            return sprite as T;
                        }
                        return modinfo.assetInfo.LoadFromAsset<T>(AssetPath, FilePath);
                    case ObjectAssetType.CodeConstructed:
                        if (modinfo.assetInfo.IDtoObject.ContainsKey(ID))
                        {
                            if (modinfo.assetInfo.IDtoObject[ID] is T)
                            {
                                return (T)modinfo.assetInfo.IDtoObject[ID];
                            }

                        }
                        return null;
                    case ObjectAssetType.FaceGameObject:
                        if (typeof(T) == typeof(GameObject))
                        {
                            return AssetGeneratingTools.Makeface(ImageKey, offsetMax, offsetMin, pivot) as T;
                        }
                        return null;
                    case ObjectAssetType.BattleCharGameObject:
                        if (typeof(T) == typeof(GameObject))
                        {
                            return AssetGeneratingTools.MakeBattleChar(ImageKey, offsetMax, offsetMin, pivot) as T;
                        }
                        return null;
                    default: return null;

                }
            }


            public bool Registered
            {
                get
                {
                    if (modinfo.assetInfo.ModObjectInfos.ContainsKey(ID))
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
        public string ChangeToSkillImage(string OldID)
        {
            ModImageInfo info = new ModImageInfo(modinfo);
            info.ID = OldID.GetHashCode().ToString();
            info.OldID = OldID;
            info.infoType = ImageAssetType.SkillImage;
            info.ID = (info.ID.GetHashCode() + info.modinfo.GetHashCode()).GetHashCode().ToString();
            if (!info.Registered)
            {
                ModImageInfos.Add(info.ID, info);
                return info.ID;
            }
            return info.ID;


        }
        public string ConstructImageByCode(Sprite sprite)
        {
            ModImageInfo info = new ModImageInfo(modinfo);
            info.ID = sprite.GetHashCode().ToString();
            info.infoType = ImageAssetType.CodeConstructed;
            info.ID = (info.ID.GetHashCode() + info.modinfo.GetHashCode()).GetHashCode().ToString();
            if (!info.Registered)
            {
                ModImageInfos.Add(info.ID, info);
                IDtoSprite.Add(info.ID, sprite);

            }
            return info.ID;

        }
        public string ImageFromAsset(string AssetBundlePath, string FilePath)
        {
            ModImageInfo info = new ModImageInfo(modinfo);
            info.AssetPath = AssetBundlePath.Replace("\\", "/");
            info.infoType = ImageAssetType.FromAssetBundle;
            info.FilePath = FilePath.Replace("\\", "/");
            info.ID = (info.AssetPath + info.FilePath).GetHashCode().ToString();
            info.ID = (info.ID.GetHashCode() + info.modinfo.GetHashCode()).GetHashCode().ToString();
            if (!info.Registered)
            {
                if (File.Exists(Path.Combine(AssetFolder,info.AssetPath)))
                {
                    AssetBundle assetBundle = GetAssetBundle(info.AssetPath);
                    if (assetBundle != null)
                    {
                        if (assetBundle.Contains(info.FilePath))
                        {
                            ModImageInfos.Add(info.ID, info);
                            return info.ID;
                        }

                    }
                }
                return "";
            }
            return info.ID;

        }
        public string AssetFolder => Path.Combine(modinfo.DirectoryName, "Assets");

        public string ImageFromFile(string path)
        {
            ModImageInfo info = new ModImageInfo(modinfo);
            info.FilePath = path.Replace("\\", "/"); ;
            info.infoType = ImageAssetType.FromFile;
            info.ID = info.FilePath.GetHashCode().ToString();
            info.ID = (info.ID.GetHashCode() + info.modinfo.GetHashCode()).GetHashCode().ToString();
            if (!info.Registered)
            {
                if (File.Exists((Path.Combine(AssetFolder, info.FilePath))))
                {
                    ModImageInfos.Add(info.ID, info);
                }
                else
                {
                    return "";
                }


            }
            return info.ID;
        }
        
        public enum ImageAssetType
        {
            FromFile, FromAssetBundle, CodeConstructed, SkillImage
        }
        public class ModImageInfo
        {
            public ModImageInfo(ModInfo info)
            {
                modinfo= info;
            }
            public ModInfo modinfo;
            
            public ImageAssetType infoType;
            public string ID;
            public string FilePath;
            public string AssetPath;
            public string OldID;




            public override string ToString()
            {
                string res = ID+ " "+ modinfo.id +" "+infoType.ToString()+" ";
                switch (infoType)
                {
                    case ImageAssetType.FromFile:
                        return res + FilePath;
                    case ImageAssetType.FromAssetBundle:
                        return res + AssetPath + FilePath;
                    case ImageAssetType.CodeConstructed:
                        return res + ID;
                    case ImageAssetType.SkillImage:
                        return res + OldID;
                    default: return null;

                }
            }

            public Sprite Get()
            {
                switch (infoType)
                {
                    case ImageAssetType.FromFile:
                        if (modinfo.assetInfo.IDtoSprite.ContainsKey(ID))
                        {
                            return modinfo.assetInfo.IDtoSprite[ID];
                        }
                        else
                        {
                            Texture2D texture = null;
                            try
                            {
                                texture = AssetGeneratingTools.LoadTexture(Path.Combine(modinfo.assetInfo.AssetDirectory,FilePath));
                            }
                            catch { }

                            if (texture != null)
                            {
                                Sprite sprite = Misc.CreatSprite(texture);

                                modinfo.assetInfo.IDtoSprite.Add(ID, sprite);
                                return sprite;

                            }

                        }
                        return null;
                    case ImageAssetType.FromAssetBundle:
                        if (modinfo.assetInfo.IDtoSprite.ContainsKey(ID))
                        {
                            return modinfo.assetInfo.IDtoSprite[ID];
                        }
                        Sprite sprite2 = modinfo.assetInfo.LoadFromAsset<Sprite>(AssetPath, FilePath);
                        if (sprite2 != null)
                        {
                            return sprite2;
                        }
                        else
                        {
                            Texture2D texture2 = modinfo.assetInfo.LoadFromAsset<Texture2D>(AssetPath, FilePath);
                            if (texture2 != null)
                            {
                                Sprite sprite = Misc.CreatSprite(texture2);

                                modinfo.assetInfo.IDtoSprite.Add(ID, sprite);
                                return sprite;

                            }
                            else { return null; }
                        }
                    case ImageAssetType.CodeConstructed:
                        return modinfo.assetInfo.IDtoSprite[ID];
                    case ImageAssetType.SkillImage:
                        if (modinfo.assetInfo.IDtoSprite.ContainsKey(ID))
                        {
                            return modinfo.assetInfo.IDtoSprite[ID];
                        }
                        else
                        {
                            Sprite sprite = AssetGeneratingTools.SkillImageResizeGet(OldID);
                            if (sprite != null)
                            {
                                modinfo.assetInfo.IDtoSprite[ID] = sprite;
                                return sprite;
                            }
                            else
                            {
                                return null;
                            }

                        }
                    default: return null;

                }
            }


            public bool Registered
            {
                get
                {
                    if (modinfo.assetInfo.ModImageInfos.ContainsKey(ID))
                    {
                        return true;
                    }
                    return false;
                }
            }

        }
    }

}
