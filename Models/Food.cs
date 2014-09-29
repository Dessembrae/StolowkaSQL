using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StolowkaSQL.Models
{
    public class Food
    {
        public string Id { get; set; }
        public string Nazwa { get; set; }
        public bool Active { get; set; }
        public bool DishOfDay { get; set; }

        public Food(string Id, string Nazwa, bool Active, bool DanieDnia)
            {
                this.Id = Id;
                this.Nazwa = Nazwa;
                this.Active = Active;
                this.DishOfDay = DanieDnia;
            }

        public override string ToString()
        {
            return Nazwa + " " + Active.ToString() + " " + DishOfDay.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Food))
                return false;

            if (this.Nazwa == ((Food)obj).Nazwa && this.Active == ((Food)obj).Active && this.DishOfDay == ((Food)obj).DishOfDay)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Nazwa.GetHashCode() ^ Active.GetHashCode() ^ DishOfDay.GetHashCode();
        }

        public Food DeepCopy()
        {
            Food othercopy = (Food)this.MemberwiseClone();
            return othercopy;
        }

    }
}
