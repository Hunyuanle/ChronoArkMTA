using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomStageListGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        List<string> _Stages = new List<string>();
        public List<string> Stages{
            get{gdata["Stages"] = _Stages;return _Stages;}
            set{_Stages = value;gdata["Stages"] = value;}}
        internal override string GetSchema(){return "StageList";}
    }
}
