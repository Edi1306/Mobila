using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Mobila.Models
{
    public class ListaClient
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Antrenor))]
        public int AntrenorID { get; set; }

        public int ClientID { get; set; }
    }
}