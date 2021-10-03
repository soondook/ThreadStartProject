﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace ThreadStartProject
{
    public static class DBSQLServerUtils
    {

        class MyClass1
        {
            public string Ip { get; set; }
            public string CompassName { get; set; }
        }
        public static string ValidateDefaultInstancePostgreSqlServer(string found)
        {
            string expt = "Close";
            try
            {
                using NpgsqlConnection postGresConnection = new NpgsqlConnection
                {
                    ConnectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=pa$$word;Pooling=true;MinPoolSize=1;MaxPoolSize=100;Command Timeout=600;Timeout=600;"
                };
                using (NpgsqlCommand checkDBCommand = postGresConnection.CreateCommand())
                {
                    postGresConnection.Open();
                    Console.WriteLine(postGresConnection.State);
                    found = postGresConnection.State.ToString();
                    found.ToString();
                }
                postGresConnection.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                expt = ex.ToString();
            }
            if (found.ToString().StartsWith("Open"))
            {
                expt = found.ToString();
            }
            else
            {
                return "IsConnect :" + expt.ToString() + "\n";
            }

            return "IsConnect :" + expt.ToString() + "\n";
        }

        
        public static string Connection(string host)
        {
            object ip = "";
            DataTable Returndata;
            Console.WriteLine("Connection for select was successful!" + "'" + $"{host}" + "'");
            string q = "SELECT ip, compassname FROM dbo.techparam where compassname =" + "'" + $"{host}" + "'";
            //string connection = "Server=172.16.0.162;Port=5432;Database=AtmBase;User Id=postgres;Password=g7712316;Pooling=true;MinPoolSize=1;MaxPoolSize=100;Command Timeout=600;Timeout=600;";
            //string query = "select id, ldap_login, password, psswd_encr from dbo.atm_user where psswd_encr is null LIMIT 6000";
            string connString = string.Format("Server={0};Port={1};" + "User Id={2};Password={3};Database={4};", "127.0.0.1", "5432", "postgres", "pa$$word", "postgres");
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            //NpgsqlConnection conn = new NpgsqlConnection(connection);
            Returndata = DataTablesReturn(q, connection);
            for (int i = 0; i < Returndata.Rows.Count; i++)
            {
                ip = Returndata.Rows[i].ItemArray[0];
                Console.WriteLine(ip.ToString());
            }
            Returndata.Dispose();
            connection.Dispose();
            if (ip.ToString().StartsWith("10")) { return ip.ToString(); }
            //if (ip.ToString().StartsWith("10")) { return ip.ToString(); }
            else
            {
                return "Not Found ATM IP";
            }
            //return ip.ToString();
        }

        public static string Connection2(string host)
        {
            //JObject obj2 = new JObject();
            object ip;
            object compassname;
            List<string> pointList = new List<string>() { };
            List<MyClass1> newData = new List<MyClass1>() { };
            DataTable Returndata;
            Console.WriteLine("Connection for select was successful!" + "'" + $"{host}" + "'");
            //string q = "SELECT DISTINCT ip, compassname FROM public.techparam where compassname =" + "'" + $"{host}" + "'";
            string q = "SELECT DISTINCT ip, compassname FROM public.techparam where compassname in ('ACER-Aspire', 'Workstation-W10')";
            //string connection = "Server=172.16.0.162;Port=5432;Database=AtmBase;User Id=postgres;Password=g7712316;Pooling=true;MinPoolSize=1;MaxPoolSize=100;Command Timeout=600;Timeout=600;";
            //string query = "select id, ldap_login, password, psswd_encr from dbo.atm_user where psswd_encr is null LIMIT 6000";
            string connString = string.Format("Server={0};Port={1};" + "User Id={2};Password={3};Database={4};", "127.0.0.1", "5432", "postgres", "pa$$word", "postgres");
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            Returndata = DataTablesReturn(q, connection);
            for (int i = 0; i < Returndata.Rows.Count; i++)
            {
                ip = Returndata.Rows[i].ItemArray[0];
                compassname = Returndata.Rows[i].ItemArray[1];
                /*
                obj2[$"{i}"] = $"{i}";
                obj2[$"ip"] = $"{ip}";
                obj2[$"compassname"] = $"{compassname}";
                */
                //string[] input = { "Ip: " + ip, "CompassName: " + compassname };
                newData.AddRange(new List<MyClass1>() { new MyClass1() { Ip = ip.ToString(), CompassName = compassname.ToString() } });
                //pointList.AddRange(input);
                //pointList.Add(input);
            }
            //Console.WriteLine(pointList.Count);
            Returndata.Dispose();
            connection.Dispose();

            var jsons = JsonConvert.SerializeObject(new
            {
                key = newData
            });

            //Console.WriteLine(jsons);
            return jsons.Trim();
            
        }

        public static DataTable DataTablesReturn(string query, NpgsqlConnection conn)
        {
            DataTable dates = new DataTable();
            dates.Clear();
            conn.Open();
            NpgsqlCommand myCommand = new NpgsqlCommand(query, conn);
            if (query.TrimStart().ToUpper().StartsWith("SELECT"))
            {
                NpgsqlDataReader DataRead = myCommand.ExecuteReader();
                dates.Load(DataRead);
                myCommand.Dispose();
            }
            else
            {
                myCommand.ExecuteNonQuery();
            }
            conn.Dispose();
            //Console.WriteLine($"{dates.Rows[1].ItemArray[1]}, {dates.Rows[1].ItemArray[2]}");
            return dates;
        }


        public static int Update_fromConnection(NpgsqlConnection connection, int rows, string password, string ldap, string Result_RSA, string connString)
        {
            NpgsqlConnectionStringBuilder sConnB = new NpgsqlConnectionStringBuilder(connString);
            NpgsqlConnection conn = new NpgsqlConnection(sConnB.ConnectionString);

            if (conn.State == ConnectionState.Closed)
            {
                Console.WriteLine("Connection status Closed: " + conn.State);
                try
                {
                    connection = new NpgsqlConnection(connString);
                    connection.Open();
                    Console.WriteLine(connection.State);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }

            }
            else
            {
                Console.WriteLine($"Connection for update was successful!" + connection.State);
            }

            if (connection.State == ConnectionState.Open)
            {
                string q = "update atm_user set pwd_encrypt = @rsa where ldap like @cnm";
                NpgsqlCommand cmd = new NpgsqlCommand(q, connection);
                cmd.Parameters.AddWithValue("@cnm", ldap);
                //cmd.Parameters.AddWithValue("@ln", p_enc);
                //cmd.Parameters.AddWithValue("@em", pass);
                cmd.Parameters.AddWithValue("@rsa", Result_RSA);
                try
                {
                    rows = cmd.ExecuteNonQuery();
                    rows += rows;
                }
                catch (NpgsqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                cmd.Dispose();
            }
            return rows;
        }
    }
}


