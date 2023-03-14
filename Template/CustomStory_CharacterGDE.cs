using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomStory_CharacterGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        string _Birthday = "";
        public string Birthday{
            get{gdata["Birthday"] = _Birthday;return _Birthday;}
            set{_Birthday = value;gdata["Birthday"] = value;}}
        string _Height = "";
        public string Height{
            get{gdata["Height"] = _Height;return _Height;}
            set{_Height = value;gdata["Height"] = value;}}
        string _Age = "";
        public string Age{
            get{gdata["Age"] = _Age;return _Age;}
            set{_Age = value;gdata["Age"] = value;}}
        string _Hobby = "";
        public string Hobby{
            get{gdata["Hobby"] = _Hobby;return _Hobby;}
            set{_Hobby = value;gdata["Hobby"] = value;}}
        string _Position = "";
        public string Position{
            get{gdata["Position"] = _Position;return _Position;}
            set{_Position = value;gdata["Position"] = value;}}
        string _Comment = "";
        public string Comment{
            get{gdata["Comment"] = _Comment;return _Comment;}
            set{_Comment = value;gdata["Comment"] = value;}}
        string _Department = "null";
        public string Department{
            get{gdata["Department"] = _Department;return _Department;}
            set{_Department = value;gdata["Department"] = value;}}
        string _EngName = "";
        public string EngName{
            get{gdata["EngName"] = _EngName;return _EngName;}
            set{_EngName = value;gdata["EngName"] = value;}}
        string _IDCard = "";
        public string IDCard{
            get{gdata["IDCard"] = _IDCard;return _IDCard;}
            set{_IDCard = value;gdata["IDCard"] = value;}}
        string _Select = "";
        public string Select{
            get{gdata["Select"] = _Select;return _Select;}
            set{_Select = value;gdata["Select"] = value;}}
        bool _Public = false;
        public bool Public{
            get{gdata["Public"] = _Public;return _Public;}
            set{_Public = value;gdata["Public"] = value;}}
        bool _Phoenix = false;
        public bool Phoenix{
            get{gdata["Phoenix"] = _Phoenix;return _Phoenix;}
            set{_Phoenix = value;gdata["Phoenix"] = value;}}
        string _Comment_Writer = "";
        public string Comment_Writer{
            get{gdata["Comment_Writer"] = _Comment_Writer;return _Comment_Writer;}
            set{_Comment_Writer = value;gdata["Comment_Writer"] = value;}}
        internal override string GetSchema(){return "Story_Character";}
    }
}
