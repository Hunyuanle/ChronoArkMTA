using System;
using System.Linq;
using System.Reflection;

namespace ReflectionExtensions
{
    
    public static class ReflectionExtensions
    {
       
        public static void ModifyField<TObject>(this TObject obj, string fieldName, object value)
        {
            FieldInfo field = obj.GetType().GetField(fieldName, (BindingFlags)(-1));
            if (field != null)
            {
                field.SetValue(obj, value);
            }
        }

        
        public static void ModifyField<TObject>(this TObject obj, string fieldName, object value, BindingFlags flags)
        {
            FieldInfo field = obj.GetType().GetField(fieldName, flags);
            if (field != null)
            {
                field.SetValue(obj, value);
            }
        }

        public static void ModifyFieldWithTypeConvert<TObject>(this TObject obj, string fieldName, object value, BindingFlags flags = (BindingFlags)(-1))
        {
            FieldInfo field = obj.GetType().GetField(fieldName, flags);
            bool flag = field == null;
            if (!flag)
            {
                object value2 = Convert.ChangeType(value, field.FieldType);
                field.SetValue(obj, value2);
            }
        }

   
        public static object GetFieldValue<TObject>(this TObject obj, string fieldName)
        {
            FieldInfo field = obj.GetType().GetField(fieldName, (BindingFlags)(-1));
            return (field != null) ? field.GetValue(obj) : null;
        }

  
        public static object GetFieldValue<TObject>(this TObject obj, string fieldName, BindingFlags flags)
        {
            FieldInfo field = obj.GetType().GetField(fieldName, flags);
            return (field != null) ? field.GetValue(obj) : null;
        }

     
        public static object CallMethod(this object obj, string methodName, params object[] args)
        {
            Type type = obj.GetType();
            MethodInfo method;
            if (args.Length == 0)
            {
                method = type.GetMethod(methodName, (BindingFlags)(-1));
            }
            else
            {
                method = type.GetMethod(methodName, (BindingFlags)(-1), null, CallingConventions.Any, (from arg in args
                                                                                                       select arg.GetType()).ToArray<Type>(), null);
            }
            MethodInfo methodInfo = method;
            bool flag = methodInfo == null;
            if (flag)
            {
                throw new ArgumentException("Unable to find method " + methodName + " with given parameters.");
            }
            return methodInfo.Invoke(obj, (args.Length == 0) ? null : args);
        }

        
        public static object CallMethod(this object obj, string methodName, BindingFlags bindingAttr, params object[] args)
        {
            Type type = obj.GetType();
            MethodInfo method;
            if (args.Length == 0)
            {
                method = type.GetMethod(methodName, bindingAttr);
            }
            else
            {
                method = type.GetMethod(methodName, bindingAttr, null, CallingConventions.Any, (from arg in args
                                                                                                select arg.GetType()).ToArray<Type>(), null);
            }
            MethodInfo methodInfo = method;
            bool flag = methodInfo == null;
            if (flag)
            {
                throw new ArgumentException("Unable to find method " + methodName + " with given parameters.");
            }
            return methodInfo.Invoke(obj, (args.Length == 0) ? null : args);
        }

        
        private const BindingFlags DefaultBindingFlags = (BindingFlags)(-1);
    }
}
