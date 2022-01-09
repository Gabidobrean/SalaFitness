using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Mobil.Models
{
    public class Antrenori
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        [OneToMany]
        public List<Cursuri> AntrenoriList { get; set; }
        public string Nume { get; set; }
        public string Ziua { get; set; }
        public DateTime Ora { get; set; }
    }
}
