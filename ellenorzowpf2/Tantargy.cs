using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ellenorzowpf2
{
    internal class Tantargy
    {
        public Tantargy(string tantargyak, string evfolyam, string kozvszak, string hetioraszam)
        {
            Tantargyak = tantargyak;
            Evfolyam = evfolyam;
            Kozvszak = kozvszak;
            Hetioraszam = hetioraszam;
        }

        public string Tantargyak { get; set; }
        public string Evfolyam { get; set; }
        public string Kozvszak { get; set; }
        public string Hetioraszam { get; set; }
    }
}

