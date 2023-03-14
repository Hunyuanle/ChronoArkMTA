using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomItem_ActiveGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _name = "";
        public string name{
            get{gdata["name"] = _name;return _name;}
            set{_name = value;gdata["name"] = value;}}
        string _image = "";
        public string image{
            get{gdata["image"] = _image;return _image;}
            set{_image = value;gdata["image"] = value;}}
        string _Description = "";
        public string Description{
            get{gdata["Description"] = _Description;return _Description;}
            set{_Description = value;gdata["Description"] = value;}}
        bool _active_field = false;
        public bool active_field{
            get{gdata["active_field"] = _active_field;return _active_field;}
            set{_active_field = value;gdata["active_field"] = value;}}
        bool _active_battle = false;
        public bool active_battle{
            get{gdata["active_battle"] = _active_battle;return _active_battle;}
            set{_active_battle = value;gdata["active_battle"] = value;}}
        string _BattleUse = "null";
        public string BattleUse{
            get{gdata["BattleUse"] = _BattleUse;return _BattleUse;}
            set{_BattleUse = value;gdata["BattleUse"] = value;}}
        bool _Lock = false;
        public bool Lock{
            get{gdata["Lock"] = _Lock;return _Lock;}
            set{_Lock = value;gdata["Lock"] = value;}}
        string _FieldUse = "";
        public string FieldUse{
            get{gdata["FieldUse"] = _FieldUse;return _FieldUse;}
            set{_FieldUse = value;gdata["FieldUse"] = value;}}
        string _Target = "null";
        public string Target{
            get{gdata["Target"] = _Target;return _Target;}
            set{_Target = value;gdata["Target"] = value;}}
        int _Charge = 0;
        public int Charge{
            get{gdata["Charge"] = _Charge;return _Charge;}
            set{_Charge = value;gdata["Charge"] = value;}}
        string _Itemclass = "null";
        public string Itemclass{
            get{gdata["Itemclass"] = _Itemclass;return _Itemclass;}
            set{_Itemclass = value;gdata["Itemclass"] = value;}}
        bool _NoDrop = false;
        public bool NoDrop{
            get{gdata["NoDrop"] = _NoDrop;return _NoDrop;}
            set{_NoDrop = value;gdata["NoDrop"] = value;}}
        bool _Special = false;
        public bool Special{
            get{gdata["Special"] = _Special;return _Special;}
            set{_Special = value;gdata["Special"] = value;}}
        int _ChargeBattleNum = 0;
        public int ChargeBattleNum{
            get{gdata["ChargeBattleNum"] = _ChargeBattleNum;return _ChargeBattleNum;}
            set{_ChargeBattleNum = value;gdata["ChargeBattleNum"] = value;}}
        internal override string GetSchema(){return "Item_Active";}
    }
}
