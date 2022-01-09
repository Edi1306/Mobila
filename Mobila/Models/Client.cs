using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Mobila.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nume { get; set; }
        [OneToMany]
        public List<ListaClient> ListaClienti { get; set; }
    }

}
