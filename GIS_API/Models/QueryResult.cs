using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIS_API.Models
{
    public partial class QueryResult : SdeRepository<QueryResult>
    {  
        public static List<dynamic> RunAnyQuery(string sql)
        {
            var result = new List<dynamic>();            
            var typeRow = new Dictionary<string, object>(); //optionally store the datatypes here if you want to see them

            using (var ctx = new OracleSdeContext())
            using (var cmd = ctx.Database.Connection.CreateCommand())
            {
                ctx.Database.Connection.Open();
                cmd.CommandText = sql;

                using (var reader = cmd.ExecuteReader())
                {
                    var rowIndex = 0;

                    //var schemaTable = reader.GetSchemaTable();
                    while (reader.Read())
                    {
                        var data = new Dictionary<string, object>();                        

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var value = reader.GetValue(i);

                            //when the type is DateTime, the value must be converted to a string
                            if (reader.GetFieldType(i).ToString() == "System.DateTime")
                            {
                                value = value.ToString();
                            }

                            data.Add(reader.GetName(i), value);

                            //for creating a row at the end with describing the data types of each value
                            //if (rowIndex == 0)
                            //{
                                //typeRow.Add(reader.GetName(i), reader.GetFieldType(i).ToString());
                            //}
                        }                        
                        
                        
                        result.Add(data);

                        rowIndex++;
                    }
                }
            }

            if (typeRow.Count() > 0)
            {
                result.Add(typeRow);
            }

            return result;
        }
    }
    public partial class AdminQueryResult : AdminRepository<AdminQueryResult>
    {
        public static List<dynamic> RunAnyQuery(string sql)
        {
            var result = new List<dynamic>();
            var typeRow = new Dictionary<string, object>(); //optionally store the datatypes here if you want to see them

            using (var ctx = new AdminOracleContext())
            using (var cmd = ctx.Database.Connection.CreateCommand())
            {
                ctx.Database.Connection.Open();
                cmd.CommandText = sql;

                using (var reader = cmd.ExecuteReader())
                {
                    var rowIndex = 0;

                    //var schemaTable = reader.GetSchemaTable();
                    while (reader.Read())
                    {
                        var data = new Dictionary<string, object>();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var value = reader.GetValue(i);

                            //when the type is DateTime, the value must be converted to a string
                            if (reader.GetFieldType(i).ToString() == "System.DateTime")
                            {
                                value = value.ToString();
                            }

                            data.Add(reader.GetName(i), value);

                            //for creating a row at the end with describing the data types of each value
                            //if (rowIndex == 0)
                            //{
                            //typeRow.Add(reader.GetName(i), reader.GetFieldType(i).ToString());
                            //}
                        }


                        result.Add(data);

                        rowIndex++;
                    }
                }
            }

            if (typeRow.Count() > 0)
            {
                result.Add(typeRow);
            }

            return result;
        }
    }
}