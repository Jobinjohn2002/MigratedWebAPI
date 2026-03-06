using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class TypeHelper
    {
        /// <summary>
        /// ToDictionary operation
        /// </summary>
        public static IDictionary<string, object> ToDictionary(object anonymousObject)
        {
            return ToDictionary<object>(anonymousObject);
        }

        public static IDictionary<string, TValue> ToDictionary<TValue>(object anonymousObject)
        {
            return (anonymousObject?.GetType().GetProperties().ToDictionary(i => i.Name, i => (TValue)i.GetValue(anonymousObject, null)));
        }

        /// <summary>
        /// TypeOrNullableType operation
        /// </summary>
        public static Type TypeOrNullableType(Type type)
        {
            return (IsNullable(type) ? type.GetGenericArguments()[0] : type);
        }

        /// <summary>
        /// IsNullable operation
        /// </summary>
        public static bool IsNullable(Type type)
        {
            return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public static T ChangeTypeOrParse<T>(object value)
        {
            return (T)ChangeTypeOrParse(value, typeof(T));
        }

        /// <summary>
        /// ChangeTypeOrParse operation
        /// </summary>
        public static object ChangeTypeOrParse(object value, Type conversionType)
        {
            if (value == null)
            {
                return null;
            }
            else if (value is string && conversionType == typeof(string))
            {
                return value;
            }
            else if (value is string)
            {
                return Parse((string)value, conversionType);
            }
            else if (value is object[])
            {
                try
                {
                    return new SelectList((object[])value);
                }
                catch (InvalidCastException e)
                {
                    return ChangeType(value, conversionType);
                }
            }
            else
            {
                return ChangeType(value, conversionType);
            }
        }

        public static T ChangeType<T>(object value)
        {
            return (T)ChangeType(value, typeof(T));
        }

        /// <summary>
        /// ChangeType operation
        /// </summary>
        public static object ChangeType(object value, Type conversionType)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return Convert.ChangeType(value, TypeOrNullableType(conversionType));
            }
        }

        public static T Parse<T>(string value)
        {
            var result = Parse(value, typeof(T));
            return (result != null || IsNullable(typeof(T)) ? (T)result : default(T));
        }

        /// <summary>
        /// Parse operation
        /// </summary>
        public static object Parse(string value, Type conversionType)
        {
            if (value == null)
            {
                return null;
            }
            else if (conversionType == typeof(string))
            {
                return value;
            }
            else if (TypeOrNullableType(conversionType) == typeof(bool))
            {
                return Parse<bool>(value, bool.TryParse);
            }
            else if (TypeOrNullableType(conversionType) == typeof(short))
            {
                return Parse<short>(value, short.TryParse);
            }
            else if (TypeOrNullableType(conversionType) == typeof(byte))
            {
                return Parse<byte>(value, byte.TryParse);
            }
            else if (TypeOrNullableType(conversionType) == typeof(int))
            {
                return Parse<int>(value, int.TryParse);
            }
            else if (TypeOrNullableType(conversionType) == typeof(long))
            {
                return Parse<long>(value, long.TryParse);
            }
            else if (TypeOrNullableType(conversionType) == typeof(float))
            {
                return Parse<float>(value, float.TryParse);
            }
            else if (TypeOrNullableType(conversionType) == typeof(double))
            {
                return Parse<double>(value, double.TryParse);
            }
            else if (TypeOrNullableType(conversionType) == typeof(decimal))
            {
                return Parse<decimal>(value, decimal.TryParse);
            }
            else if (TypeOrNullableType(conversionType) == typeof(Guid))
            {
                return Parse<Guid>(value, Guid.TryParse);
            }
            else if (TypeOrNullableType(conversionType) == typeof(DateTime))
            {
                return Parse<DateTime>(value, DateTime.TryParse);
            }
            else if (TypeOrNullableType(conversionType) == typeof(TimeSpan))
            {
                return Parse<TimeSpan>(value, TimeSpan.TryParse);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public delegate bool TryParseDelegate<T>(string value, out T result);
        public static Nullable<T> Parse<T>(string value, TryParseDelegate<T> tryParse)
            where T : struct
        {
            bool success = tryParse(value, out T result);
            return (success ? result : (T?)null);
        }

        /// <summary>
        /// FormatString operation
        /// </summary>
        public static string FormatString(PropertyInfo property, bool simple)
        {
            var attribute = property.GetCustomAttributes(typeof(DisplayFormatAttribute), true).SingleOrDefault() as DisplayFormatAttribute;
            var formatString = attribute?.DataFormatString;
            return (simple ? StringHelper.ToSimpleFormatString(formatString) : formatString);
        }

        /// <summary>
        /// Compare operation
        /// </summary>
        public static int Compare(object value1, object value2)
        {
            var type1 = value1.GetType();
            var type2 = value2.GetType();

            if (type1 != type2)
            {
                throw new ArgumentException("value1 must be of the same type as value2");
            }
            else if (type1 == typeof(int))
            {
                var difference = (int)value1 - (int)value2;
                return (difference == 0 ? 0 : (difference < 0 ? -1 : 1));
            }
            else if (type1 == typeof(byte))
            {
                var difference = (byte)value1 - (byte)value2;
                return (difference == 0 ? 0 : (difference < 0 ? -1 : 1));
            }
            else if (type1 == typeof(string))
            {
                return string.Compare((string)value1, (string)value2);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// DisplayName operation
        /// </summary>
        public static string DisplayName(PropertyInfo property)
        {
            var attribute = (DisplayAttribute)property.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault();
            return (attribute == null ? property.Name : attribute.Name);
        }

        /// <summary>
        /// PropertyAlias operation
        /// </summary>
        public static string PropertyAlias(PropertyInfo property)
        {
            var attribute = (PropertyAliasAttribute)property.GetCustomAttributes(typeof(PropertyAliasAttribute), true).SingleOrDefault();
            return attribute?.Alias;
        }
    }
}
