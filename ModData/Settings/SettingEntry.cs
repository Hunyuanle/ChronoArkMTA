using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoArkMod.ModData.Settings
{
    public abstract class SettingEntry
    {
        
        public SettingEntry(string key, string displayName, string description,string id)
        {
            this.Key = key;
            this.DisplayName = displayName;
            this.Description = description;
            modid = id;
            
        }

       
        public abstract void SaveToModSettings(Dictionary<string,object> settings);

       
        public abstract void RestoreFromModSettings(Dictionary<string, object> settings);

        public string Key;
        private string _DisplayName;
        public string DisplayName
        {
            get
            {

                return ModManager.getModInfo(modid).localizationInfo.SyetemLocalizationUpdate(_DisplayName);
            }
            set
            {
                _DisplayName = value;
            }
        }
        private string _Description;
        public string Description
        {
            get
            {

                return ModManager.getModInfo(modid).localizationInfo.SyetemLocalizationUpdate(_Description);
            }
            set
            {
                _Description = value;
            }
        }
        public string GroupName;
        string modid;
    }
}
