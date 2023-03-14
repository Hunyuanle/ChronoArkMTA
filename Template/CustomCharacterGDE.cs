using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomCharacterGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _name = "";
        public string name{
            get{gdata["name"] = _name;return _name;}
            set{_name = value;gdata["name"] = value;}}
        List<string> _Skills = new List<string>();
        public List<string> Skills{
            get{gdata["Skills"] = _Skills;return _Skills;}
            set{_Skills = value;gdata["Skills"] = value;}}
        string _Illust_NoGlass = "";
        public string Illust_NoGlass{
            get{gdata["Illust_NoGlass"] = _Illust_NoGlass;return _Illust_NoGlass;}
            set{_Illust_NoGlass = value;gdata["Illust_NoGlass"] = value;}}
        string _face = "";
        public string face{
            get{gdata["face"] = _face;return _face;}
            set{_face = value;gdata["face"] = value;}}
        string _PassiveClassName = "";
        public string PassiveClassName{
            get{gdata["PassiveClassName"] = _PassiveClassName;return _PassiveClassName;}
            set{_PassiveClassName = value;gdata["PassiveClassName"] = value;}}
        string _PassiveName = "";
        public string PassiveName{
            get{gdata["PassiveName"] = _PassiveName;return _PassiveName;}
            set{_PassiveName = value;gdata["PassiveName"] = value;}}
        string _PassiveDes = "";
        public string PassiveDes{
            get{gdata["PassiveDes"] = _PassiveDes;return _PassiveDes;}
            set{_PassiveDes = value;gdata["PassiveDes"] = value;}}
        string _BattleChar = "";
        public string BattleChar{
            get{gdata["BattleChar"] = _BattleChar;return _BattleChar;}
            set{_BattleChar = value;gdata["BattleChar"] = value;}}
        string _FaceOriginChar = "";
        public string FaceOriginChar{
            get{gdata["FaceOriginChar"] = _FaceOriginChar;return _FaceOriginChar;}
            set{_FaceOriginChar = value;gdata["FaceOriginChar"] = value;}}
        Vector2 _MAXHP = new Vector2();
        public Vector2 MAXHP{
            get{gdata["MAXHP"] = _MAXHP;return _MAXHP;}
            set{_MAXHP = value;gdata["MAXHP"] = value;}}
        Vector2 _ATK = new Vector2();
        public Vector2 ATK{
            get{gdata["ATK"] = _ATK;return _ATK;}
            set{_ATK = value;gdata["ATK"] = value;}}
        Vector2 _DEF = new Vector2();
        public Vector2 DEF{
            get{gdata["DEF"] = _DEF;return _DEF;}
            set{_DEF = value;gdata["DEF"] = value;}}
        Vector2 _CRI = new Vector2();
        public Vector2 CRI{
            get{gdata["CRI"] = _CRI;return _CRI;}
            set{_CRI = value;gdata["CRI"] = value;}}
        Vector2 _DODGE = new Vector2();
        public Vector2 DODGE{
            get{gdata["DODGE"] = _DODGE;return _DODGE;}
            set{_DODGE = value;gdata["DODGE"] = value;}}
        Vector2 _HIT = new Vector2();
        public Vector2 HIT{
            get{gdata["HIT"] = _HIT;return _HIT;}
            set{_HIT = value;gdata["HIT"] = value;}}
        Vector2 _HIT_DOT = new Vector2();
        public Vector2 HIT_DOT{
            get{gdata["HIT_DOT"] = _HIT_DOT;return _HIT_DOT;}
            set{_HIT_DOT = value;gdata["HIT_DOT"] = value;}}
        Vector2 _REG = new Vector2();
        public Vector2 REG{
            get{gdata["REG"] = _REG;return _REG;}
            set{_REG = value;gdata["REG"] = value;}}
        Vector2 _RES_CC = new Vector2();
        public Vector2 RES_CC{
            get{gdata["RES_CC"] = _RES_CC;return _RES_CC;}
            set{_RES_CC = value;gdata["RES_CC"] = value;}}
        Vector2 _RES_DEBUFF = new Vector2();
        public Vector2 RES_DEBUFF{
            get{gdata["RES_DEBUFF"] = _RES_DEBUFF;return _RES_DEBUFF;}
            set{_RES_DEBUFF = value;gdata["RES_DEBUFF"] = value;}}
        Vector2 _HIT_CC = new Vector2();
        public Vector2 HIT_CC{
            get{gdata["HIT_CC"] = _HIT_CC;return _HIT_CC;}
            set{_HIT_CC = value;gdata["HIT_CC"] = value;}}
        Vector2 _HIT_DEBUFF = new Vector2();
        public Vector2 HIT_DEBUFF{
            get{gdata["HIT_DEBUFF"] = _HIT_DEBUFF;return _HIT_DEBUFF;}
            set{_HIT_DEBUFF = value;gdata["HIT_DEBUFF"] = value;}}
        Vector2 _RES_DOT = new Vector2();
        public Vector2 RES_DOT{
            get{gdata["RES_DOT"] = _RES_DOT;return _RES_DOT;}
            set{_RES_DOT = value;gdata["RES_DOT"] = value;}}
        string _PassiveIcon = "";
        public string PassiveIcon{
            get{gdata["PassiveIcon"] = _PassiveIcon;return _PassiveIcon;}
            set{_PassiveIcon = value;gdata["PassiveIcon"] = value;}}
        bool _Lock = false;
        public bool Lock{
            get{gdata["Lock"] = _Lock;return _Lock;}
            set{_Lock = value;gdata["Lock"] = value;}}
        string _SelectInfo = "";
        public string SelectInfo{
            get{gdata["SelectInfo"] = _SelectInfo;return _SelectInfo;}
            set{_SelectInfo = value;gdata["SelectInfo"] = value;}}
        string _Role = "null";
        public string Role{
            get{gdata["Role"] = _Role;return _Role;}
            set{_Role = value;gdata["Role"] = value;}}
        string _NameAfter1 = "";
        public string NameAfter1{
            get{gdata["NameAfter1"] = _NameAfter1;return _NameAfter1;}
            set{_NameAfter1 = value;gdata["NameAfter1"] = value;}}
        string _NameAfter2 = "";
        public string NameAfter2{
            get{gdata["NameAfter2"] = _NameAfter2;return _NameAfter2;}
            set{_NameAfter2 = value;gdata["NameAfter2"] = value;}}
        string _UnlockString = "";
        public string UnlockString{
            get{gdata["UnlockString"] = _UnlockString;return _UnlockString;}
            set{_UnlockString = value;gdata["UnlockString"] = value;}}
        string _FirstSkill = "null";
        public string FirstSkill{
            get{gdata["FirstSkill"] = _FirstSkill;return _FirstSkill;}
            set{_FirstSkill = value;gdata["FirstSkill"] = value;}}
        List<string> _CampSD = new List<string>();
        public List<string> CampSD{
            get{gdata["CampSD"] = _CampSD;return _CampSD;}
            set{_CampSD = value;gdata["CampSD"] = value;}}
        string _Face_NoGlass = "";
        public string Face_NoGlass{
            get{gdata["Face_NoGlass"] = _Face_NoGlass;return _Face_NoGlass;}
            set{_Face_NoGlass = value;gdata["Face_NoGlass"] = value;}}
        List<string> _Text_Battle_Idle = new List<string>();
        public List<string> Text_Battle_Idle{
            get{gdata["Text_Battle_Idle"] = _Text_Battle_Idle;return _Text_Battle_Idle;}
            set{_Text_Battle_Idle = value;gdata["Text_Battle_Idle"] = value;}}
        List<string> _Text_Battle_ND = new List<string>();
        public List<string> Text_Battle_ND{
            get{gdata["Text_Battle_ND"] = _Text_Battle_ND;return _Text_Battle_ND;}
            set{_Text_Battle_ND = value;gdata["Text_Battle_ND"] = value;}}
        List<string> _Text_Battle_AllyND = new List<string>();
        public List<string> Text_Battle_AllyND{
            get{gdata["Text_Battle_AllyND"] = _Text_Battle_AllyND;return _Text_Battle_AllyND;}
            set{_Text_Battle_AllyND = value;gdata["Text_Battle_AllyND"] = value;}}
        List<string> _Text_Battle_Kill = new List<string>();
        public List<string> Text_Battle_Kill{
            get{gdata["Text_Battle_Kill"] = _Text_Battle_Kill;return _Text_Battle_Kill;}
            set{_Text_Battle_Kill = value;gdata["Text_Battle_Kill"] = value;}}
        List<string> _Text_Battle_Start = new List<string>();
        public List<string> Text_Battle_Start{
            get{gdata["Text_Battle_Start"] = _Text_Battle_Start;return _Text_Battle_Start;}
            set{_Text_Battle_Start = value;gdata["Text_Battle_Start"] = value;}}
        List<string> _Text_Battle_Cri = new List<string>();
        public List<string> Text_Battle_Cri{
            get{gdata["Text_Battle_Cri"] = _Text_Battle_Cri;return _Text_Battle_Cri;}
            set{_Text_Battle_Cri = value;gdata["Text_Battle_Cri"] = value;}}
        List<string> _Text_Battle_Healed = new List<string>();
        public List<string> Text_Battle_Healed{
            get{gdata["Text_Battle_Healed"] = _Text_Battle_Healed;return _Text_Battle_Healed;}
            set{_Text_Battle_Healed = value;gdata["Text_Battle_Healed"] = value;}}
        List<string> _Text_Field_Idle = new List<string>();
        public List<string> Text_Field_Idle{
            get{gdata["Text_Field_Idle"] = _Text_Field_Idle;return _Text_Field_Idle;}
            set{_Text_Field_Idle = value;gdata["Text_Field_Idle"] = value;}}
        List<string> _Text_Field_GetItem = new List<string>();
        public List<string> Text_Field_GetItem{
            get{gdata["Text_Field_GetItem"] = _Text_Field_GetItem;return _Text_Field_GetItem;}
            set{_Text_Field_GetItem = value;gdata["Text_Field_GetItem"] = value;}}
        List<string> _Text_Field_Potion_N = new List<string>();
        public List<string> Text_Field_Potion_N{
            get{gdata["Text_Field_Potion_N"] = _Text_Field_Potion_N;return _Text_Field_Potion_N;}
            set{_Text_Field_Potion_N = value;gdata["Text_Field_Potion_N"] = value;}}
        List<string> _Text_Field_Potion_P = new List<string>();
        public List<string> Text_Field_Potion_P{
            get{gdata["Text_Field_Potion_P"] = _Text_Field_Potion_P;return _Text_Field_Potion_P;}
            set{_Text_Field_Potion_P = value;gdata["Text_Field_Potion_P"] = value;}}
        List<string> _Text_Character = new List<string>();
        public List<string> Text_Character{
            get{gdata["Text_Character"] = _Text_Character;return _Text_Character;}
            set{_Text_Character = value;gdata["Text_Character"] = value;}}
        bool _Off = false;
        public bool Off{
            get{gdata["Off"] = _Off;return _Off;}
            set{_Off = value;gdata["Off"] = value;}}
        List<string> _Text_PharosLeader = new List<string>();
        public List<string> Text_PharosLeader{
            get{gdata["Text_PharosLeader"] = _Text_PharosLeader;return _Text_PharosLeader;}
            set{_Text_PharosLeader = value;gdata["Text_PharosLeader"] = value;}}
        int _StatView_Atk = 0;
        public int StatView_Atk{
            get{gdata["StatView_Atk"] = _StatView_Atk;return _StatView_Atk;}
            set{_StatView_Atk = value;gdata["StatView_Atk"] = value;}}
        int _StatView_Sup = 0;
        public int StatView_Sup{
            get{gdata["StatView_Sup"] = _StatView_Sup;return _StatView_Sup;}
            set{_StatView_Sup = value;gdata["StatView_Sup"] = value;}}
        int _StatView_Def = 0;
        public int StatView_Def{
            get{gdata["StatView_Def"] = _StatView_Def;return _StatView_Def;}
            set{_StatView_Def = value;gdata["StatView_Def"] = value;}}
        int _StatView_Dot = 0;
        public int StatView_Dot{
            get{gdata["StatView_Dot"] = _StatView_Dot;return _StatView_Dot;}
            set{_StatView_Dot = value;gdata["StatView_Dot"] = value;}}
        int _StatView_CC = 0;
        public int StatView_CC{
            get{gdata["StatView_CC"] = _StatView_CC;return _StatView_CC;}
            set{_StatView_CC = value;gdata["StatView_CC"] = value;}}
        int _StatView_Debuff = 0;
        public int StatView_Debuff{
            get{gdata["StatView_Debuff"] = _StatView_Debuff;return _StatView_Debuff;}
            set{_StatView_Debuff = value;gdata["StatView_Debuff"] = value;}}
        int _StatView_Difficult = 0;
        public int StatView_Difficult{
            get{gdata["StatView_Difficult"] = _StatView_Difficult;return _StatView_Difficult;}
            set{_StatView_Difficult = value;gdata["StatView_Difficult"] = value;}}
        string _CollectionSprite_Cover = "";
        public string CollectionSprite_Cover{
            get{gdata["CollectionSprite_Cover"] = _CollectionSprite_Cover;return _CollectionSprite_Cover;}
            set{_CollectionSprite_Cover = value;gdata["CollectionSprite_Cover"] = value;}}
        int _StatView_Heal = 0;
        public int StatView_Heal{
            get{gdata["StatView_Heal"] = _StatView_Heal;return _StatView_Heal;}
            set{_StatView_Heal = value;gdata["StatView_Heal"] = value;}}
        bool _PassiveUnlockLV1 = false;
        public bool PassiveUnlockLV1{
            get{gdata["PassiveUnlockLV1"] = _PassiveUnlockLV1;return _PassiveUnlockLV1;}
            set{_PassiveUnlockLV1 = value;gdata["PassiveUnlockLV1"] = value;}}
        int _Gender = 0;
        public int Gender{
            get{gdata["Gender"] = _Gender;return _Gender;}
            set{_Gender = value;gdata["Gender"] = value;}}
        string _CollectionSprite_SkillFace = "";
        public string CollectionSprite_SkillFace{
            get{gdata["CollectionSprite_SkillFace"] = _CollectionSprite_SkillFace;return _CollectionSprite_SkillFace;}
            set{_CollectionSprite_SkillFace = value;gdata["CollectionSprite_SkillFace"] = value;}}
        internal override string GetSchema(){return "Character";}
    }
}
