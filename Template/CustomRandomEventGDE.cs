using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomRandomEventGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        string _Desc = "";
        public string Desc{
            get{gdata["Desc"] = _Desc;return _Desc;}
            set{_Desc = value;gdata["Desc"] = value;}}
        string _Script = "";
        public string Script{
            get{gdata["Script"] = _Script;return _Script;}
            set{_Script = value;gdata["Script"] = value;}}
        int _UseItemSlot = 0;
        public int UseItemSlot{
            get{gdata["UseItemSlot"] = _UseItemSlot;return _UseItemSlot;}
            set{_UseItemSlot = value;gdata["UseItemSlot"] = value;}}
        List<string> _UseButton = new List<string>();
        public List<string> UseButton{
            get{gdata["UseButton"] = _UseButton;return _UseButton;}
            set{_UseButton = value;gdata["UseButton"] = value;}}
        List<string> _UseButtonTooltip = new List<string>();
        public List<string> UseButtonTooltip{
            get{gdata["UseButtonTooltip"] = _UseButtonTooltip;return _UseButtonTooltip;}
            set{_UseButtonTooltip = value;gdata["UseButtonTooltip"] = value;}}
        string _EventDetails = "";
        public string EventDetails{
            get{gdata["EventDetails"] = _EventDetails;return _EventDetails;}
            set{_EventDetails = value;gdata["EventDetails"] = value;}}
        List<string> _OrderStrings = new List<string>();
        public List<string> OrderStrings{
            get{gdata["OrderStrings"] = _OrderStrings;return _OrderStrings;}
            set{_OrderStrings = value;gdata["OrderStrings"] = value;}}
        bool _DisableBackButton = false;
        public bool DisableBackButton{
            get{gdata["DisableBackButton"] = _DisableBackButton;return _DisableBackButton;}
            set{_DisableBackButton = value;gdata["DisableBackButton"] = value;}}
        string _MainImage = "";
        public string MainImage{
            get{gdata["MainImage"] = _MainImage;return _MainImage;}
            set{_MainImage = value;gdata["MainImage"] = value;}}
        string _EventFieldObject = "";
        public string EventFieldObject{
            get{gdata["EventFieldObject"] = _EventFieldObject;return _EventFieldObject;}
            set{_EventFieldObject = value;gdata["EventFieldObject"] = value;}}
        bool _RareEvent = false;
        public bool RareEvent{
            get{gdata["RareEvent"] = _RareEvent;return _RareEvent;}
            set{_RareEvent = value;gdata["RareEvent"] = value;}}
        bool _SpecialAppearance = false;
        public bool SpecialAppearance{
            get{gdata["SpecialAppearance"] = _SpecialAppearance;return _SpecialAppearance;}
            set{_SpecialAppearance = value;gdata["SpecialAppearance"] = value;}}
        bool _ItemSlotView = false;
        public bool ItemSlotView{
            get{gdata["ItemSlotView"] = _ItemSlotView;return _ItemSlotView;}
            set{_ItemSlotView = value;gdata["ItemSlotView"] = value;}}
        string _EventFieldObject_2Stage = "";
        public string EventFieldObject_2Stage{
            get{gdata["EventFieldObject_2Stage"] = _EventFieldObject_2Stage;return _EventFieldObject_2Stage;}
            set{_EventFieldObject_2Stage = value;gdata["EventFieldObject_2Stage"] = value;}}
        string _EventFieldObject_3Stage = "";
        public string EventFieldObject_3Stage{
            get{gdata["EventFieldObject_3Stage"] = _EventFieldObject_3Stage;return _EventFieldObject_3Stage;}
            set{_EventFieldObject_3Stage = value;gdata["EventFieldObject_3Stage"] = value;}}
        string _MainImage_2Stage = "";
        public string MainImage_2Stage{
            get{gdata["MainImage_2Stage"] = _MainImage_2Stage;return _MainImage_2Stage;}
            set{_MainImage_2Stage = value;gdata["MainImage_2Stage"] = value;}}
        string _MainImage_3Stage = "";
        public string MainImage_3Stage{
            get{gdata["MainImage_3Stage"] = _MainImage_3Stage;return _MainImage_3Stage;}
            set{_MainImage_3Stage = value;gdata["MainImage_3Stage"] = value;}}
        internal override string GetSchema(){return "RandomEvent";}
    }
}
