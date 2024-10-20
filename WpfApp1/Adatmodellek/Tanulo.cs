using System.Collections.Generic;
using System.Linq;

namespace Adatmodellek
{
    public class Tanulo
    {
        public string Nev { get; set; }
        public List<Targy> Targyak { get; set; } = new List<Targy>();
    }
}
