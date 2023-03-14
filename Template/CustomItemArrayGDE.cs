using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomItemArrayGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        List<string> _Consume = new List<string>();
        public List<string> Consume{
            get{gdata["Consume"] = _Consume;return _Consume;}
            set{_Consume = value;gdata["Consume"] = value;}}
        List<string> _Passive = new List<string>();
        public List<string> Passive{
            get{gdata["Passive"] = _Passive;return _Passive;}
            set{_Passive = value;gdata["Passive"] = value;}}
        List<string> _Equip = new List<string>();
        public List<string> Equip{
            get{gdata["Equip"] = _Equip;return _Equip;}
            set{_Equip = value;gdata["Equip"] = value;}}
        List<string> _Skill = new List<string>();
        public List<string> Skill{
            get{gdata["Skill"] = _Skill;return _Skill;}
            set{_Skill = value;gdata["Skill"] = value;}}
        internal override string GetSchema(){return "ItemArray";}
    }
}
