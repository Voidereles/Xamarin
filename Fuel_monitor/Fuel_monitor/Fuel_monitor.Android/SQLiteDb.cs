using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Fuel_monitor.Droid;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Fuel_monitor.Droid
{
    public class SQLiteDb : ISQLiteDb
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);

        }
    }
}
