using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomFieldMapsGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _Map = "";
        public string Map{
            get{gdata["Map"] = _Map;return _Map;}
            set{_Map = value;gdata["Map"] = value;}}
        internal override string GetSchema(){return "FieldMaps";}
    }
}
