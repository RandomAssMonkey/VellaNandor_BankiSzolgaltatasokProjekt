using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class Bank
    {
        List<Szamla> szamlaLista = new List<Szamla>();

        public long OsszHitelkeret
        {
            get
            {
                long ossz = 0;
                foreach (var item in szamlaLista)
                {
                    if (item.GetType() == typeof(HitelSzamla))
                    {
                        ossz += ((HitelSzamla)item).HitelKeret;
                    }
                }
                return ossz;
            }
        }

        public Szamla SzamlaNyitas(Tulajdonos tulajdonos, int hitelKeret)
        {
            Szamla szamla;
            if (hitelKeret < 0)
            {
                throw new ArgumentException("hibas");
            }
            else if (hitelKeret > 0)
            {
                szamla = new HitelSzamla(tulajdonos, hitelKeret);
                szamlaLista.Add(szamla);
                return szamla;
            }
            else
            {
                szamla = new MegtakaritasiSzamla(tulajdonos);
                szamlaLista.Add(szamla);
                return szamla;
            }

        }
        public long GetOsszEgyenleg(Tulajdonos tulajdonos)
        {
            long a = 0;
            foreach (var item in szamlaLista)
            {
                if (item.Tulajdonos == tulajdonos)
                {
                    a += item.AktualisEgyenleg;
                }
            }
            return a;
        }

        public Szamla GetLegnagyobbEgyenleguSzamla(Tulajdonos tulajdonos)
        {

            List<Szamla> legnagyobbLista = new List<Szamla>();
            foreach (Szamla item in szamlaLista)
            {
                if (item.Tulajdonos.Equals(tulajdonos))
                {
                    legnagyobbLista.Add(item);
                }
            }
            Szamla max = legnagyobbLista[0];
            foreach (Szamla item in szamlaLista)
            {
                if (item.Tulajdonos.Equals(tulajdonos) && item.AktualisEgyenleg > max.AktualisEgyenleg)
                {
                    max = item;
                }
            }
            return max;
        }
    }
}
