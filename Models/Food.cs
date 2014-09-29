using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StolowkaSQL.Models
{
    public class Food
    {
        public string id { get; set; }
        public string nazwa { get; set; }
        public bool active { get; set; }
        public bool danieDnia { get; set; }

        public Food(string id, string nazwa, bool active, bool danieDnia)
            {
                this.id = id;
                this.nazwa = nazwa;
                this.active = active;
                this.danieDnia = danieDnia;
            }

        public override string ToString()
        {
            return nazwa + " " + active.ToString() + " " + danieDnia.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Food))
                return false;

            if (this.nazwa == ((Food)obj).nazwa && this.active == ((Food)obj).active && this.danieDnia == ((Food)obj).danieDnia)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode() ^ nazwa.GetHashCode() ^ active.GetHashCode() ^ danieDnia.GetHashCode();
        }

        public Food DeepCopy()
        {
            Food othercopy = (Food)this.MemberwiseClone();
            return othercopy;
        }

    }
}
