using System.Collections.Generic;
using System.Linq;

namespace TanuloApp
{
    public class Tanulo
    {
        public string Nev { get; set; }
        public List<Targy> Targyak { get; set; }

        public double OsszesitettAtlag => Targyak.Average(t => t.Atlag);

        public bool LemorzsolodassalVeszelyeztetett => Targyak.Count(t => t.Atlag < 1.75) >= 3;
    }
}
