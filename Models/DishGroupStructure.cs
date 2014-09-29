using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StolowkaSQL.Models
{
    public class DishGroupStructure
    {
        public string Key { get; set; }
        public string Description{ get; set; }

        public DishGroupStructure(string Key, string Opis)
        {
            this.Key = Key;
            this.Description = Opis;
        }
    }
}
