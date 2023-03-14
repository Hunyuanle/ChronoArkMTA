using GameDataEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CodeGeneratorGDE
{
    public class CodeGeneratorGDE
    {
        public static string ClassFileDefaultPath = "Template/";
        public class GDEFieldInfo
        {
            public string Name;
            public string Type;
            public bool isList;
            public object defaultValue;
            
        }
        public static List<GDEFieldInfo> GetSchemaInfo(string Schema)
        {
            try
            {
                Dictionary<string, object> dict = GDEDataManager.masterData[GDMConstants.SchemaPrefix + Schema] as Dictionary<string, object>;
                List<string> list = new List<string>();
                foreach (string key in dict.Keys)
                {
                    if (!key.StartsWith(GDMConstants.TypePrefix) && !key.StartsWith(GDMConstants.IsListPrefix))
                    {
                        list.Add(key);
                    }
                }
                List<GDEFieldInfo> res = new List<GDEFieldInfo>();
                foreach (string key in list)
                {
                    GDEFieldInfo field = new GDEFieldInfo();
                    field.Name = key;
                    dict.TryGetString(GDMConstants.TypePrefix + key, out field.Type);
                    dict.TryGetBool(GDMConstants.IsListPrefix + key, out field.isList);
                    dict.TryGetValue(key, out field.defaultValue);
                    res.Add(field);
                }
                return res;
            }
            catch
            {
                UnityEngine.Debug.Log("???"+Schema);
                return new List<GDEFieldInfo>();
            }
            
        }
        public static string GetMTAType(string Type)
        {
            switch (Type)
            {
                case "Int":
                    return "int";
                case "Float":
                    return "float";
                case "Bool":
                    return "bool";
                case "Vector2":
                    return "Vector2";
                case "Vector3":
                    return "Vector3";
                default: 
                    return "string";
            }
        }
        public static string GetMTADefault(string Type,object defaultValue)
        {
            switch (Type)
            {
                case "Int":
                    return "0";
                case "Float":
                    return "0";
                case "Bool":
                    return "false";
                case "Vector2":
                    return "new Vector2()";
                case "Vector3":
                    return "new Vector3()";
                default:
                    return "\""+defaultValue.ToString()+"\"";
            }
        }
        public static StringBuilder GetMTA(string Schema)
        {
            StringBuilder sb = new StringBuilder();
            List<GDEFieldInfo> fields = GetSchemaInfo(Schema);
            if(fields.Count==0)
            {
                return sb;
            }
            sb.AppendLine("using System.Collections.Generic;\r\nusing GameDataEditor;\r\nusing UnityEngine;");
            sb.AppendLine("namespace  ChronoArkMod.Template");
            sb.AppendLine("{");
            sb.AppendLine("    public abstract class Custom{0}GDE<Mod> : CustomGDE<Mod> where Mod :ModDefinition".Replace("{0}", Schema));
            sb.AppendLine("    {");
            
              
            foreach(GDEFieldInfo field in fields)
            {

                string mtaType = GetMTAType(field.Type);
                if(field.isList)
                {
                    sb.AppendLine(string.Format("        List<{0}> _{1} = new List<{0}>();", mtaType,field.Name));
                    sb.AppendLine(string.Format("        public List<{0}> {1}", mtaType, field.Name)+"{");

                }
                else
                {
                    string mtaDef = GetMTADefault(field.Type,field.defaultValue);
                    sb.AppendLine(string.Format("        {0} _{1} = {2};", mtaType, field.Name,mtaDef));
                    sb.AppendLine(string.Format("        public {0} {1}", mtaType, field.Name)+"{");
                }

                sb.AppendLine("            get{gdata[\"{0}\"] = _{0};return _{0};}".Replace("{0}", field.Name));
                sb.AppendLine("            set{_{0} = value;gdata[\"{0}\"] = value;}}".Replace("{0}",field.Name));
            }
            sb.AppendLine("        internal override string GetSchema(){return \"{0}\";}".Replace("{0}", Schema));



            

            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb;
        }
        public static void WriteMTA(string Schema)
        {
            string file = Application.dataPath + "/ModTheArk/Template" + "/Custom{0}GDE.cs".Replace("{0}", Schema);
            UnityEngine.Debug.Log(file);
            string code = GetMTA(Schema).ToString();
            if (string.IsNullOrEmpty(code))
            {
                return;
            }
            File.WriteAllText(file, code);
        }
        public static void WriteAllMTA(Dictionary<string, Dictionary<string, object>> allSchemas)
        {
           //List<string> list = new List<string>();
          //  Directory.CreateDirectory(BepInEx.Paths.PluginPath + "/MTAGDE");
          //  list.AddRange(Traverse.Create(typeof(GDEDataManager)).Field("dataKeysBySchema").GetValue<Dictionary<string, HashSet<string>>>().Keys);
            foreach (string s in allSchemas.Keys)
            {
                WriteMTA(s);
            }

        }




    }
}
