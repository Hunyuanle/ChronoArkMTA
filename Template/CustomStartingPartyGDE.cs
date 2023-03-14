using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomStartingPartyGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _RefPreset = "null";
        public string RefPreset{
            get{gdata["RefPreset"] = _RefPreset;return _RefPreset;}
            set{_RefPreset = value;gdata["RefPreset"] = value;}}
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        string _Des = "";
        public string Des{
            get{gdata["Des"] = _Des;return _Des;}
            set{_Des = value;gdata["Des"] = value;}}
        internal override string GetSchema(){return "StartingParty";}
    }
}
