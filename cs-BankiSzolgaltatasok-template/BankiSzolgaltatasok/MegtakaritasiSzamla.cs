using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class MegtakaritasiSzamla : Szamla
    {
        private double kamat;
        public static double alapKamat = 1.1;

        public MegtakaritasiSzamla(Tulajdonos tulajdonos) : base(tulajdonos)
        {
            this.kamat = alapKamat;
        }

        public double AlapKamat { get => alapKamat; set => alapKamat = value; }
        public double Kamat { get => kamat; set => kamat = value; }

        public override bool Kivesz(int osszeg)
        {
            if (this.aktualisEgyenleg - osszeg >= 0)
            {
                this.aktualisEgyenleg -= osszeg;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void KamatJovairas()
        {
            this.aktualisEgyenleg = (int)(this.aktualisEgyenleg * kamat);
        }
    }
}
