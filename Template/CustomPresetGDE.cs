using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomPresetGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        List<string> _Party = new List<string>();
        public List<string> Party{
            get{gdata["Party"] = _Party;return _Party;}
            set{_Party = value;gdata["Party"] = value;}}
        int _Level = 0;
        public int Level{
            get{gdata["Level"] = _Level;return _Level;}
            set{_Level = value;gdata["Level"] = value;}}
        List<string> _PartyEquip = new List<string>();
        public List<string> PartyEquip{
            get{gdata["PartyEquip"] = _PartyEquip;return _PartyEquip;}
            set{_PartyEquip = value;gdata["PartyEquip"] = value;}}
        int _AP = 0;
        public int AP{
            get{gdata["AP"] = _AP;return _AP;}
            set{_AP = value;gdata["AP"] = value;}}
        List<string> _PartySkills = new List<string>();
        public List<string> PartySkills{
            get{gdata["PartySkills"] = _PartySkills;return _PartySkills;}
            set{_PartySkills = value;gdata["PartySkills"] = value;}}
        int _Draw = 0;
        public int Draw{
            get{gdata["Draw"] = _Draw;return _Draw;}
            set{_Draw = value;gdata["Draw"] = value;}}
        List<string> _PartyBasicSkill = new List<string>();
        public List<string> PartyBasicSkill{
            get{gdata["PartyBasicSkill"] = _PartyBasicSkill;return _PartyBasicSkill;}
            set{_PartyBasicSkill = value;gdata["PartyBasicSkill"] = value;}}
        List<string> _ConsumeItems = new List<string>();
        public List<string> ConsumeItems{
            get{gdata["ConsumeItems"] = _ConsumeItems;return _ConsumeItems;}
            set{_ConsumeItems = value;gdata["ConsumeItems"] = value;}}
        List<string> _LucySkill = new List<string>();
        public List<string> LucySkill{
            get{gdata["LucySkill"] = _LucySkill;return _LucySkill;}
            set{_LucySkill = value;gdata["LucySkill"] = value;}}
        List<string> _Passive = new List<string>();
        public List<string> Passive{
            get{gdata["Passive"] = _Passive;return _Passive;}
            set{_Passive = value;gdata["Passive"] = value;}}
        internal override string GetSchema(){return "Preset";}
    }
}
