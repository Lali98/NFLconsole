using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFL
{
    internal class Jatekos
    {
        public string Nev { get; private set; }
        public string F_nev
        {
            get
            {
                return FormazottNev(Nev);
            }
            private set
            {

            }
        }
        public int Passzol_yard { get; private set; }
        public int Passz_kiserletek { get; private set; }
        public int Sikeres_passzol { get; private set; }
        public int Td { get; private set; }
        public int Eladott_labdak { get; private set; }
        public double Iranymutato { get; private set; }
        public string Egyetem { get; private set; }
        public int YardokMeter
        {
            get
            {
                return (int)Math.Round(Passzol_yard * 0.9144);
            }
            private set
            {

            }
        }

        public Jatekos(string bemenet)
        {
            string[] adat = bemenet.Split(';');
            Nev = adat[0];
            Passzol_yard = int.Parse(adat[1]);
            Passz_kiserletek = int.Parse(adat[2]);
            Sikeres_passzol = int.Parse(adat[3]);
            Td = int.Parse(adat[4]);
            Eladott_labdak = int.Parse(adat[5]);
            Iranymutato = Konvertal(adat[6]);
            Egyetem = adat[7];
        }

        private double Konvertal(string iranyitoMutato)
        {
            var decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            iranyitoMutato = iranyitoMutato.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            if (double.TryParse(iranyitoMutato, out var ertek))
                return ertek;
            throw new FormatException("Hibás érték (irányítómutató)");
        }

        public string FormazottNev(string nev)
        {
            var n = nev.Split(' ');
            n[n.Length - 1] = n[n.Length - 1].ToUpper();
            return string.Join(" ", n);
        }
    }
}
