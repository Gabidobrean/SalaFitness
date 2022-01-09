using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Mobil.Models
{
    public class Cursuri
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(AbonamenteList))]
        public string Denumire { get; set; }
        public string Dificultate { get; set; }
    }
}
