using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace WizBackend.DataHandler
{
    public class WordHandler
    {

        static private string connectionString = @"Data Source = C:\Users\Daniel Hollmann\Documents\Development\Source\wizfile\database\Dictionary.db; 
                                    Version=3; FailIfMissing=True; Foreign Keys = True;";

        public static void LookUpWord(string parts)
        {
            List<String> MatchingWords = new List<String>();
            SQLiteConnection e = new SQLiteConnection(connectionString, true);
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM Words w WHERE w.value like 'e%'";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
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

            Console.WriteLine(MatchingWords.Count);

        }
    }
}
