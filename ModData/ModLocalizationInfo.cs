using ChronoArkMod.ModData;
using ChronoArkMod.Plugin;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChronoArkMod.ModData
{
    public class ModLocalizationInfo
    {
        public ModInfo info;

        public ModLocalizationInfo(ModInfo modinfo)
        {
            info = modinfo;
        }
        public LanguageSourceData MainFile;
        public LanguageSourceData DBFile;
        public void init()
        {
            MainFile = UnityEngine.Object.Instantiate(Resources.Load<LanguageSourceAsset>("LangSystemDB")).SourceData;
            DBFile = UnityEngine.Object.Instantiate(Resources.Load<LanguageSourceAsset>("LangSystemDB")).SourceData;
            Directory.CreateDirectory(Path.Combine(info.DirectoryName, "Localization"));
            string SystemLocPath = Path.Combine(info.DirectoryName, "Localization", "LangSystemDB.csv");
            if (File.Exists(SystemLocPath))
            {
                string csvstring = LocalizationReader.ReadCSVfile(SystemLocPath, Encoding.UTF8);
                MainFile.Import_CSV(string.Empty, csvstring, eSpreadsheetUpdateMode.Replace, ',');
            }
           
            string DataPath = Path.Combine(info.DirectoryName, "Localization", "LangDataDB.csv");
            if (File.Exists(DataPath))
            {
                csv = LocalizationReader.ReadCSVfile(DataPath, Encoding.UTF8);
                DBFile.Import_CSV(string.Empty, csv, eSpreadsheetUpdateMode.Replace, ',');
            }
           

        }
        string csv;
        public void UnLoad()
        {
            MainFile = null;
            DBFile = null;//???????????????
        }
        public string SyetemLocalizationUpdate(string key)
        {
            string translated = MainFile.GetTranslation(key);
            if(translated.IsNullOrEmpty())
            {
                translated = key;
            }
            return translated;
        }
        public void LocalizationUpdate()
        {
            foreach (KeyValuePair<string, object> keyValuePair in info.gdeinfo.gdatas)
            {

                LocalizeDataPool localizeDataPool = Resources.Load<LocalizeDataPool>("LocalizeDataPool");
                Dictionary<string, object> dictionary = keyValuePair.Value as Dictionary<string, object>;
                string schema;
                dictionary.TryGetString("_gdeSchema", out schema, "");
                MultiString multiString = Array.Find<MultiString>(localizeDataPool.Schemas, (MultiString p) => p.Schema == schema);
                if (multiString != null)
                {
                    foreach (string valueName in multiString.ValueArray)
                    {
                        LocalizeUpdate(keyValuePair.Key, valueName, dictionary);
                    }
                    for (int j = 0; j < multiString.ListArray.Length; j++)
                    {
                        List<string> list;
                        dictionary.TryGetStringList(multiString.ListArray[j], out list, "");
                        if (list != null && list.Count != 0)
                        {
                            LocalizeArrayUpdate(keyValuePair.Key, multiString.ListArray[j], list, dictionary);
                        }
                    }
                }
            }
            
        
        }
        public void LocalizeUpdate(string Key, string ValueName, Dictionary<string, object> LocalizeText)
        {
            if (DBFile != null)
            {
                string translation = DBFile.GetTranslation(string.Concat(new object[]
                {
                    LocalizeText["_gdeSchema"],
                    "/",
                    Key,
                    "_",
                    ValueName
                }), null, null, false, false);
                if (!string.IsNullOrEmpty(translation))
                {
                    LocalizeText[ValueName] = translation;
                }
            }
        }
        public void LocalizeArrayUpdate(string Key, string ValueName, List<string> MainList, Dictionary<string, object> LocalizeText)
        {
            List<object> list = new List<object>();

            for (int i = 0; i < MainList.Count; i++)
            {
                try
                {
                    string temp = DBFile.GetTranslation(string.Concat(new object[]
                        {
                    LocalizeText["_gdeSchema"],
                    "/",
                    Key,
                    "_",
                    ValueName,
                    "_",
                    i
                }), null, null, false, false);

                    if (string.IsNullOrEmpty(temp))
                    {
                        list.Add(MainList[i]);
                    }
                    else
                    {
                        list.Add(temp);
                    }
                }
                catch
                {
                    list.Add(MainList[i]);
                }

            }
            LocalizeText[ValueName] = list;
        }
    }
}
