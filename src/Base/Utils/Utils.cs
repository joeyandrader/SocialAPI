using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using RedeSocialAPI.Models.Data;

namespace RedeSocialAPI.src.Base.Utils
{
    public static class Utils
    {
        /// <summary>
        /// Mapeia todos os campos que estão preenchidos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="current"></param>
        /// <param name="updateModel"></param>
        /// <returns></returns>
        public static T MapTo<T>(T current, object updateModel)
        {
            if (current == null)
            {
                throw new ArgumentNullException(nameof(current));
            }
            var type = current.GetType();
            foreach (var property in type.GetProperties())
            {
                try
                {
                    if (!(property.Name == "Id"))
                    {
                        goto pula;
                    }

                    object value = property.GetValue(current);
                    if (value == null || !(value.GetType().Name == "Int32") || (int)value <= 0)
                    {
                        goto pula;
                    }
                    goto end_Pula;
                pula:
                    var updateValue = updateModel.GetType().GetProperty(property.Name)?.GetValue(updateModel, null);
                    if (updateValue != null)
                    {
                        if (property.Name == "Password")
                        {
                            property.SetValue(current, CryptPassword.GerarHash(updateValue.ToString()), null);

                        }
                        property.SetValue(current, updateValue, null);
                    }
                end_Pula:
                    ;
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            return current;
        }

        /// <summary>
        /// Set value property info
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void ChangePropertyValue<T>(this T source, string propertyName, object value)
        {
            if (source != null)
            {
                PropertyInfo property = source.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    property.SetValue(source, value);
                }
            }
        }
    }
}