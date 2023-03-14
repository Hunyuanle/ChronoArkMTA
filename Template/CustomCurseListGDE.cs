using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomCurseListGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        bool _Special = false;
        public bool Special{
            get{gdata["Special"] = _Special;return _Special;}
            set{_Special = value;gdata["Special"] = value;}}
        string _SubClassName = "";
        public string SubClassName{
            get{gdata["SubClassName"] = _SubClassName;return _SubClassName;}
            set{_SubClassName = value;gdata["SubClassName"] = value;}}
        internal override string GetSchema(){return "CurseList";}
    }
}
