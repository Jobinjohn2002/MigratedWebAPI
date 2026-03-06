using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Column Property Mapping
    /// </summary>
    /// <summary>
    /// ColumnPropertyMapping
    /// </summary>
    public class ColumnPropertyMapping
    {
        /// <summary>
        /// The column name
        /// </summary>
        /// <summary>
        /// Gets or sets ColumnName
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// The property name
        /// </summary>
        /// <summary>
        /// Gets or sets PropertyName
        /// </summary>
        public string PropertyName { get; set; }
    }

    /// <summary>
    /// IEnumerable extension class
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Converts a collection of integers to a strongly typed data table
        /// </summary>
        /// <param name="items">The collection to convert</param>
        /// <param name="columnName">The name for the integer column in the data table</param>
        /// <returns>A strongly typed data table</returns>
        /// <summary>
        /// ToDataTable operation
        /// </summary>
        public static DataTable ToDataTable(this IEnumerable<int> items, string columnName)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            if (columnName == null)
            {
                throw new ArgumentNullException("columnName");
            }

            if (columnName.Length == 0)
            {
                throw new ArgumentException("columnName");
            }

            var table = new DataTable();

            table.Columns.Add(columnName, typeof(int));

            foreach (var item in items)
            {
                table.Rows.Add(new object[] { item });
            }

            return table;
        }

        /// <summary>
        /// Converts a generic collection to a strongly typed data table
        /// </summary>
        /// <typeparam name="T">The type of objects in the generic collection</typeparam>
        /// <param name="items">The collection of objects</param>
        /// <param name="mapping">The column to property mappings</param>
        /// <returns>A strongly typed data table</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> items, params ColumnPropertyMapping[] mapping) where T : class
        {
            return ToDataTable<T>(items, false, mapping);
        }

        /// <summary>
        /// Converts a generic collection to a strongly typed data table
        /// </summary>
        /// <typeparam name="T">The type of objects in the generic collection</typeparam>
        /// <param name="items">The collection of objects</param>
        /// <param name="includeIdentityColumn">True to include an auto-generated identify column with a name of "RowIdentity"</param>
        /// <param name="mapping">The column to property mappings</param>
        /// <returns>A strongly typed data table</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> items,  bool includeIdentityColumn, params ColumnPropertyMapping[] mapping) where T : class
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            if (mapping == null)
            {
                throw new ArgumentNullException("mapping");
            }

            if (mapping.Length == 0)
            {
                throw new ArgumentException("You must specify at least one ColumnPropertyMapping");
            }

            var type = typeof(T);
            var properties = new List<PropertyInfo>();
            var table = new DataTable();

            if (includeIdentityColumn)
            {
                table.Columns.Add("RowIdentity", typeof(int));
            }

            foreach (var m in mapping)
            {
                var brokenMappings = mapping.Where(map => string.IsNullOrEmpty(map.ColumnName) || string.IsNullOrEmpty(map.PropertyName));

                if (brokenMappings.Any())
                {
                    throw new ArgumentException("ColumnPropertyMapping contains an invalid item (ColumnName and/or PropertyName is null or empty)", "mapping");
                }
                    
                var property = type.GetProperty(m.PropertyName);

                if (property == null)
                {
                    throw new NullReferenceException("Type {0} does not contain a property named {1}".FormatWith(type.FullName, m.PropertyName));
                }

                var indexers = property.GetIndexParameters();

                if (indexers != null && indexers.Length > 0)
                {
                    throw new NotSupportedException("Cannot convert indexed property to a table column");
                }
                
                properties.Add(property);
                
                table.Columns.Add(m.ColumnName, property.PropertyType);
            }

            var propertyCount = properties.Count;
            var rowIndex = 1;
            var startIndex = includeIdentityColumn ? 1 : 0;
            foreach (var item in items)
            {
                var values = new object[propertyCount];

                if (includeIdentityColumn)
                {
                    values[0] = rowIndex;
                }

                for (var i = 0; i < propertyCount; i++)
                {
                    values[i + startIndex] = properties[i].GetValue(item, null);
                }

                table.Rows.Add(values);
                rowIndex++;
            }

            return table;
        }
    }
}
