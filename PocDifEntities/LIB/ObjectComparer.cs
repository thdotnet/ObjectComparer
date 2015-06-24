using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocDifEntities.cs
{
    public class ObjectComparer
    {
        public static Dictionary<string, ObjectComparerItem> Compare<T>(T old, T actual) where T : class
        {
            var result = new Dictionary<string, ObjectComparerItem>();

            var properties = old.GetType().GetProperties();

            foreach(var property in properties)
            {
                object oldValue = GetValueFromProperty<T>(old, property);
                object currentValue = GetValueFromProperty<T>(actual, property);

                if (ValorDaPropriedadeAlterado(oldValue, currentValue) || PropriedadeAdicionada(oldValue, currentValue) || PropriedadeRemovida(oldValue, currentValue))
                {
                    string oldV = oldValue == null ? "" : oldValue.ToString();
                    string currentV = currentValue == null ? "" : currentValue.ToString();

                    var item = new ObjectComparerItem(oldV, currentV);

                    result.Add(property.Name, item);
                }
            }

            return result;
        }

        private static bool ValorDaPropriedadeAlterado(object oldValue, object currentValue)
        {
            return (oldValue != null && oldValue.Equals(currentValue) == false);
        }

        private static bool PropriedadeRemovida(object oldValue, object currentValue)
        {
            return (oldValue != null && currentValue == null);
        }

        private static bool PropriedadeAdicionada(object oldValue, object currentValue)
        {
            return (oldValue == null && currentValue != null);
        }

        private static object GetValueFromProperty<T>(T old, System.Reflection.PropertyInfo property) where T : class
        {
            return old.GetType().GetProperty(property.Name).GetValue(old);
        }
    
        public class ObjectComparerItem
        {            
            public string ValorAnterior {get;set;}

            public string ValorAtual {get;set;}

            public ObjectComparerItem(string valorAnterior, string valorAtual)
            {
                ValorAnterior = valorAnterior;
                ValorAtual = valorAtual;
            }
        }
    }
}
