using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomItem_PassiveGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _name = "";
        public string name{
            get{gdata["name"] = _name;return _name;}
            set{_name = value;gdata["name"] = value;}}
        string _image = "";
        public string image{
            get{gdata["image"] = _image;return _image;}
            set{_image = value;gdata["image"] = value;}}
        string _passive_script = "";
        public string passive_script{
            get{gdata["passive_script"] = _passive_script;return _passive_script;}
            set{_passive_script = value;gdata["passive_script"] = value;}}
        string _Description = "";
        public string Description{
            get{gdata["Description"] = _Description;return _Description;}
            set{_Description = value;gdata["Description"] = value;}}
        bool _Lock = false;
        public bool Lock{
            get{gdata["Lock"] = _Lock;return _Lock;}
            set{_Lock = value;gdata["Lock"] = value;}}
        int _TimeMoneyPrice = 0;
        public int TimeMoneyPrice{
            get{gdata["TimeMoneyPrice"] = _TimeMoneyPrice;return _TimeMoneyPrice;}
            set{_TimeMoneyPrice = value;gdata["TimeMoneyPrice"] = value;}}
        bool _SpecialUnlock = false;
        public bool SpecialUnlock{
            get{gdata["SpecialUnlock"] = _SpecialUnlock;return _SpecialUnlock;}
            set{_SpecialUnlock = value;gdata["SpecialUnlock"] = value;}}
        bool _Unchangeable = false;
        public bool Unchangeable{
            get{gdata["Unchangeable"] = _Unchangeable;return _Unchangeable;}
            set{_Unchangeable = value;gdata["Unchangeable"] = value;}}
        bool _Off = false;
        public bool Off{
            get{gdata["Off"] = _Off;return _Off;}
            set{_Off = value;gdata["Off"] = value;}}
        bool _NoDrop = false;
        public bool NoDrop{
            get{gdata["NoDrop"] = _NoDrop;return _NoDrop;}
            set{_NoDrop = value;gdata["NoDrop"] = value;}}
        bool _LastAreaNoDrop = false;
        public bool LastAreaNoDrop{
            get{gdata["LastAreaNoDrop"] = _LastAreaNoDrop;return _LastAreaNoDrop;}
            set{_LastAreaNoDrop = value;gdata["LastAreaNoDrop"] = value;}}
        internal override string GetSchema(){return "Item_Passive";}
    }
}
