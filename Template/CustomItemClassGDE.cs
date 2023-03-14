using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomItemClassGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        bool _Dummy = false;
        public bool Dummy{
            get{gdata["Dummy"] = _Dummy;return _Dummy;}
            set{_Dummy = value;gdata["Dummy"] = value;}}
        internal override string GetSchema(){return "ItemClass";}
    }
}
