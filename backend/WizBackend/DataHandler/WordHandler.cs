using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace WizBackend.DataHandler
{
    public class WordHandler
    {

        static private string connectionString = @"Data Source = database\Dictionary.db; 
                                    Version=3; FailIfMissing=True; Foreign Keys = True;";

        public static List<String> LookUpWord(string parts)
        {
            List<String> MatchingWords = new List<String>();
            SQLiteConnection e = new SQLiteConnection(connectionString, true);
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM Words w WHERE w.value like @part";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        //cmd.Parameters.Add("@part", DbType.String);
                        SQLiteParameter parameter = new SQLiteParameter("@part", DbType.String);
                        //parameter.Value = ez;
                        cmd.Parameters.AddWithValue("@part", parts + "%");
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MatchingWords.Add(reader["value"].ToString());
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException exp)
            {
                throw exp;
            }

            return MatchingWords;

        }
    }
}
