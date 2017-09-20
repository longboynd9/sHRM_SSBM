using System;
using System.Reflection;
using System.Linq;
using System.Data;
using System.Data.Linq;

namespace iHRM.Common.Code
{
    public static class PropertyExtension1
    {
        public static object GetPropValue(object obj, string propName)
        {
            if (obj == null)
                return null;

            foreach (string part in propName.Split('.'))
            {
                if (obj == null)
                    return null;

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) 
                    return null; 

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static void SetPropValue(object obj, string propName, object value)
        {
            if (obj == null)
                return;

            int i = propName.IndexOf('.');
            if (i > -1)
            {
                string path = propName.Substring(0, i);
                propName = propName.Substring(i + 1);
                obj = GetPropValue(obj, path);
            }

            Type type = obj.GetType();
            PropertyInfo info = type.GetProperty(propName);
            if (info == null)
                return;

            //Convert.ChangeType does not handle conversion to nullable types
            //if the property type is nullable, we need to get the underlying type of the property
            var targetType = IsNullableType(info.PropertyType) ? Nullable.GetUnderlyingType(info.PropertyType) : info.PropertyType;

            //Returns an System.Object with the specified System.Type and whose value is
            //equivalent to the specified object.
            try
            {
                if (targetType.Name == "Guid" && value is string)
                    value = new Guid(value as string);
                else if (targetType.Name == "Binary")
                {
                    value = new Binary(value as byte[]);
                }
                else
                    value = Convert.ChangeType(value, targetType);
            }
            catch { }

            //Set the value of the property
            info.SetValue(obj, value, null);
        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }
}
