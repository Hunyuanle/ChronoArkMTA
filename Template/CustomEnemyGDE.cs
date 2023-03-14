using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomEnemyGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        int _maxhp = 0;
        public int maxhp{
            get{gdata["maxhp"] = _maxhp;return _maxhp;}
            set{_maxhp = value;gdata["maxhp"] = value;}}
        int _atk = 0;
        public int atk{
            get{gdata["atk"] = _atk;return _atk;}
            set{_atk = value;gdata["atk"] = value;}}
        int _def = 0;
        public int def{
            get{gdata["def"] = _def;return _def;}
            set{_def = value;gdata["def"] = value;}}
        int _cri = 0;
        public int cri{
            get{gdata["cri"] = _cri;return _cri;}
            set{_cri = value;gdata["cri"] = value;}}
        int _dodge = 0;
        public int dodge{
            get{gdata["dodge"] = _dodge;return _dodge;}
            set{_dodge = value;gdata["dodge"] = value;}}
        int _hit = 0;
        public int hit{
            get{gdata["hit"] = _hit;return _hit;}
            set{_hit = value;gdata["hit"] = value;}}
        string _name = "";
        public string name{
            get{gdata["name"] = _name;return _name;}
            set{_name = value;gdata["name"] = value;}}
        List<string> _Skills = new List<string>();
        public List<string> Skills{
            get{gdata["Skills"] = _Skills;return _Skills;}
            set{_Skills = value;gdata["Skills"] = value;}}
        string _BattleObject = "";
        public string BattleObject{
            get{gdata["BattleObject"] = _BattleObject;return _BattleObject;}
            set{_BattleObject = value;gdata["BattleObject"] = value;}}
        string _AI = "";
        public string AI{
            get{gdata["AI"] = _AI;return _AI;}
            set{_AI = value;gdata["AI"] = value;}}
        List<string> _Passives = new List<string>();
        public List<string> Passives{
            get{gdata["Passives"] = _Passives;return _Passives;}
            set{_Passives = value;gdata["Passives"] = value;}}
        bool _Boss = false;
        public bool Boss{
            get{gdata["Boss"] = _Boss;return _Boss;}
            set{_Boss = value;gdata["Boss"] = value;}}
        int _reg = 0;
        public int reg{
            get{gdata["reg"] = _reg;return _reg;}
            set{_reg = value;gdata["reg"] = value;}}
        int _spd = 0;
        public int spd{
            get{gdata["spd"] = _spd;return _spd;}
            set{_spd = value;gdata["spd"] = value;}}
        int _RES_CC = 0;
        public int RES_CC{
            get{gdata["RES_CC"] = _RES_CC;return _RES_CC;}
            set{_RES_CC = value;gdata["RES_CC"] = value;}}
        int _RES_DEBUFF = 0;
        public int RES_DEBUFF{
            get{gdata["RES_DEBUFF"] = _RES_DEBUFF;return _RES_DEBUFF;}
            set{_RES_DEBUFF = value;gdata["RES_DEBUFF"] = value;}}
        int _RES_DOT = 0;
        public int RES_DOT{
            get{gdata["RES_DOT"] = _RES_DOT;return _RES_DOT;}
            set{_RES_DOT = value;gdata["RES_DOT"] = value;}}
        List<int> _PlusActCount = new List<int>();
        public List<int> PlusActCount{
            get{gdata["PlusActCount"] = _PlusActCount;return _PlusActCount;}
            set{_PlusActCount = value;gdata["PlusActCount"] = value;}}
        string _EnemyCate = "null";
        public string EnemyCate{
            get{gdata["EnemyCate"] = _EnemyCate;return _EnemyCate;}
            set{_EnemyCate = value;gdata["EnemyCate"] = value;}}
        bool _NotCursed = false;
        public bool NotCursed{
            get{gdata["NotCursed"] = _NotCursed;return _NotCursed;}
            set{_NotCursed = value;gdata["NotCursed"] = value;}}
        string _Face = "";
        public string Face{
            get{gdata["Face"] = _Face;return _Face;}
            set{_Face = value;gdata["Face"] = value;}}
        int _CollactionEnemy = 0;
        public int CollactionEnemy{
            get{gdata["CollactionEnemy"] = _CollactionEnemy;return _CollactionEnemy;}
            set{_CollactionEnemy = value;gdata["CollactionEnemy"] = value;}}
        string _CollactionSprite_Cover = "";
        public string CollactionSprite_Cover{
            get{gdata["CollactionSprite_Cover"] = _CollactionSprite_Cover;return _CollactionSprite_Cover;}
            set{_CollactionSprite_Cover = value;gdata["CollactionSprite_Cover"] = value;}}
        string _EnemyStory = "";
        public string EnemyStory{
            get{gdata["EnemyStory"] = _EnemyStory;return _EnemyStory;}
            set{_EnemyStory = value;gdata["EnemyStory"] = value;}}
        string _SubName = "";
        public string SubName{
            get{gdata["SubName"] = _SubName;return _SubName;}
            set{_SubName = value;gdata["SubName"] = value;}}
        int _MaxSoulStoneNum = 0;
        public int MaxSoulStoneNum{
            get{gdata["MaxSoulStoneNum"] = _MaxSoulStoneNum;return _MaxSoulStoneNum;}
            set{_MaxSoulStoneNum = value;gdata["MaxSoulStoneNum"] = value;}}
        internal override string GetSchema(){return "Enemy";}
    }
}
