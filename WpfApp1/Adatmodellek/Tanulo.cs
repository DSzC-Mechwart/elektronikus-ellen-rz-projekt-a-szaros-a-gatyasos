using System.Collections.Generic;

namespace Adatmodellek
{
    public class Tanulo
    {
        public string Nev { get; set; }
        public List<Targy> Targyak { get; set; } = new List<Targy>();
    }
}
