using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChronoArkMod.ModData.Settings
{
    public class SliderSetting : SettingEntry
    {
        public readonly int MinValue;
        public readonly int MaxValue;
        public readonly int StepSize;
        private int _value;
        public int Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = Mathf.Clamp(value, this.MinValue, this.MaxValue);
            }
        }

        public SliderSetting(string key, string displayName, string description, int initValue, int minValue, int maxValue, int stepSize, string id) 
            : base(key, displayName, description,id)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.StepSize = stepSize;
            this.Value = initValue;
        }


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
