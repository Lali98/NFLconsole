using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFL
{
    internal class Adatbazis
    {
        private string feladat(int sorsam)
        {
            return $"{sorsam}. feladat";
        }

        List<Jatekos> jatekosok = new List<Jatekos>();

        public void beolvas(string faljnev)
        {
            string[] falj = File.ReadAllLines(faljnev);
            for(int i = 0; i < falj.Length; i++)
            {
                jatekosok.Add(new Jatekos(falj[i]));
            }
        }

        public void feladat5()
        {
            Console.WriteLine($"{feladat(5)}: A statistikában {jatekosok.Count} iranyitó szerepel.");
        }

        public void feladat7()
        {
            Console.WriteLine($"{feladat(7)}: Legjobb irányitok:");

            for(int i = 0; i < jatekosok.Count; i++)
            {
                if (jatekosok[i].Iranymutato >= 100 && jatekosok[i].YardokMeter >= 4000)
                {
                    Console.WriteLine($"\t{jatekosok[i].F_nev} (Irányító mutató: {jatekosok[i].Iranymutato}. Passzok: {jatekosok[i].YardokMeter}m.)");
                }
            }
        }

        public void feladat8()
        {
            Console.Write($"{feladat(8)}: Eladott labdák száma: ");
            int szam = int.Parse(Console.ReadLine());
            List<string> e_jatekosok = new List<string>();

            for(int i = 0; i < jatekosok.Count; i++)
            {
                if(szam < jatekosok[i].Eladott_labdak)
                {
                    e_jatekosok.Add(jatekosok[i].F_nev);
                }
            }
            e_jatekosok.Sort();
            File.WriteAllLines("legtobbeladott.txt", e_jatekosok);
        }

        public void feladat9()
        {
            Console.WriteLine($"{feladat(9)}: Legtöbb TD-t szertő játékos:");
            Jatekos max = jatekosok[0];
            for(int i = 1; i < jatekosok.Count; i++)
            {
                if(max.Td < jatekosok[i].Td)
                {
                    max = jatekosok[i];
                }
            }
            Console.WriteLine($"\tNeve: {max.Nev}");
            Console.WriteLine($"\tTD-k száma: {max.Td}");
            Console.WriteLine($"\tEladott labdák száma: {max.Eladott_labdak}");
        }

        public void feladat10()
        {
            Console.WriteLine($"{feladat(10)}: Legsikeresebb egyetemek:");
            Dictionary<string, int> szotar = new Dictionary<string, int>();
            for(int i = 0; i < jatekosok.Count; i++)
            {
                if (szotar.ContainsKey(jatekosok[i].Egyetem))
                {
                    szotar[jatekosok[i].Egyetem]++;
                }
                else
                {
                    szotar.Add(jatekosok[i].Egyetem, 1);
                }
            }

            foreach(var item in szotar)
            {
                if(item.Value > 1)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
        }
    }
}
