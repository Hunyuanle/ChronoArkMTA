using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class Customs_targettypeGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        bool _EXIT = false;
        public bool EXIT{
            get{gdata["EXIT"] = _EXIT;return _EXIT;}
            set{_EXIT = value;gdata["EXIT"] = value;}}
        internal override string GetSchema(){return "s_targettype";}
    }
}
