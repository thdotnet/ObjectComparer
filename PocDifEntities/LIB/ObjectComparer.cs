using PocDifEntities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PocDifEntities.LIB
{
    public class ObjectComparer
    {
        public static Dictionary<string, ObjectComparerItem> Compare<T>(T old, T actual) where T : class
        {
            var result = new Dictionary<string, ObjectComparerItem>();

            result = GetDifferences<T>(old, actual);

            return result;
        }

        private static Dictionary<string, ObjectComparerItem> GetDifferences<T>(T old, T actual) where T : class
        {
            var result = new Dictionary<string, ObjectComparerItem>();

            var properties = old.GetType().GetProperties();

            foreach (var property in properties)
            {
                object oldValue = GetValueFromProperty<T>(old, property);
                object currentValue = GetValueFromProperty<T>(actual, property);

                if(property.PropertyType.IsPrimitive == false && property.PropertyType.Namespace.Equals("System") == false)
                {
                    var obj = old.GetType().GetProperty(property.Name).GetValue(old);
                    var obj2 = actual.GetType().GetProperty(property.Name).GetValue(actual);

                    Type T2 = property.GetType();

                    var x = GetDifferences(((dynamic)obj), ((dynamic)obj2));
                    foreach (KeyValuePair<string, ObjectComparerItem> keyValue in x)
                    {
                        result.Add(keyValue.Key, keyValue.Value);
                    }
                }
                else if (UpdatedPropertyValue(oldValue, currentValue) || PropertyAdded(oldValue, currentValue) || PropertyRemoved(oldValue, currentValue))
                {
                    string oldV = oldValue == null ? "" : oldValue.ToString();
                    string currentV = currentValue == null ? "" : currentValue.ToString();

                    var item = new ObjectComparerItem(oldV, currentV);

                    result.Add(property.Name, item);
                }
            }

            return result;
        }

        private static bool UpdatedPropertyValue(object oldValue, object currentValue)
        {
            return (oldValue != null && oldValue.Equals(currentValue) == false);
        }

        private static bool PropertyRemoved(object oldValue, object currentValue)
        {
            return (oldValue != null && currentValue == null);
        }

        private static bool PropertyAdded(object oldValue, object currentValue)
        {
            return (oldValue == null && currentValue != null);
        }

        private static object GetValueFromProperty<T>(T old, System.Reflection.PropertyInfo property) where T : class
        {
            return old.GetType().GetProperty(property.Name).GetValue(old);
        }
    
        public class ObjectComparerItem
        {            
            public string OldValue {get;set;}

            public string CurrentValue {get;set;}

            public ObjectComparerItem(string oldValue, string currentValue)
            {
                OldValue = oldValue;
                CurrentValue = currentValue;
            }
        }
    }
}
