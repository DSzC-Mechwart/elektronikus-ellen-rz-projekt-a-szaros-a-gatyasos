using System.Collections.Generic;
using System.Linq;

namespace Adatmodellek
{
    public class Targy
    {
        public string Nev { get; set; }
        public List<Jegy> Jegyek { get; set; } = new List<Jegy>();

        public double Atlag => Jegyek.Count > 0 ? Jegyek.Average(j => j.Ertek) : 0;
    }
}
