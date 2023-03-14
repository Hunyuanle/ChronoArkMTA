using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ChronoArkMod
{
    public static class Extentions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static void ForEach<T>(this T[] array, Func<int, T, bool> _action)
        {
            int i = 0;
            int max = array.Length;
            while (i < max)
            {
                bool flag = _action(i, array[i]);
                if (flag)
                {
                    break;
                }
                i++;
            }
        }
        public static bool TryGetFromKeyField(this Dictionary<string,object> dictionary, string key,string field,out object value)
        {
            value = null;
            try
            {
                if (dictionary.ContainsKey(key))
                {
                    object littledict = dictionary[key];
                    if (littledict is Dictionary<string, object>)
                    {
                        if ((littledict as Dictionary<string, object>).ContainsKey(field))
                        {
                            return (littledict as Dictionary<string, object>).TryGetValue(field, out value);
                        }
                    }
                }
            }
            catch { }
            return false;
        }
        public static string PathFix(this string path)
        {
            return path.Replace('\\', '/');
        }
        public static bool HasInvalidCharForFileName(this string fileName)
        {
            return Extentions.InvalidFileNameCharRegex.IsMatch(fileName);
        }

        public static T[] ChangeArrType<TA, T>(this TA[] arrSrc, Func<TA, T> changeFunc = null)
        {
            T[] tarArr = new T[arrSrc.Length];
            int i = 0;
            int max = arrSrc.Length;
            while (i < max)
            {
                bool flag = changeFunc != null;
                if (flag)
                {
                    tarArr[i] = changeFunc(arrSrc[i]);
                }
                else
                {
                    tarArr[i] = (T)((object)Convert.ChangeType(arrSrc[i], typeof(T)));
                }
                i++;
            }
            return tarArr;
        }
        public static readonly Regex InvalidFileNameCharRegex = new Regex("[><?？*|\\\"~\\\\!$%^&+{};:',.·`！￥…、【】：；‘’“”《》，。=]");

        public static object GetSingleton(this Type type)
        {
             return typeof(Singleton<>).MakeGenericType(type).GetProperty("Instance").GetValue(null);
        }
        public static T GetSingletonAs<T>(this Type type)
        {
            return (T)type.GetSingleton();
        }
        public static void DestorySingleton(this Type type)
        {
            typeof(Singleton<>).MakeGenericType(type).GetMethod("Destory").Invoke(null, null);
        }
    }
}

