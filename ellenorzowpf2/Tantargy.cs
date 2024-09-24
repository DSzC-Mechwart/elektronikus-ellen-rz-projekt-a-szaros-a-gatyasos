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

        public string Tantargyak { get; set; }
        public int Evfolyam { get; set; }
        public string Kozvszak { get; set; }
        public int Hetioraszam { get; set; }
        public int EvesOraSzam { get; set; }
        /*public int EvesOraszamFugg(int szam)
        {
            if (Evfolyam == 11 || Evfolyam == 10 || Evfolyam == 9)
            {
                return Hetioraszam * 36;
            }
            else if (Evfolyam == 12)
            {
                if (Kozvszak == "k")
                {
                    return Hetioraszam * 31;
                }
                else if (Kozvszak == "sz")
                {
                    return Hetioraszam * 36;
                }
            }
            else
            {
                return Hetioraszam * 31;
            }
        }*/
    }

}

