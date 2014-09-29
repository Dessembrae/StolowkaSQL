using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StolowkaSQL.Models
{
    public class GrupyStructure
    {
        public string Klucz { get; set; }
        public string Opis{ get; set; }

        public GrupyStructure(string klucz, string opis)
        {
            this.Klucz = klucz;
            this.Opis = opis;
        }
    }
}
