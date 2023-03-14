using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomSkillUpgradeGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _Desc = "";
        public string Desc{
            get{gdata["Desc"] = _Desc;return _Desc;}
            set{_Desc = value;gdata["Desc"] = value;}}
        string _Class = "";
        public string Class{
            get{gdata["Class"] = _Class;return _Class;}
            set{_Class = value;gdata["Class"] = value;}}
        string _Character = "";
        public string Character{
            get{gdata["Character"] = _Character;return _Character;}
            set{_Character = value;gdata["Character"] = value;}}
        internal override string GetSchema(){return "SkillUpgrade";}
    }
}
