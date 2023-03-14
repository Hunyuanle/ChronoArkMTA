using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomEnemyQueueGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        List<string> _Enemys = new List<string>();
        public List<string> Enemys{
            get{gdata["Enemys"] = _Enemys;return _Enemys;}
            set{_Enemys = value;gdata["Enemys"] = value;}}
        List<Vector3> _Pos = new List<Vector3>();
        public List<Vector3> Pos{
            get{gdata["Pos"] = _Pos;return _Pos;}
            set{_Pos = value;gdata["Pos"] = value;}}
        string _BattleReward = "null";
        public string BattleReward{
            get{gdata["BattleReward"] = _BattleReward;return _BattleReward;}
            set{_BattleReward = value;gdata["BattleReward"] = value;}}
        bool _Lock = false;
        public bool Lock{
            get{gdata["Lock"] = _Lock;return _Lock;}
            set{_Lock = value;gdata["Lock"] = value;}}
        bool _UseCustomPosition = false;
        public bool UseCustomPosition{
            get{gdata["UseCustomPosition"] = _UseCustomPosition;return _UseCustomPosition;}
            set{_UseCustomPosition = value;gdata["UseCustomPosition"] = value;}}
        List<string> _Wave2 = new List<string>();
        public List<string> Wave2{
            get{gdata["Wave2"] = _Wave2;return _Wave2;}
            set{_Wave2 = value;gdata["Wave2"] = value;}}
        List<string> _Wave3 = new List<string>();
        public List<string> Wave3{
            get{gdata["Wave3"] = _Wave3;return _Wave3;}
            set{_Wave3 = value;gdata["Wave3"] = value;}}
        int _Wave2Turn = 0;
        public int Wave2Turn{
            get{gdata["Wave2Turn"] = _Wave2Turn;return _Wave2Turn;}
            set{_Wave2Turn = value;gdata["Wave2Turn"] = value;}}
        int _Wave3Turn = 0;
        public int Wave3Turn{
            get{gdata["Wave3Turn"] = _Wave3Turn;return _Wave3Turn;}
            set{_Wave3Turn = value;gdata["Wave3Turn"] = value;}}
        int _CustomeFogTurn = 0;
        public int CustomeFogTurn{
            get{gdata["CustomeFogTurn"] = _CustomeFogTurn;return _CustomeFogTurn;}
            set{_CustomeFogTurn = value;gdata["CustomeFogTurn"] = value;}}
        bool _CustomBGM = false;
        public bool CustomBGM{
            get{gdata["CustomBGM"] = _CustomBGM;return _CustomBGM;}
            set{_CustomBGM = value;gdata["CustomBGM"] = value;}}
        string _BattleExtended = "";
        public string BattleExtended{
            get{gdata["BattleExtended"] = _BattleExtended;return _BattleExtended;}
            set{_BattleExtended = value;gdata["BattleExtended"] = value;}}
        string _DialogueObject = "";
        public string DialogueObject{
            get{gdata["DialogueObject"] = _DialogueObject;return _DialogueObject;}
            set{_DialogueObject = value;gdata["DialogueObject"] = value;}}
        internal override string GetSchema(){return "EnemyQueue";}
    }
}
