using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomItem_MiscGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _name = "";
        public string name{
            get{gdata["name"] = _name;return _name;}
            set{_name = value;gdata["name"] = value;}}
        bool _stack = false;
        public bool stack{
            get{gdata["stack"] = _stack;return _stack;}
            set{_stack = value;gdata["stack"] = value;}}
        bool _outinventory = false;
        public bool outinventory{
            get{gdata["outinventory"] = _outinventory;return _outinventory;}
            set{_outinventory = value;gdata["outinventory"] = value;}}
        string _image = "";
        public string image{
            get{gdata["image"] = _image;return _image;}
            set{_image = value;gdata["image"] = value;}}
        string _Description = "";
        public string Description{
            get{gdata["Description"] = _Description;return _Description;}
            set{_Description = value;gdata["Description"] = value;}}
        int _MaxStack = 0;
        public int MaxStack{
            get{gdata["MaxStack"] = _MaxStack;return _MaxStack;}
            set{_MaxStack = value;gdata["MaxStack"] = value;}}
        int _Price = 0;
        public int Price{
            get{gdata["Price"] = _Price;return _Price;}
            set{_Price = value;gdata["Price"] = value;}}
        string _Itemclass = "null";
        public string Itemclass{
            get{gdata["Itemclass"] = _Itemclass;return _Itemclass;}
            set{_Itemclass = value;gdata["Itemclass"] = value;}}
        internal override string GetSchema(){return "Item_Misc";}
    }
}
