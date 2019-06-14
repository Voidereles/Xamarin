using System;
using System.Collections.Generic;
using System.Text;

namespace Fuel_monitor.Models
{
    class Refueling_data
    {
        public int Przebieg { get; set; }
        public float Zatankowano { get; set; }
        public float Cena_litra { get; set; }
        public float Koszt { get; set; }
        public DateTime Data_tankowania { get; set; }
    }
}
