using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Orca_FO_v2._12._0.Utils
{
    public class DataTableUtilities
    {
        sealed class Tuple<T1, T2>
        {
            public Tuple() { }

            public Tuple(T1 value1, T2 value2)
            {
                Value1 = value1; Value2 = value2;
            }
            public T1 Value1 { get; }
            public T2 Value2 { get; }
        }

        public static List<T> Convert<T>(DataTable table)
            where T : class, new()
        {
            if (table == null)
            {
                return new List<T>();
            }
            var map = (
                from pi in typeof(T).GetProperties()
                where pi != null &&
                      table.Columns.Contains(pi.Name)
                select new Tuple<DataColumn, PropertyInfo>(table.Columns[pi.Name], pi)
            ).ToList();

            var list = new List<T>(table.Rows.Count);
            foreach (DataRow row in table.Rows)
            {
                if (row == null)
                {
                    list.Add(null);
                    continue;
                }
                var item = new T();
                ConvertRowValue(map, row, item);
                list.Add(item);
            }
            return list;
        }

        private static void ConvertRowValue<T>(List<Tuple<DataColumn, PropertyInfo>> map, DataRow row, T item) where T : class, new()
        {
            foreach (var pair in map)
            {
                var value = row[pair.Value1];

                if (value is DBNull) value = null;
                var maintype = (Nullable.GetUnderlyingType(pair.Value2.PropertyType) ?? pair.Value2.PropertyType);
                if (string.Equals(pair.Value2.Name, "timestamp", StringComparison.InvariantCultureIgnoreCase))
                {
                    pair.Value2.SetValue(item, null, null);
                }
                else if (



                string.Equals(
                        value?.GetType().FullName,
                        typeof(Int64).FullName,
                        StringComparison.CurrentCultureIgnoreCase)
                    || string.Equals(
                        value?.GetType().FullName,
                        typeof(Double).FullName,
                        StringComparison.CurrentCultureIgnoreCase))
                {
                    object setval;

                    if (string.Equals(value?.GetType().FullName, typeof(Int64).FullName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        value = System.Convert.ChangeType(value, typeof(Int32));
                    }
                    setval = System.Convert.ChangeType(value, maintype);
                    pair.Value2.SetValue(item, setval, null);
                }
                else
                {
                    try
                    {
                        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                        {
                            pair.Value2.SetValue(item, null, null);
                        }
                        else
                        {
                            var setval = System.Convert.ChangeType(value, maintype);
                            pair.Value2.SetValue(item, setval, null);
                        }

                    }
                    catch (Exception e)
                    {
                        pair.Value2.SetValue(item, value, null);
                    }

                }


                //var setval = System.Convert.ChangeType(value, pair.Value2.PropertyType);
                //pair.Value2.SetValue(item, value, null);
            }
        }

        public static T ConvertRow<T>(DataRow row)
            where T : class, new()
        {
            if (row == null)
            {
                return null;
            }
            var table = row.Table;

            var map = (
                from pi in typeof(T).GetProperties()
                where pi != null && table.Columns.Contains(pi.Name)
                select new Tuple<DataColumn, PropertyInfo>(table.Columns[pi.Name], pi)
            ).ToList();


            var item = new T();
            ConvertRowValue(map, row, item);

            return item;
        }


        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table mo
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            DataColumnCollection columns = dataTable.Columns;
            if (columns.Contains("TSBarEndDateTime"))
            {
                dataTable.Columns["TSBarEndDateTime"].DateTimeMode = DataSetDateTime.Utc;

            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows         
                    values[i] = Props[i].GetValue(item, null); 
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
