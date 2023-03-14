using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
namespace  ChronoArkMod.Template
{
    public abstract class CustomSkillExtendedGDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition
    {
        string _Image = "";
        public string Image{
            get{gdata["Image"] = _Image;return _Image;}
            set{_Image = value;gdata["Image"] = value;}}
        string _Des = "";
        public string Des{
            get{gdata["Des"] = _Des;return _Des;}
            set{_Des = value;gdata["Des"] = value;}}
        string _ClassName = "";
        public string ClassName{
            get{gdata["ClassName"] = _ClassName;return _ClassName;}
            set{_ClassName = value;gdata["ClassName"] = value;}}
        string _Particle = "";
        public string Particle{
            get{gdata["Particle"] = _Particle;return _Particle;}
            set{_Particle = value;gdata["Particle"] = value;}}
        bool _AlwaysParticle = false;
        public bool AlwaysParticle{
            get{gdata["AlwaysParticle"] = _AlwaysParticle;return _AlwaysParticle;}
            set{_AlwaysParticle = value;gdata["AlwaysParticle"] = value;}}
        string _IsIcon = "";
        public string IsIcon{
            get{gdata["IsIcon"] = _IsIcon;return _IsIcon;}
            set{_IsIcon = value;gdata["IsIcon"] = value;}}
        string _Name = "";
        public string Name{
            get{gdata["Name"] = _Name;return _Name;}
            set{_Name = value;gdata["Name"] = value;}}
        bool _Debuff = false;
        public bool Debuff{
            get{gdata["Debuff"] = _Debuff;return _Debuff;}
            set{_Debuff = value;gdata["Debuff"] = value;}}
        bool _IsOnesInit = false;
        public bool IsOnesInit{
            get{gdata["IsOnesInit"] = _IsOnesInit;return _IsOnesInit;}
            set{_IsOnesInit = value;gdata["IsOnesInit"] = value;}}
        bool _Drop = false;
        public bool Drop{
            get{gdata["Drop"] = _Drop;return _Drop;}
            set{_Drop = value;gdata["Drop"] = value;}}
        string _EnforceString = "";
        public string EnforceString{
            get{gdata["EnforceString"] = _EnforceString;return _EnforceString;}
            set{_EnforceString = value;gdata["EnforceString"] = value;}}
        string _NeedCharacter = "";
        public string NeedCharacter{
            get{gdata["NeedCharacter"] = _NeedCharacter;return _NeedCharacter;}
            set{_NeedCharacter = value;gdata["NeedCharacter"] = value;}}
        internal override string GetSchema(){return "SkillExtended";}
    }
}
