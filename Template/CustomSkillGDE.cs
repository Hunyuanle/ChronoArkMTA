using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomSkillGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        int _UseAp = 0;
        public int UseAp{
            get{gdata["UseAp"] = _UseAp;return _UseAp;}
            set{_UseAp = value;gdata["UseAp"] = value;}}
        string _Target = "null";
        public string Target{
            get{gdata["Target"] = _Target;return _Target;}
            set{_Target = value;gdata["Target"] = value;}}
        string _Particle = "";
        public string Particle{
            get{gdata["Particle"] = _Particle;return _Particle;}
            set{_Particle = value;gdata["Particle"] = value;}}
        string _Effect_Target = "null";
        public string Effect_Target{
            get{gdata["Effect_Target"] = _Effect_Target;return _Effect_Target;}
            set{_Effect_Target = value;gdata["Effect_Target"] = value;}}
        string _Effect_Self = "null";
        public string Effect_Self{
            get{gdata["Effect_Self"] = _Effect_Self;return _Effect_Self;}
            set{_Effect_Self = value;gdata["Effect_Self"] = value;}}
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        string _KeyID = "";
        public string KeyID{
            get{gdata["KeyID"] = _KeyID;return _KeyID;}
            set{_KeyID = value;gdata["KeyID"] = value;}}
        string _Category = "null";
        public string Category{
            get{gdata["Category"] = _Category;return _Category;}
            set{_Category = value;gdata["Category"] = value;}}
        bool _NODOD = false;
        public bool NODOD{
            get{gdata["NODOD"] = _NODOD;return _NODOD;}
            set{_NODOD = value;gdata["NODOD"] = value;}}
        string _Description = "";
        public string Description{
            get{gdata["Description"] = _Description;return _Description;}
            set{_Description = value;gdata["Description"] = value;}}
        List<string> _SkillExtended = new List<string>();
        public List<string> SkillExtended{
            get{gdata["SkillExtended"] = _SkillExtended;return _SkillExtended;}
            set{_SkillExtended = value;gdata["SkillExtended"] = value;}}
        int _AutoDelete = 0;
        public int AutoDelete{
            get{gdata["AutoDelete"] = _AutoDelete;return _AutoDelete;}
            set{_AutoDelete = value;gdata["AutoDelete"] = value;}}
        bool _NotCount = false;
        public bool NotCount{
            get{gdata["NotCount"] = _NotCount;return _NotCount;}
            set{_NotCount = value;gdata["NotCount"] = value;}}
        bool _ViewBuff = false;
        public bool ViewBuff{
            get{gdata["ViewBuff"] = _ViewBuff;return _ViewBuff;}
            set{_ViewBuff = value;gdata["ViewBuff"] = value;}}
        List<string> _SKillExtendedItem = new List<string>();
        public List<string> SKillExtendedItem{
            get{gdata["SKillExtendedItem"] = _SKillExtendedItem;return _SKillExtendedItem;}
            set{_SKillExtendedItem = value;gdata["SKillExtendedItem"] = value;}}
        bool _NotChuck = false;
        public bool NotChuck{
            get{gdata["NotChuck"] = _NotChuck;return _NotChuck;}
            set{_NotChuck = value;gdata["NotChuck"] = value;}}
        bool _HealSkill = false;
        public bool HealSkill{
            get{gdata["HealSkill"] = _HealSkill;return _HealSkill;}
            set{_HealSkill = value;gdata["HealSkill"] = value;}}
        bool _Disposable = false;
        public bool Disposable{
            get{gdata["Disposable"] = _Disposable;return _Disposable;}
            set{_Disposable = value;gdata["Disposable"] = value;}}
        string _User = "";
        public string User{
            get{gdata["User"] = _User;return _User;}
            set{_User = value;gdata["User"] = value;}}
        List<string> _PlusViewBuffList = new List<string>();
        public List<string> PlusViewBuffList{
            get{gdata["PlusViewBuffList"] = _PlusViewBuffList;return _PlusViewBuffList;}
            set{_PlusViewBuffList = value;gdata["PlusViewBuffList"] = value;}}
        bool _Lock = false;
        public bool Lock{
            get{gdata["Lock"] = _Lock;return _Lock;}
            set{_Lock = value;gdata["Lock"] = value;}}
        bool _NoDrop = false;
        public bool NoDrop{
            get{gdata["NoDrop"] = _NoDrop;return _NoDrop;}
            set{_NoDrop = value;gdata["NoDrop"] = value;}}
        bool _IgnoreTaunt = false;
        public bool IgnoreTaunt{
            get{gdata["IgnoreTaunt"] = _IgnoreTaunt;return _IgnoreTaunt;}
            set{_IgnoreTaunt = value;gdata["IgnoreTaunt"] = value;}}
        string _Image_2 = "";
        public string Image_2{
            get{gdata["Image_2"] = _Image_2;return _Image_2;}
            set{_Image_2 = value;gdata["Image_2"] = value;}}
        string _Image_1 = "";
        public string Image_1{
            get{gdata["Image_1"] = _Image_1;return _Image_1;}
            set{_Image_1 = value;gdata["Image_1"] = value;}}
        string _Image_0 = "";
        public string Image_0{
            get{gdata["Image_0"] = _Image_0;return _Image_0;}
            set{_Image_0 = value;gdata["Image_0"] = value;}}
        bool _Except = false;
        public bool Except{
            get{gdata["Except"] = _Except;return _Except;}
            set{_Except = value;gdata["Except"] = value;}}
        bool _NoBasicSkill = false;
        public bool NoBasicSkill{
            get{gdata["NoBasicSkill"] = _NoBasicSkill;return _NoBasicSkill;}
            set{_NoBasicSkill = value;gdata["NoBasicSkill"] = value;}}
        bool _Basic = false;
        public bool Basic{
            get{gdata["Basic"] = _Basic;return _Basic;}
            set{_Basic = value;gdata["Basic"] = value;}}
        List<string> _PlusKeyWords = new List<string>();
        public List<string> PlusKeyWords{
            get{gdata["PlusKeyWords"] = _PlusKeyWords;return _PlusKeyWords;}
            set{_PlusKeyWords = value;gdata["PlusKeyWords"] = value;}}
        int _Counting = 0;
        public int Counting{
            get{gdata["Counting"] = _Counting;return _Counting;}
            set{_Counting = value;gdata["Counting"] = value;}}
        bool _Track = false;
        public bool Track{
            get{gdata["Track"] = _Track;return _Track;}
            set{_Track = value;gdata["Track"] = value;}}
        bool _Rare = false;
        public bool Rare{
            get{gdata["Rare"] = _Rare;return _Rare;}
            set{_Rare = value;gdata["Rare"] = value;}}
        string _LucyPartyDraw = "";
        public string LucyPartyDraw{
            get{gdata["LucyPartyDraw"] = _LucyPartyDraw;return _LucyPartyDraw;}
            set{_LucyPartyDraw = value;gdata["LucyPartyDraw"] = value;}}
        bool _EnemyPreview = false;
        public bool EnemyPreview{
            get{gdata["EnemyPreview"] = _EnemyPreview;return _EnemyPreview;}
            set{_EnemyPreview = value;gdata["EnemyPreview"] = value;}}
        string _PlusSkillView = "";
        public string PlusSkillView{
            get{gdata["PlusSkillView"] = _PlusSkillView;return _PlusSkillView;}
            set{_PlusSkillView = value;gdata["PlusSkillView"] = value;}}
        int _EnemySkillSpeed = 0;
        public int EnemySkillSpeed{
            get{gdata["EnemySkillSpeed"] = _EnemySkillSpeed;return _EnemySkillSpeed;}
            set{_EnemySkillSpeed = value;gdata["EnemySkillSpeed"] = value;}}
        bool _UnknownTarget = false;
        public bool UnknownTarget{
            get{gdata["UnknownTarget"] = _UnknownTarget;return _UnknownTarget;}
            set{_UnknownTarget = value;gdata["UnknownTarget"] = value;}}
        bool _Fatal = false;
        public bool Fatal{
            get{gdata["Fatal"] = _Fatal;return _Fatal;}
            set{_Fatal = value;gdata["Fatal"] = value;}}
        bool _SpecialUnlock = false;
        public bool SpecialUnlock{
            get{gdata["SpecialUnlock"] = _SpecialUnlock;return _SpecialUnlock;}
            set{_SpecialUnlock = value;gdata["SpecialUnlock"] = value;}}
        List<string> _SubParticle = new List<string>();
        public List<string> SubParticle{
            get{gdata["SubParticle"] = _SubParticle;return _SubParticle;}
            set{_SubParticle = value;gdata["SubParticle"] = value;}}
        internal override string GetSchema(){return "Skill";}
    }
}
