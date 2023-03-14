using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomItem_EquipGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
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
        string _Equip_Script = "";
        public string Equip_Script{
            get{gdata["Equip_Script"] = _Equip_Script;return _Equip_Script;}
            set{_Equip_Script = value;gdata["Equip_Script"] = value;}}
        bool _Lock = false;
        public bool Lock{
            get{gdata["Lock"] = _Lock;return _Lock;}
            set{_Lock = value;gdata["Lock"] = value;}}
        int _TimeMoneyPrice = 0;
        public int TimeMoneyPrice{
            get{gdata["TimeMoneyPrice"] = _TimeMoneyPrice;return _TimeMoneyPrice;}
            set{_TimeMoneyPrice = value;gdata["TimeMoneyPrice"] = value;}}
        string _Itemclass = "null";
        public string Itemclass{
            get{gdata["Itemclass"] = _Itemclass;return _Itemclass;}
            set{_Itemclass = value;gdata["Itemclass"] = value;}}
        List<string> _EquipSkill = new List<string>();
        public List<string> EquipSkill{
            get{gdata["EquipSkill"] = _EquipSkill;return _EquipSkill;}
            set{_EquipSkill = value;gdata["EquipSkill"] = value;}}
        bool _Off = false;
        public bool Off{
            get{gdata["Off"] = _Off;return _Off;}
            set{_Off = value;gdata["Off"] = value;}}
        bool _SpecialUnlock = false;
        public bool SpecialUnlock{
            get{gdata["SpecialUnlock"] = _SpecialUnlock;return _SpecialUnlock;}
            set{_SpecialUnlock = value;gdata["SpecialUnlock"] = value;}}
        bool _NoDrop = false;
        public bool NoDrop{
            get{gdata["NoDrop"] = _NoDrop;return _NoDrop;}
            set{_NoDrop = value;gdata["NoDrop"] = value;}}
        internal override string GetSchema(){return "Item_Equip";}
    }
}
