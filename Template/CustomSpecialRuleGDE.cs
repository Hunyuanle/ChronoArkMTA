using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomSpecialRuleGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        string _Desc = "";
        public string Desc{
            get{gdata["Desc"] = _Desc;return _Desc;}
            set{_Desc = value;gdata["Desc"] = value;}}
        string _Icon = "";
        public string Icon{
            get{gdata["Icon"] = _Icon;return _Icon;}
            set{_Icon = value;gdata["Icon"] = value;}}
        int _Difficulty = 0;
        public int Difficulty{
            get{gdata["Difficulty"] = _Difficulty;return _Difficulty;}
            set{_Difficulty = value;gdata["Difficulty"] = value;}}
        string _SimpleText = "";
        public string SimpleText{
            get{gdata["SimpleText"] = _SimpleText;return _SimpleText;}
            set{_SimpleText = value;gdata["SimpleText"] = value;}}
        List<string> _Reward = new List<string>();
        public List<string> Reward{
            get{gdata["Reward"] = _Reward;return _Reward;}
            set{_Reward = value;gdata["Reward"] = value;}}
        List<int> _RewardCount = new List<int>();
        public List<int> RewardCount{
            get{gdata["RewardCount"] = _RewardCount;return _RewardCount;}
            set{_RewardCount = value;gdata["RewardCount"] = value;}}
        bool _Except = false;
        public bool Except{
            get{gdata["Except"] = _Except;return _Except;}
            set{_Except = value;gdata["Except"] = value;}}
        string _SubClassName = "";
        public string SubClassName{
            get{gdata["SubClassName"] = _SubClassName;return _SubClassName;}
            set{_SubClassName = value;gdata["SubClassName"] = value;}}
        internal override string GetSchema(){return "SpecialRule";}
    }
}
