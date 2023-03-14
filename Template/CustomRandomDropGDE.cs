using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomRandomDropGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        int _Common = 0;
        public int Common{
            get{gdata["Common"] = _Common;return _Common;}
            set{_Common = value;gdata["Common"] = value;}}
        int _UnCommon = 0;
        public int UnCommon{
            get{gdata["UnCommon"] = _UnCommon;return _UnCommon;}
            set{_UnCommon = value;gdata["UnCommon"] = value;}}
        int _Rare = 0;
        public int Rare{
            get{gdata["Rare"] = _Rare;return _Rare;}
            set{_Rare = value;gdata["Rare"] = value;}}
        int _Unique = 0;
        public int Unique{
            get{gdata["Unique"] = _Unique;return _Unique;}
            set{_Unique = value;gdata["Unique"] = value;}}
        int _Legendary = 0;
        public int Legendary{
            get{gdata["Legendary"] = _Legendary;return _Legendary;}
            set{_Legendary = value;gdata["Legendary"] = value;}}
        int _NoItem = 0;
        public int NoItem{
            get{gdata["NoItem"] = _NoItem;return _NoItem;}
            set{_NoItem = value;gdata["NoItem"] = value;}}
        internal override string GetSchema(){return "RandomDrop";}
    }
}
