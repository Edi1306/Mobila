using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mobila.Models
{
    public class Antrenor
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        public DateTime Date { get; set; }

    }
}
