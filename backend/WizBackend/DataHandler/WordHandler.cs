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
            SQLiteConnection e = new SQLiteConnection(connectionString, true);
            e.Open();
            Console.Write("Bla");
        }
    }
}
