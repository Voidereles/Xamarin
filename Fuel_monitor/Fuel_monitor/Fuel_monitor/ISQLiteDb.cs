using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Fuel_monitor
{
    public interface ISQLiteDb
    {
        string GetLocalFilePath(string filename);
    }
}