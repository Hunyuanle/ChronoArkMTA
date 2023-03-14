using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomFieldObjectGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _Object = "";
        public string Object{
            get{gdata["Object"] = _Object;return _Object;}
            set{_Object = value;gdata["Object"] = value;}}
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        bool _Rare = false;
        public bool Rare{
            get{gdata["Rare"] = _Rare;return _Rare;}
            set{_Rare = value;gdata["Rare"] = value;}}
        string _Desc = "";
        public string Desc{
            get{gdata["Desc"] = _Desc;return _Desc;}
            set{_Desc = value;gdata["Desc"] = value;}}
        string _Object2 = "";
        public string Object2{
            get{gdata["Object2"] = _Object2;return _Object2;}
            set{_Object2 = value;gdata["Object2"] = value;}}
        string _Script = "";
        public string Script{
            get{gdata["Script"] = _Script;return _Script;}
            set{_Script = value;gdata["Script"] = value;}}
        string _Object3 = "";
        public string Object3{
            get{gdata["Object3"] = _Object3;return _Object3;}
            set{_Object3 = value;gdata["Object3"] = value;}}
        string _Object4 = "";
        public string Object4{
            get{gdata["Object4"] = _Object4;return _Object4;}
            set{_Object4 = value;gdata["Object4"] = value;}}
        internal override string GetSchema(){return "FieldObject";}
    }
}
