using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomItem_ScrollGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        bool _Lock = false;
        public bool Lock{
            get{gdata["Lock"] = _Lock;return _Lock;}
            set{_Lock = value;gdata["Lock"] = value;}}
        string _name = "";
        public string name{
            get{gdata["name"] = _name;return _name;}
            set{_name = value;gdata["name"] = value;}}
        string _Description = "";
        public string Description{
            get{gdata["Description"] = _Description;return _Description;}
            set{_Description = value;gdata["Description"] = value;}}
        string _SubClassName = "";
        public string SubClassName{
            get{gdata["SubClassName"] = _SubClassName;return _SubClassName;}
            set{_SubClassName = value;gdata["SubClassName"] = value;}}
        internal override string GetSchema(){return "Item_Scroll";}
    }
}
