using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomGameobjectDatasGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _Gameobject = "";
        public string Gameobject{
            get{gdata["Gameobject"] = _Gameobject;return _Gameobject;}
            set{_Gameobject = value;gdata["Gameobject"] = value;}}
        internal override string GetSchema(){return "GameobjectDatas";}
    }
}
