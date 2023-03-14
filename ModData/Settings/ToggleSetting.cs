using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoArkMod.ModData.Settings
{
    public class ToggleSetting : SettingEntry
    {

        public bool Value { get; set; }
        public ToggleSetting(string key, string displayName, string description, bool initValue,string id) : base(key, displayName, description,id)
        {
            this.Value = initValue;
        }


        public override void SaveToModSettings(Dictionary<string, object> settings)
        {
            settings.TryAddOrUpdateValue(this.Key, this.Value);
        }
        public override void RestoreFromModSettings(Dictionary<string, object> settings)
        {

            settings.TryGetBool(this.Key, out bool value);
            Value = value;
        }


    }
}
