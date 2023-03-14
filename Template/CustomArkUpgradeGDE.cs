using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomArkUpgradeGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        int _Price = 0;
        public int Price{
            get{gdata["Price"] = _Price;return _Price;}
            set{_Price = value;gdata["Price"] = value;}}
        int _LockNum = 0;
        public int LockNum{
            get{gdata["LockNum"] = _LockNum;return _LockNum;}
            set{_LockNum = value;gdata["LockNum"] = value;}}
        string _Desc = "";
        public string Desc{
            get{gdata["Desc"] = _Desc;return _Desc;}
            set{_Desc = value;gdata["Desc"] = value;}}
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        string _Icon = "";
        public string Icon{
            get{gdata["Icon"] = _Icon;return _Icon;}
            set{_Icon = value;gdata["Icon"] = value;}}
        internal override string GetSchema(){return "ArkUpgrade";}
    }
}
