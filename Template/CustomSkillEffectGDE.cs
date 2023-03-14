using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomSkillEffectGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        int _DMG_Per = 0;
        public int DMG_Per{
            get{gdata["DMG_Per"] = _DMG_Per;return _DMG_Per;}
            set{_DMG_Per = value;gdata["DMG_Per"] = value;}}
        int _DMG_Base = 0;
        public int DMG_Base{
            get{gdata["DMG_Base"] = _DMG_Base;return _DMG_Base;}
            set{_DMG_Base = value;gdata["DMG_Base"] = value;}}
        int _HEAL_Per = 0;
        public int HEAL_Per{
            get{gdata["HEAL_Per"] = _HEAL_Per;return _HEAL_Per;}
            set{_HEAL_Per = value;gdata["HEAL_Per"] = value;}}
        int _HEAL_Base = 0;
        public int HEAL_Base{
            get{gdata["HEAL_Base"] = _HEAL_Base;return _HEAL_Base;}
            set{_HEAL_Base = value;gdata["HEAL_Base"] = value;}}
        List<string> _Buffs = new List<string>();
        public List<string> Buffs{
            get{gdata["Buffs"] = _Buffs;return _Buffs;}
            set{_Buffs = value;gdata["Buffs"] = value;}}
        int _CRI = 0;
        public int CRI{
            get{gdata["CRI"] = _CRI;return _CRI;}
            set{_CRI = value;gdata["CRI"] = value;}}
        int _HIT = 0;
        public int HIT{
            get{gdata["HIT"] = _HIT;return _HIT;}
            set{_HIT = value;gdata["HIT"] = value;}}
        int _AP = 0;
        public int AP{
            get{gdata["AP"] = _AP;return _AP;}
            set{_AP = value;gdata["AP"] = value;}}
        int _HEAL_MaxHpPer = 0;
        public int HEAL_MaxHpPer{
            get{gdata["HEAL_MaxHpPer"] = _HEAL_MaxHpPer;return _HEAL_MaxHpPer;}
            set{_HEAL_MaxHpPer = value;gdata["HEAL_MaxHpPer"] = value;}}
        int _Horror = 0;
        public int Horror{
            get{gdata["Horror"] = _Horror;return _Horror;}
            set{_Horror = value;gdata["Horror"] = value;}}
        List<int> _BuffPlusTagPer = new List<int>();
        public List<int> BuffPlusTagPer{
            get{gdata["BuffPlusTagPer"] = _BuffPlusTagPer;return _BuffPlusTagPer;}
            set{_BuffPlusTagPer = value;gdata["BuffPlusTagPer"] = value;}}
        bool _ForceHeal = false;
        public bool ForceHeal{
            get{gdata["ForceHeal"] = _ForceHeal;return _ForceHeal;}
            set{_ForceHeal = value;gdata["ForceHeal"] = value;}}
        bool _ChainHeal = false;
        public bool ChainHeal{
            get{gdata["ChainHeal"] = _ChainHeal;return _ChainHeal;}
            set{_ChainHeal = value;gdata["ChainHeal"] = value;}}
        internal override string GetSchema(){return "SkillEffect";}
    }
}
