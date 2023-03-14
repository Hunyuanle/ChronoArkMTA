using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomImageDatasGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        List<string> _Sprites = new List<string>();
        public List<string> Sprites{
            get{gdata["Sprites"] = _Sprites;return _Sprites;}
            set{_Sprites = value;gdata["Sprites"] = value;}}
        internal override string GetSchema(){return "ImageDatas";}
    }
}
