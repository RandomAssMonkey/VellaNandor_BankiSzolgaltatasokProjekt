using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public sealed class Tulajdonos
    {
        private string nev;

        public Tulajdonos(string name)
        {
            this.Nev = name;
        }

        public string Nev { get => nev; set => nev = value; }
    }
}
