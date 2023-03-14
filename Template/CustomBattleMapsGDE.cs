using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomBattleMapsGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _MapPrefab = "";
        public string MapPrefab{
            get{gdata["MapPrefab"] = _MapPrefab;return _MapPrefab;}
            set{_MapPrefab = value;gdata["MapPrefab"] = value;}}
        internal override string GetSchema(){return "BattleMaps";}
    }
}
