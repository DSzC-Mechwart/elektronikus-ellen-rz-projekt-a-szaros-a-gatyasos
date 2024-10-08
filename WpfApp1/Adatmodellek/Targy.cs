using System.Collections.Generic;

namespace Adatmodellek
{
    public class Targy
    {
        public string Nev { get; set; }
        public List<Jegy> Jegyek { get; set; } = new List<Jegy>();

        public double Atlag
        {
            get
            {
                if (Jegyek.Count == 0) return 0;
                double sum = 0;
                foreach (var jegy in Jegyek)
                {
                    sum += jegy.Ertek;
                }
                return sum / Jegyek.Count;
            }
        }
    }
}
