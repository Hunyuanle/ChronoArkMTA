using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomRewardGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        Vector3 _Soul = new Vector3();
        public Vector3 Soul{
            get{gdata["Soul"] = _Soul;return _Soul;}
            set{_Soul = value;gdata["Soul"] = value;}}
        Vector3 _Gold = new Vector3();
        public Vector3 Gold{
            get{gdata["Gold"] = _Gold;return _Gold;}
            set{_Gold = value;gdata["Gold"] = value;}}
        string _Consume = "null";
        public string Consume{
            get{gdata["Consume"] = _Consume;return _Consume;}
            set{_Consume = value;gdata["Consume"] = value;}}
        int _Passive = 0;
        public int Passive{
            get{gdata["Passive"] = _Passive;return _Passive;}
            set{_Passive = value;gdata["Passive"] = value;}}
        Vector2 _ItemNum = new Vector2();
        public Vector2 ItemNum{
            get{gdata["ItemNum"] = _ItemNum;return _ItemNum;}
            set{_ItemNum = value;gdata["ItemNum"] = value;}}
        Vector3 _Crystal = new Vector3();
        public Vector3 Crystal{
            get{gdata["Crystal"] = _Crystal;return _Crystal;}
            set{_Crystal = value;gdata["Crystal"] = value;}}
        int _Active = 0;
        public int Active{
            get{gdata["Active"] = _Active;return _Active;}
            set{_Active = value;gdata["Active"] = value;}}
        Vector3 _ItemKey = new Vector3();
        public Vector3 ItemKey{
            get{gdata["ItemKey"] = _ItemKey;return _ItemKey;}
            set{_ItemKey = value;gdata["ItemKey"] = value;}}
        Vector3 _Heal = new Vector3();
        public Vector3 Heal{
            get{gdata["Heal"] = _Heal;return _Heal;}
            set{_Heal = value;gdata["Heal"] = value;}}
        List<string> _Item_Consume = new List<string>();
        public List<string> Item_Consume{
            get{gdata["Item_Consume"] = _Item_Consume;return _Item_Consume;}
            set{_Item_Consume = value;gdata["Item_Consume"] = value;}}
        List<string> _Item_Passive = new List<string>();
        public List<string> Item_Passive{
            get{gdata["Item_Passive"] = _Item_Passive;return _Item_Passive;}
            set{_Item_Passive = value;gdata["Item_Passive"] = value;}}
        List<string> _Item_Equip = new List<string>();
        public List<string> Item_Equip{
            get{gdata["Item_Equip"] = _Item_Equip;return _Item_Equip;}
            set{_Item_Equip = value;gdata["Item_Equip"] = value;}}
        Vector3 _TimeMoney = new Vector3();
        public Vector3 TimeMoney{
            get{gdata["TimeMoney"] = _TimeMoney;return _TimeMoney;}
            set{_TimeMoney = value;gdata["TimeMoney"] = value;}}
        string _Equip = "null";
        public string Equip{
            get{gdata["Equip"] = _Equip;return _Equip;}
            set{_Equip = value;gdata["Equip"] = value;}}
        int _PublicSkill = 0;
        public int PublicSkill{
            get{gdata["PublicSkill"] = _PublicSkill;return _PublicSkill;}
            set{_PublicSkill = value;gdata["PublicSkill"] = value;}}
        string _Item_PublicSkill = "null";
        public string Item_PublicSkill{
            get{gdata["Item_PublicSkill"] = _Item_PublicSkill;return _Item_PublicSkill;}
            set{_Item_PublicSkill = value;gdata["Item_PublicSkill"] = value;}}
        int _Scroll = 0;
        public int Scroll{
            get{gdata["Scroll"] = _Scroll;return _Scroll;}
            set{_Scroll = value;gdata["Scroll"] = value;}}
        List<string> _Reward_Extended = new List<string>();
        public List<string> Reward_Extended{
            get{gdata["Reward_Extended"] = _Reward_Extended;return _Reward_Extended;}
            set{_Reward_Extended = value;gdata["Reward_Extended"] = value;}}
        int _Potions = 0;
        public int Potions{
            get{gdata["Potions"] = _Potions;return _Potions;}
            set{_Potions = value;gdata["Potions"] = value;}}
        internal override string GetSchema(){return "Reward";}
    }
}
