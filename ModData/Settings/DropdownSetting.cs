using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChronoArkMod.ModData.Settings
{
    public class DropdownSetting : SettingEntry
    {

        public int Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = Mathf.Clamp(value, 0, this.Options.Count - 1);
            }
        }
        public DropdownSetting(string key, string displayName, string description, int initialValue,string id, params string[] options)
            : base(key, displayName, description,id)
        {
            this.Options = new List<string>(options);
            this.Value = initialValue;
        }

        public List<string> Options;

        private int _value;

         
        public override void SaveToModSettings(Dictionary<string, object> settings)
        {
            settings.TryAddOrUpdateValue(this.Key, this.Value);
        }
        public override void RestoreFromModSettings(Dictionary<string, object> settings)
        {

            settings.TryGetInt(this.Key, out int value);
            Value = value;
        }


    }
}
