using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;



namespace ThreadStartProject
{
    internal class SplitClass
    {
        public static void SSplit(string s)
        {
            //string s;
            string v = null;
            string[] newstr;
            Console.WriteLine("Enter the email addresses: ");
            //s = "Україна,область Дніпропетровська,місто Дніпро,вулиця Набережна Перемоги,будинок 32 в 0 м від Вас";
            newstr = s.Split(new char[] { ',' }); // Split to get a temporal array of addresses 
            var ele = newstr.Skip(2);
            foreach (var str in ele)
            {
                //Console.WriteLine (str);
                v += str + ", ";
            }
            v = v.TrimEnd(new char[] { ',', ' ' });
            Console.WriteLine(v);
            //newstr = s.Split(new char[] { ',', ';' }).Skip(1);
            //Console.WriteLine(s.Substring(s.IndexOf(','))); // Extract the sender from the email addresses
            //Console.WriteLine(s.Split(',').Skip(1));

            string st = "Україна,область Дніпропетровська,місто Дніпро,вулиця Набережна Перемоги,будинок 32 в 0 м від Вас";

            Console.WriteLine(string.Join(",", st.Split(',', StringSplitOptions.RemoveEmptyEntries).Skip(2)));

            SSplitSQL(st);

        }

        public static void SSplitSQL(string sql)
        {

            SqlCommand cmd = new SqlCommand();            
            var SQL0 = "SELECT * FROM [database] WHERE material_id IN (select value from string_split('{0}'))";

            var idList = new List<string> { "CADN111", "CADN123", "CADN1234" };
            string[] idListArray = idList.ToArray();
            cmd.CommandText = string.Format(SQL0, string.Join("','", idListArray));
            Console.WriteLine(cmd.CommandText.ToString());

            /*
            var SQL0 = "SELECT * FROM [database] WHERE material_id IN ({0})";
            var idList = new List<int> { 11, 53, 125 };
            var idParameterList = new List<string>();
            var pms = new List<SqlParameter>();
            int count = 1;
            foreach (var id in idList)
            {
                var paramName = "@idParam" + count++;
                SqlParameter p = new SqlParameter(paramName, SqlDbType.Int);
                p.Value = id;
                pms.Add(p);
                idParameterList.Add(paramName);
            }
            string cmdText = String.Format(SQL0, string.Join(",", idParameterList));
            var datainput = context.materials.SqlQuery(cmdText, pms);
            */
        }
            public static void SSplitSQL2(string sql)
            {

            SqlCommand cmd = new SqlCommand();
            var SQL0 = "SELECT * FROM [database] WHERE material_id IN (select value from string_split('@ids'))";
            SqlParameter op1 = new SqlParameter();
            //op1.ParameterName = "@ItemKey";
            op1.SqlDbType = SqlDbType.Int;
            var idList = new List<string> { "CADN111", "CADN123", "CADN1234" };
            string[] idListArray = idList.ToArray();
            cmd.CommandText = SQL0;
            var cmdText = cmd.Parameters.Add("@ids", SqlDbType.VarChar, -1).Value = string.Join("','", idListArray);
            Console.WriteLine(cmdText.ToString());

        }

    }
}
