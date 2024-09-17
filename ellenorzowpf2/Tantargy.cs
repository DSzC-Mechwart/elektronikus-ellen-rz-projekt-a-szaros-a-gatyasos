using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ellenorzowpf2
{
    internal class Tantargy
    {
        public Tantargy(string tantargyak, int evfolyam, string kozvszak, int hetioraszam)
        {
            Tantargyak = tantargyak;
            Evfolyam = evfolyam;
            Kozvszak = kozvszak;
            Hetioraszam = hetioraszam;
        }

        string Tantargyak { get; set; }
        int Evfolyam { get; set; }
        string Kozvszak { get; set; }
        int Hetioraszam { get; set; }
    }
}
}
