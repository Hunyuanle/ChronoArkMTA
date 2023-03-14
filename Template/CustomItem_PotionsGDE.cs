using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomItem_PotionsGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        bool _Lock = false;
        public bool Lock{
            get{gdata["Lock"] = _Lock;return _Lock;}
            set{_Lock = value;gdata["Lock"] = value;}}
        string _BattleUse = "null";
        public string BattleUse{
            get{gdata["BattleUse"] = _BattleUse;return _BattleUse;}
            set{_BattleUse = value;gdata["BattleUse"] = value;}}
        string _image = "";
        public string image{
            get{gdata["image"] = _image;return _image;}
            set{_image = value;gdata["image"] = value;}}
        string _name = "";
        public string name{
            get{gdata["name"] = _name;return _name;}
            set{_name = value;gdata["name"] = value;}}
        string _Description = "";
        public string Description{
            get{gdata["Description"] = _Description;return _Description;}
            set{_Description = value;gdata["Description"] = value;}}
        int _PotionValue = 0;
        public int PotionValue{
            get{gdata["PotionValue"] = _PotionValue;return _PotionValue;}
            set{_PotionValue = value;gdata["PotionValue"] = value;}}
        internal override string GetSchema(){return "Item_Potions";}
    }
}
