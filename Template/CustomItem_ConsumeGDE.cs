using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomItem_ConsumeGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _name = "";
        public string name{
            get{gdata["name"] = _name;return _name;}
            set{_name = value;gdata["name"] = value;}}
        string _image = "";
        public string image{
            get{gdata["image"] = _image;return _image;}
            set{_image = value;gdata["image"] = value;}}
        bool _active_field = false;
        public bool active_field{
            get{gdata["active_field"] = _active_field;return _active_field;}
            set{_active_field = value;gdata["active_field"] = value;}}
        bool _active_battle = false;
        public bool active_battle{
            get{gdata["active_battle"] = _active_battle;return _active_battle;}
            set{_active_battle = value;gdata["active_battle"] = value;}}
        string _Description = "";
        public string Description{
            get{gdata["Description"] = _Description;return _Description;}
            set{_Description = value;gdata["Description"] = value;}}
        string _Target = "null";
        public string Target{
            get{gdata["Target"] = _Target;return _Target;}
            set{_Target = value;gdata["Target"] = value;}}
        string _BattleUse = "null";
        public string BattleUse{
            get{gdata["BattleUse"] = _BattleUse;return _BattleUse;}
            set{_BattleUse = value;gdata["BattleUse"] = value;}}
        string _FieldUse = "";
        public string FieldUse{
            get{gdata["FieldUse"] = _FieldUse;return _FieldUse;}
            set{_FieldUse = value;gdata["FieldUse"] = value;}}
        int _Stack = 0;
        public int Stack{
            get{gdata["Stack"] = _Stack;return _Stack;}
            set{_Stack = value;gdata["Stack"] = value;}}
        bool _Lock = false;
        public bool Lock{
            get{gdata["Lock"] = _Lock;return _Lock;}
            set{_Lock = value;gdata["Lock"] = value;}}
        string _itemClass = "null";
        public string itemClass{
            get{gdata["itemClass"] = _itemClass;return _itemClass;}
            set{_itemClass = value;gdata["itemClass"] = value;}}
        int _Price = 0;
        public int Price{
            get{gdata["Price"] = _Price;return _Price;}
            set{_Price = value;gdata["Price"] = value;}}
        internal override string GetSchema(){return "Item_Consume";}
    }
}
