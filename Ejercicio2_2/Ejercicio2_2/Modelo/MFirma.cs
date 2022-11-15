using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2_2.Modelo
{
    public class MFirma
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set;}
        public string firma { get; set; }
    }
}
