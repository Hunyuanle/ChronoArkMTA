using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomSpecialKeyGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        internal override string GetSchema(){return "SpecialKey";}
    }
}
