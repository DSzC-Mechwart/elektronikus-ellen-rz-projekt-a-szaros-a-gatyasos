using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ellenorzowpf2
{
    internal class Tantargy
    {
        public Tantargy(string tantargyak, int evfolyam, string kozvszak, int hetioraszam, int evesOraSzam)
        {
            Tantargyak = tantargyak;
            Evfolyam = evfolyam;
            Kozvszak = kozvszak;
            Hetioraszam = hetioraszam;
            EvesOraSzam = evesOraSzam;
        }

        public string Tantargyak { get; set; }
        public int Evfolyam { get; set; }
        public string Kozvszak { get; set; }
        public int Hetioraszam { get; set; }
        public int EvesOraSzam { get; set; }
    }

}

