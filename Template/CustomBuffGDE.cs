using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomBuffGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        bool _Debuff = false;
        public bool Debuff{
            get{gdata["Debuff"] = _Debuff;return _Debuff;}
            set{_Debuff = value;gdata["Debuff"] = value;}}
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        string _ClassName = "";
        public string ClassName{
            get{gdata["ClassName"] = _ClassName;return _ClassName;}
            set{_ClassName = value;gdata["ClassName"] = value;}}
        float _LifeTime = 0;
        public float LifeTime{
            get{gdata["LifeTime"] = _LifeTime;return _LifeTime;}
            set{_LifeTime = value;gdata["LifeTime"] = value;}}
        int _MaxStack = 0;
        public int MaxStack{
            get{gdata["MaxStack"] = _MaxStack;return _MaxStack;}
            set{_MaxStack = value;gdata["MaxStack"] = value;}}
        string _Icon = "";
        public string Icon{
            get{gdata["Icon"] = _Icon;return _Icon;}
            set{_Icon = value;gdata["Icon"] = value;}}
        bool _Hide = false;
        public bool Hide{
            get{gdata["Hide"] = _Hide;return _Hide;}
            set{_Hide = value;gdata["Hide"] = value;}}
        string _Description = "";
        public string Description{
            get{gdata["Description"] = _Description;return _Description;}
            set{_Description = value;gdata["Description"] = value;}}
        bool _Cantdisable = false;
        public bool Cantdisable{
            get{gdata["Cantdisable"] = _Cantdisable;return _Cantdisable;}
            set{_Cantdisable = value;gdata["Cantdisable"] = value;}}
        string _Tick = "null";
        public string Tick{
            get{gdata["Tick"] = _Tick;return _Tick;}
            set{_Tick = value;gdata["Tick"] = value;}}
        int _Barrier = 0;
        public int Barrier{
            get{gdata["Barrier"] = _Barrier;return _Barrier;}
            set{_Barrier = value;gdata["Barrier"] = value;}}
        string _AllyBuffEffect = "";
        public string AllyBuffEffect{
            get{gdata["AllyBuffEffect"] = _AllyBuffEffect;return _AllyBuffEffect;}
            set{_AllyBuffEffect = value;gdata["AllyBuffEffect"] = value;}}
        string _EnemyBuffEffect = "";
        public string EnemyBuffEffect{
            get{gdata["EnemyBuffEffect"] = _EnemyBuffEffect;return _EnemyBuffEffect;}
            set{_EnemyBuffEffect = value;gdata["EnemyBuffEffect"] = value;}}
        string _BuffTag = "null";
        public string BuffTag{
            get{gdata["BuffTag"] = _BuffTag;return _BuffTag;}
            set{_BuffTag = value;gdata["BuffTag"] = value;}}
        int _TagPer = 0;
        public int TagPer{
            get{gdata["TagPer"] = _TagPer;return _TagPer;}
            set{_TagPer = value;gdata["TagPer"] = value;}}
        bool _Caution = false;
        public bool Caution{
            get{gdata["Caution"] = _Caution;return _Caution;}
            set{_Caution = value;gdata["Caution"] = value;}}
        string _BuffSoundEffect = "";
        public string BuffSoundEffect{
            get{gdata["BuffSoundEffect"] = _BuffSoundEffect;return _BuffSoundEffect;}
            set{_BuffSoundEffect = value;gdata["BuffSoundEffect"] = value;}}
        bool _IsFieldBuff = false;
        public bool IsFieldBuff{
            get{gdata["IsFieldBuff"] = _IsFieldBuff;return _IsFieldBuff;}
            set{_IsFieldBuff = value;gdata["IsFieldBuff"] = value;}}
        bool _UseSkillDebuff = false;
        public bool UseSkillDebuff{
            get{gdata["UseSkillDebuff"] = _UseSkillDebuff;return _UseSkillDebuff;}
            set{_UseSkillDebuff = value;gdata["UseSkillDebuff"] = value;}}
        internal override string GetSchema(){return "Buff";}
    }
}
