using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ChronoArkMod.ModData
{
    public class ModAudioInfo
    {
        public ModInfo info;
        public Dictionary<string,ModAudio> audios = new Dictionary<string, ModAudio>();
        GameObject _baseGameObject;
        public GameObject baseGameObject
        {
            get
            {
                if(_baseGameObject==null)
                {
                    _baseGameObject = new GameObject(info.id);
                    UnityEngine.Object.DontDestroyOnLoad(_baseGameObject);
                }
                return _baseGameObject;
            }
            set { _baseGameObject = value; }
        }
        public ModAudioInfo(ModInfo modinfo)
        {
            info = modinfo;
        }
        public class ModAudio
        {
            public string Name;
            public string path;
            public string AssetBundlePath;
            public bool Loop = false;
            public AudioMixerType MixerType = AudioMixerType.SFX;
            [JsonIgnore]
            public ModInfo modInfo;
            [JsonIgnore]
            public AudioSource source;
            [JsonIgnore]
            public string assetkey;
            public void init()
            {
                source =  modInfo.audioinfo.baseGameObject.AddComponent<AudioSource>();
                if (AssetBundlePath != null)
                {
                    assetkey = modInfo.assetInfo.ObjectFromAsset<AudioClip>(AssetBundlePath, path);
                    Addressables.LoadAssetAsync<AudioClip>(assetkey).Completed += delegate (AsyncOperationHandle<AudioClip> handle)
                    {
                        source.clip = handle.Result;
                    };
                }
                else
                {
                    SaveManager.savemanager.StartCoroutine(LoadAudioClip(("file://"+Path.Combine(modInfo.assetInfo.AssetDirectory,path))));
                }
                source.loop= Loop;
                AudioMixerGroup[] groups =  SaveManager.savemanager.MainAudio.FindMatchingGroups(MixerType.ToString());
                foreach(AudioMixerGroup group in groups)
                {
                    if(group.name== MixerType.ToString())
                    {
                        source.outputAudioMixerGroup= group;
                        break;
                    }
                }


            }
            private IEnumerator<object> LoadAudioClip(string path,AudioType audioType = AudioType.UNKNOWN)
            {
                UnityWebRequest unityWebRequest = UnityWebRequestMultimedia.GetAudioClip(path, audioType);
                yield return unityWebRequest.SendWebRequest();
                if (unityWebRequest.isHttpError || unityWebRequest.isNetworkError)
                {
                    UnityEngine.Debug.Log("Error: " + path);
                }
                else
                {
                    source.clip = DownloadHandlerAudioClip.GetContent(unityWebRequest);
                }
            }
            public void Play() 
            {
                switch (MixerType)
                {
                    case AudioMixerType.SFX:
                        source.Play();
                        break;
                    case AudioMixerType.BGM:
                        MasterAudio.ChangeVariationClip("ModBGM", true, "", source.clip);
                        MasterAudio.PlaySound("ModBGM");
                        break;
                    case AudioMixerType.FieldBGM:
                        MasterAudio.ChangeVariationClip("ModFieldBGM", true, "", source.clip);
                        MasterAudio.PlaySound("ModFieldBGM");
                        break;
                    case AudioMixerType.BattleBGM:
                        MasterAudio.ChangeVariationClip("ModBattleBGM", true, "", source.clip);
                        MasterAudio.PlaySound("ModBattleBGM");
                        break;
                }

                
                
            }
            public void Stop()
            {
                switch (MixerType)
                {
                    case AudioMixerType.SFX:
                        source.Stop();
                        break;
                    case AudioMixerType.BGM:
                        MasterAudio.StopAllOfSound("ModBGM");
                        break;
                    case AudioMixerType.FieldBGM:
                        MasterAudio.StopAllOfSound("ModFieldBGM");
                        break;
                    case AudioMixerType.BattleBGM:
                        MasterAudio.StopAllOfSound("ModBattleBGM");
                        break;
                }
            }
            public void Destroy()
            {
                UnityEngine.Object.Destroy(source);
            }
          
        }
        public enum AudioMixerType
        {
            SFX,BGM,FieldBGM,BattleBGM
        }
        public void init()
        {
            Directory.CreateDirectory(Path.Combine(info.DirectoryName, "Audio"));
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "Audio"));
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (FileInfo file in directoryInfo.GetFiles("*.json"))
            {
                string text = File.ReadAllText(file.FullName);
                ModAudio audiodef = JsonConvert.DeserializeObject<ModAudio>(text);
                audiodef.modInfo= info;
                audiodef.init();
                audios.Add(audiodef.Name, audiodef);
            }
            


        }
        public void Play(string audiokey)
        {
            if(audios.ContainsKey(audiokey))
            {
                audios[audiokey].Play();
            }
        }
        public void Stop(string audiokey)
        {
            if (audios.ContainsKey(audiokey))
            {
                audios[audiokey].Stop();
            }
        }
        public void UnLoad() 
        {
            foreach(ModAudio modAudio in audios.Values)
            {
                modAudio.Destroy();
            }
            UnityEngine.Object.Destroy(baseGameObject);
            baseGameObject= null;
            audios.Clear();
        }
       
    }
    public class ModAudioPlayScript :MonoBehaviour
    {
        public string modid;
        public string audiokey;
        public void Awake()
        {
            ModInfo modInfo =  ModManager.getModInfo(modid);
            if(modInfo != null)
            {
                modInfo.audioinfo.Play(audiokey);
            }
        }
    }
}
