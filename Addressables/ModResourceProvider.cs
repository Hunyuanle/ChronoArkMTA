using ChronoArkMod.ModData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine;
using System.IO;
using GameDataEditor;

namespace ChronoArkMod.Addressable
{
    public class ModResourceProvider_Image: ResourceProviderBase
    {

        public ModResourceProvider_Image(string id)
        {
            this.id = id;
        }
        string id;
        public override string ProviderId => base.ProviderId + id;
        
        public override void Provide(ProvideHandle provideHandle)
        {
            if (provideHandle.Location.PrimaryKey == "null")
            {
                provideHandle.Complete<object>(null, true, null);

            }
            Sprite sprite = (provideHandle.Location.Data as ModAssetInfo.ModImageInfo).Get();
            if (sprite != null)
            {
                Type type = provideHandle.Type;
                if (typeof(Sprite).IsAssignableFrom(type))
                {
                    provideHandle.Complete<Sprite>(sprite, true, null);
                    return;

                }
                else if (typeof(Texture2D).IsAssignableFrom(type))
                {
                    provideHandle.Complete<Texture2D>(sprite.texture, true, null);
                    return;
                }
                else
                {

                    provideHandle.Complete<object>(null, false, new Exception((provideHandle.Location.Data as ModAssetInfo.ModImageInfo).ToString()+ "Type Error"));
                    return;
                }

            }
            provideHandle.Complete<object>(null, false, new Exception((provideHandle.Location.Data as ModAssetInfo.ModImageInfo).ToString() + "Load Error"));
            return;

        }


    }
    public class ModResourceProvider_Object : ResourceProviderBase
    {

        public ModResourceProvider_Object(string id)
        {
            this.id = id;
        }
        string id;
        public override string ProviderId => base.ProviderId + id;
        ModInfo info => ModManager.getModInfo(id);
       
        public override void Provide(ProvideHandle provideHandle)
        {
            if (provideHandle.Location.PrimaryKey == "null")
            {
                provideHandle.Complete<object>(null,true, null);
            }
            object @object = (provideHandle.Location.Data as ModAssetInfo.ModObjectInfo).Get();
            if (@object != null)
            {
                Type type = provideHandle.Type;
                if (@object.GetType().IsAssignableFrom(type))
                {
                    provideHandle.Complete(@object, true, null);

                    return;
                }
                else
                {

                    provideHandle.Complete<object>(null, false, new Exception((provideHandle.Location.Data as ModAssetInfo.ModImageInfo).ToString()+"Type Error"));
                    return;
                }

            }

            provideHandle.Complete<object>(null, false, new Exception((provideHandle.Location.Data as ModAssetInfo.ModImageInfo).ToString()+"Load Error"));
            return;
        }


    }
}
