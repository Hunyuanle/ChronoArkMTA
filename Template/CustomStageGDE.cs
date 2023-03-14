using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomStageGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        List<string> _FieldEnemy = new List<string>();
        public List<string> FieldEnemy{
            get{gdata["FieldEnemy"] = _FieldEnemy;return _FieldEnemy;}
            set{_FieldEnemy = value;gdata["FieldEnemy"] = value;}}
        Vector2 _MapSize = new Vector2();
        public Vector2 MapSize{
            get{gdata["MapSize"] = _MapSize;return _MapSize;}
            set{_MapSize = value;gdata["MapSize"] = value;}}
        float _BlockPer = 0;
        public float BlockPer{
            get{gdata["BlockPer"] = _BlockPer;return _BlockPer;}
            set{_BlockPer = value;gdata["BlockPer"] = value;}}
        List<string> _EventObject_S = new List<string>();
        public List<string> EventObject_S{
            get{gdata["EventObject_S"] = _EventObject_S;return _EventObject_S;}
            set{_EventObject_S = value;gdata["EventObject_S"] = value;}}
        List<string> _EventObject_L = new List<string>();
        public List<string> EventObject_L{
            get{gdata["EventObject_L"] = _EventObject_L;return _EventObject_L;}
            set{_EventObject_L = value;gdata["EventObject_L"] = value;}}
        List<string> _EventEnemy = new List<string>();
        public List<string> EventEnemy{
            get{gdata["EventEnemy"] = _EventEnemy;return _EventEnemy;}
            set{_EventEnemy = value;gdata["EventEnemy"] = value;}}
        int _EnemyNum = 0;
        public int EnemyNum{
            get{gdata["EnemyNum"] = _EnemyNum;return _EnemyNum;}
            set{_EnemyNum = value;gdata["EnemyNum"] = value;}}
        int _Event_S = 0;
        public int Event_S{
            get{gdata["Event_S"] = _Event_S;return _Event_S;}
            set{_Event_S = value;gdata["Event_S"] = value;}}
        int _Event_L = 0;
        public int Event_L{
            get{gdata["Event_L"] = _Event_L;return _Event_L;}
            set{_Event_L = value;gdata["Event_L"] = value;}}
        List<string> _Bosses = new List<string>();
        public List<string> Bosses{
            get{gdata["Bosses"] = _Bosses;return _Bosses;}
            set{_Bosses = value;gdata["Bosses"] = value;}}
        string _BattleMap = "null";
        public string BattleMap{
            get{gdata["BattleMap"] = _BattleMap;return _BattleMap;}
            set{_BattleMap = value;gdata["BattleMap"] = value;}}
        int _RareEvent_L = 0;
        public int RareEvent_L{
            get{gdata["RareEvent_L"] = _RareEvent_L;return _RareEvent_L;}
            set{_RareEvent_L = value;gdata["RareEvent_L"] = value;}}
        int _RareEvent_S = 0;
        public int RareEvent_S{
            get{gdata["RareEvent_S"] = _RareEvent_S;return _RareEvent_S;}
            set{_RareEvent_S = value;gdata["RareEvent_S"] = value;}}
        string _Tile_Iso = "";
        public string Tile_Iso{
            get{gdata["Tile_Iso"] = _Tile_Iso;return _Tile_Iso;}
            set{_Tile_Iso = value;gdata["Tile_Iso"] = value;}}
        string _StageEffect = "";
        public string StageEffect{
            get{gdata["StageEffect"] = _StageEffect;return _StageEffect;}
            set{_StageEffect = value;gdata["StageEffect"] = value;}}
        int _Event_EnemyNum = 0;
        public int Event_EnemyNum{
            get{gdata["Event_EnemyNum"] = _Event_EnemyNum;return _Event_EnemyNum;}
            set{_Event_EnemyNum = value;gdata["Event_EnemyNum"] = value;}}
        List<string> _RandomEventList = new List<string>();
        public List<string> RandomEventList{
            get{gdata["RandomEventList"] = _RandomEventList;return _RandomEventList;}
            set{_RandomEventList = value;gdata["RandomEventList"] = value;}}
        bool _Camp = false;
        public bool Camp{
            get{gdata["Camp"] = _Camp;return _Camp;}
            set{_Camp = value;gdata["Camp"] = value;}}
        int _DefultFogTurn = 0;
        public int DefultFogTurn{
            get{gdata["DefultFogTurn"] = _DefultFogTurn;return _DefultFogTurn;}
            set{_DefultFogTurn = value;gdata["DefultFogTurn"] = value;}}
        bool _Cursed_NomalEnemy = false;
        public bool Cursed_NomalEnemy{
            get{gdata["Cursed_NomalEnemy"] = _Cursed_NomalEnemy;return _Cursed_NomalEnemy;}
            set{_Cursed_NomalEnemy = value;gdata["Cursed_NomalEnemy"] = value;}}
        bool _Cursed_EventEnemy = false;
        public bool Cursed_EventEnemy{
            get{gdata["Cursed_EventEnemy"] = _Cursed_EventEnemy;return _Cursed_EventEnemy;}
            set{_Cursed_EventEnemy = value;gdata["Cursed_EventEnemy"] = value;}}
        string _FixedObject = "null";
        public string FixedObject{
            get{gdata["FixedObject"] = _FixedObject;return _FixedObject;}
            set{_FixedObject = value;gdata["FixedObject"] = value;}}
        int _StrongEnemyNum = 0;
        public int StrongEnemyNum{
            get{gdata["StrongEnemyNum"] = _StrongEnemyNum;return _StrongEnemyNum;}
            set{_StrongEnemyNum = value;gdata["StrongEnemyNum"] = value;}}
        int _BattleSoulStoneNum = 0;
        public int BattleSoulStoneNum{
            get{gdata["BattleSoulStoneNum"] = _BattleSoulStoneNum;return _BattleSoulStoneNum;}
            set{_BattleSoulStoneNum = value;gdata["BattleSoulStoneNum"] = value;}}
        int _BattleBossSouleStoneNum = 0;
        public int BattleBossSouleStoneNum{
            get{gdata["BattleBossSouleStoneNum"] = _BattleBossSouleStoneNum;return _BattleBossSouleStoneNum;}
            set{_BattleBossSouleStoneNum = value;gdata["BattleBossSouleStoneNum"] = value;}}
        bool _StoryMap = false;
        public bool StoryMap{
            get{gdata["StoryMap"] = _StoryMap;return _StoryMap;}
            set{_StoryMap = value;gdata["StoryMap"] = value;}}
        internal override string GetSchema(){return "Stage";}
    }
}
