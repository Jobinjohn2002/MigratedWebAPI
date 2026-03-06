using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// GetValue operation
        /// </summary>
        public static object GetValue(object obj, string expression)
        {
            var properties = expression.Split('.');
            foreach (var property in properties)
            {
                var propertyParts = property.Split('[');
                obj = obj.GetType().GetProperty(propertyParts[0]).GetValue(obj, null);

                if (propertyParts.Length == 2)
                {
                    var index = int.Parse(propertyParts[1].TrimEnd(']'));
                    obj = ((IEnumerable<object>)obj).ToArray()[index];
                }
            }

            return obj;
        }

        public static string PropertyName<TClass, TProperty>(Expression<Func<TClass, TProperty>> property)
        {
            return PropertyName(property, false);
        }

        public static string PropertyName<TClass, TProperty>(Expression<Func<TClass, TProperty>> property, bool fullName)
        {
            var propertyName = new StringBuilder();
            var expression = (LambdaExpression)property;

            while (expression.Body is MemberExpression || expression.Body is UnaryExpression)
            {
                var memberExpression = (expression.Body as MemberExpression ?? ((UnaryExpression)expression.Body).Operand as MemberExpression);
                propertyName.Insert(0, memberExpression.Member.Name + '.');
                if (!fullName)
                {
                    break;
                }
                expression = Expression.Lambda(memberExpression.Expression);
            }

            propertyName.Length--;
            return propertyName.ToString();
        }

        public static string MethodName<TClass>(Expression<Func<TClass, object>> property)
        {
            return (property.Body as MethodCallExpression).Method.Name;
        }
    }
}