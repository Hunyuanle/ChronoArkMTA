using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomUnlockWindowGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _UnlockString = "";
        public string UnlockString{
            get{gdata["UnlockString"] = _UnlockString;return _UnlockString;}
            set{_UnlockString = value;gdata["UnlockString"] = value;}}
        string _UnlockSprite = "";
        public string UnlockSprite{
            get{gdata["UnlockSprite"] = _UnlockSprite;return _UnlockSprite;}
            set{_UnlockSprite = value;gdata["UnlockSprite"] = value;}}
        internal override string GetSchema(){return "UnlockWindow";}
    }
}
