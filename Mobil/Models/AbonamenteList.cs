using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mobil.Models
{
    public class AbonamenteList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Tip { get; set; }
        public decimal Pret { get; set; }
        public string Curs { get; set; }
        public DateTime Date { get; set; }
    }
}
