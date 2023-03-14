using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomEnchantListGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        string _ClassName = "";
        public string ClassName{
            get{gdata["ClassName"] = _ClassName;return _ClassName;}
            set{_ClassName = value;gdata["ClassName"] = value;}}
        bool _CurseOption = false;
        public bool CurseOption{
            get{gdata["CurseOption"] = _CurseOption;return _CurseOption;}
            set{_CurseOption = value;gdata["CurseOption"] = value;}}
        internal override string GetSchema(){return "EnchantList";}
    }
}
