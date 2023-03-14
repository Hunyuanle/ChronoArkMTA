using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoArkMod.ModData.Settings
{
    public class InputFieldSetting : SettingEntry
    {

        public string Value { get; set; }
        public InputFieldSetting(string key, string displayName, string description, string initialValue,string id) : base(key, displayName, description,id)
        {
            this.Value = initialValue;
        }


        public override void SaveToModSettings(Dictionary<string, object> settings)
        {
            settings.TryAddOrUpdateValue(this.Key, this.Value);
        }
        public override void RestoreFromModSettings(Dictionary<string, object> settings)
        {
           
            settings.TryGetString(this.Key,out string value);
            Value= value;
        }


    }
}
