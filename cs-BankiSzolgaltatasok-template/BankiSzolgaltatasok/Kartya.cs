using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class Kartya : BankiSzolgaltatas
    {
        private string kartyaSzam;
        private Szamla szamla;

        public string KartyaSzam { get => kartyaSzam; }

        public Kartya(Tulajdonos tulajdonos, Szamla szamla, string kartyaSzam) : base(tulajdonos)
        {
            this.kartyaSzam = kartyaSzam;
            this.szamla = szamla;
        }

        public bool Vasarlas(int osszeg)
        {
            if (this.szamla.AktualisEgyenleg - osszeg >= 0)
            {
                szamla.Kivesz(osszeg);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
