using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ExpressionHelper
    {
        /// <summary>
        /// SynergyChangeParameter operation
        /// </summary>
        public static MemberExpression SynergyChangeParameter(this MemberExpression memberExpression, ParameterExpression parameter)
        {
            var propertyNames = memberExpression.ToString().Split('.').Skip(1); // ToDo: Weak
            var propertyExpression = (Expression)parameter;

            foreach (var propertyName in propertyNames)
            {
                propertyExpression = Expression.Property(propertyExpression, propertyName);
            }
            return (MemberExpression)propertyExpression;
        }

        /// <summary>
        /// SynergyToString operation
        /// </summary>
        public static Expression SynergyToString(this MemberExpression memberExpression, string formatString)
        {
            var type = TypeHelper.TypeOrNullableType(memberExpression.Type);
            if (type == typeof(string))
            {
                return memberExpression;
            }
            else if (type == typeof(bool))
            {
                return memberExpression.SynergyBooleanToString(formatString);
            }
            else if (type == typeof(short) || type == typeof(int) || type == typeof(long))
            {
                return memberExpression.SynergyIntegerToString(formatString);
            }
            else if (type == typeof(float) || type == typeof(double) || type == typeof(decimal))
            {
                return memberExpression.SynergyDecimalToString(formatString);
            }
            else if (type == typeof(DateTime))
            {
                return memberExpression.SynergyDateToString(formatString);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// SynergyBooleanToString operation
        /// </summary>
        public static Expression SynergyBooleanToString(this MemberExpression memberExpression, string formatString)
        {
            if (formatString != null)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// SynergyIntegerToString operation
        /// </summary>
        public static Expression SynergyIntegerToString(this MemberExpression memberExpression, string formatString)
        {
            return memberExpression.SynergyStringConvert();
        }

        /// <summary>
        /// SynergyDecimalToString operation
        /// </summary>
        public static Expression SynergyDecimalToString(this MemberExpression memberExpression, string formatString)
        {
            if (formatString != null)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// SynergyDateToString operation
        /// </summary>
        public static Expression SynergyDateToString(this MemberExpression memberExpression, string formatString)
        {
            if (formatString != null)
            {
                Expression expression = null;
                var dateFormat = StringHelper.ToSimpleFormatString(formatString, true);
                var position = 0;

                while (position < dateFormat.Length)
                {
                    Expression subExpression;
                    var datePart = Regex.Match(dateFormat.Substring(position), "^[a-z]+", RegexOptions.IgnoreCase);

                    if (datePart.Success)
                    {
                        subExpression = memberExpression.SynergyFormatDatePart(datePart.Value);
                        position += datePart.Length;
                    }
                    else
                    {
                        var separator = Regex.Match(dateFormat.Substring(position), "^[^a-z]+", RegexOptions.IgnoreCase);
                        subExpression = Expression.Constant(separator.Value, typeof(string));
                        position += separator.Length;
                    }

                    expression = (expression == null ? subExpression : expression.SynergyAdd(subExpression));
                }

                return expression;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// SynergyFormatDatePart operation
        /// </summary>
        public static Expression SynergyFormatDatePart(this MemberExpression memberExpression, string datePart)
        {
            switch (datePart)
            {
                case "yy":
                {
                    return memberExpression.SynergyDateName(SqlDatePart.Year).SynergyPrepend("00").SynergyRight(2);
                }
                case "yyyy":
                {
                    return memberExpression.SynergyDateName(SqlDatePart.Year).SynergyPrepend("0000").SynergyRight(4);
                }
                case "MM":
                {
                    return memberExpression.SynergyDatePart(SqlDatePart.Month).SynergyStringConvert().SynergyPrepend("00").SynergyRight(2);
                }
                case "MMM":
                {
                    return memberExpression.SynergyDateName(SqlDatePart.Month).SynergyLeft(3);
                }
                case "dd":
                {
                    return memberExpression.SynergyDateName(SqlDatePart.Day).SynergyPrepend("00").SynergyRight(2);
                }
                case "HH":
                {
                    return memberExpression.SynergyDateName(SqlDatePart.Hour).SynergyPrepend("00").SynergyRight(2);
                }
                case "mm":
                {
                    return memberExpression.SynergyDateName(SqlDatePart.Minute).SynergyPrepend("00").SynergyRight(2);
                }
                case "ss":
                {
                    return memberExpression.SynergyDateName(SqlDatePart.Second).SynergyPrepend("00").SynergyRight(2);
                }
                default:
                {
                    throw new NotSupportedException();
                }
            }
        }

        /// <summary>
        /// SynergyToLower operation
        /// </summary>
        public static Expression SynergyToLower(this Expression stringExpression)
        {
            var method = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
            return Expression.Call(stringExpression, method);
        }

        /// <summary>
        /// SynergyContains operation
        /// </summary>
        public static Expression SynergyContains(this Expression stringExpression, string value)
        {
            var method = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            var arg = Expression.Constant(value, typeof(string));
            return Expression.Call(stringExpression, method, arg);
        }

        /// <summary>
        /// SynergyDatePart operation
        /// </summary>
        public static Expression SynergyDatePart(this Expression expression, string datePart)
        {
            var method = typeof(SqlFunctions).GetMethod("DatePart", new Type[] { typeof(string), typeof(DateTime?) });
            var arg1 = Expression.Constant(datePart);
            var arg2 = expression.SynergyConvert(typeof(DateTime?));
            return Expression.Call(method, arg1, arg2);
        }

        /// <summary>
        /// SynergyDateName operation
        /// </summary>
        public static Expression SynergyDateName(this Expression expression, string datePart)
        {
            var method = typeof(SqlFunctions).GetMethod("DateName", new Type[] { typeof(string), typeof(DateTime?) });
            var arg1 = Expression.Constant(datePart);
            var arg2 = expression.SynergyConvert(typeof(DateTime?));
            return Expression.Call(method, arg1, arg2);
        }

        /// <summary>
        /// SynergyConvert operation
        /// </summary>
        public static Expression SynergyConvert(this Expression expression, Type type)
        {
            return Expression.Convert(expression, type);
        }

        /// <summary>
        /// SynergyStringConvert operation
        /// </summary>
        public static Expression SynergyStringConvert(this Expression memberExpression)
        {
            var method = typeof(SqlFunctions).GetMethod("StringConvert", new Type[] { typeof(decimal?) });
            var arg = Expression.Convert(memberExpression, typeof(decimal?));
            return Expression.Call(method, arg);
        }

        /// <summary>
        /// SynergyPrepend operation
        /// </summary>
        public static Expression SynergyPrepend(this Expression expression, string value)
        {
            var method = typeof(string).GetMethod("Concat", new Type[] { typeof(object), typeof(object) });
            var arg = Expression.Constant(value);
            return Expression.Add(arg, expression, method);
        }

        /// <summary>
        /// SynergyAdd operation
        /// </summary>
        public static Expression SynergyAdd(this Expression expression1, Expression expression2)
        {
            var method = typeof(string).GetMethod("Concat", new Type[] { typeof(object), typeof(object) });
            return Expression.Add(expression1, expression2, method);
        }

        /// <summary>
        /// SynergySubtract operation
        /// </summary>
        public static Expression SynergySubtract(this Expression expression, int value)
        {
            var arg = Expression.Constant(value);
            return Expression.Subtract(expression, arg);
        }

        /// <summary>
        /// SynergyLeft operation
        /// </summary>
        public static Expression SynergyLeft(this Expression expression, int length)
        {
            var method = typeof(string).GetMethod("Substring", new Type[] { typeof(int), typeof(int) });
            var arg1 = Expression.Constant(0);
            var arg2 = Expression.Constant(length);
            return Expression.Call(expression, method, arg1, arg2);
        }

        /// <summary>
        /// SynergyRight operation
        /// </summary>
        public static Expression SynergyRight(this Expression expression, int length)
        {
            var method = typeof(string).GetMethod("Substring", new Type[] { typeof(int) });
            var arg = expression.SynergyLength().SynergySubtract(length);
            return Expression.Call(expression, method, arg);
        }

        /// <summary>
        /// SynergyLength operation
        /// </summary>
        public static Expression SynergyLength(this Expression expression)
        {
            var property = typeof(string).GetProperty("Length");
            return Expression.Property(expression, property);
        }
    }
}
