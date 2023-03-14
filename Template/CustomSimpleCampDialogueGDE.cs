using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomSimpleCampDialogueGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _CharA = "null";
        public string CharA{
            get{gdata["CharA"] = _CharA;return _CharA;}
            set{_CharA = value;gdata["CharA"] = value;}}
        string _CharB = "null";
        public string CharB{
            get{gdata["CharB"] = _CharB;return _CharB;}
            set{_CharB = value;gdata["CharB"] = value;}}
        List<string> _Dialogues = new List<string>();
        public List<string> Dialogues{
            get{gdata["Dialogues"] = _Dialogues;return _Dialogues;}
            set{_Dialogues = value;gdata["Dialogues"] = value;}}
        internal override string GetSchema(){return "SimpleCampDialogue";}
    }
}
