using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Fuel_monitor;
using Fuel_monitor.UWP;
using Windows.Storage;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Fuel_monitor.UWP
{
    public class SQLiteDb : ISQLiteDb
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}

