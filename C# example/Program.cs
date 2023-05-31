using System;
using System.Collections.Generic;
using System.IO;

namespace torna2008_doga
{
    class Program
    {
        static List<Versenyzo> versenyzok = new List<Versenyzo>();
        static void Main(string[] args)
        {
            FileRead();
            Console.WriteLine($"2. feladat\n Összesen {versenyzok.Count} versenyzo indult az olimpián.");
            Console.WriteLine($"3. feladat\n Korláton {KorlatTop1()} szerezte meg az aranyérmet");
            GyuruEredmenyKereso();
            NemJutottBe();
            FoldreszIndult();
            OrszagLista();
            FileWrite();
        }
        static void FileRead()
        {
            StreamReader sr = new StreamReader("torna.csv");
            sr.ReadLine();//cimsor átugrása
            while (!sr.EndOfStream)
            {
                versenyzok.Add(new Versenyzo(sr.ReadLine()));
            }
            sr.Close();
        }

        static string KorlatTop1()
        {
            double max = 0;
            string maxnev = "";
            string lofasz = "";
            foreach (var item in versenyzok)
            {
                if (item.Eredmenyek.Korlat > max)
                {
                    max = item.Eredmenyek.Korlat;
                    maxnev = item.Nev;
                }
            }
            return maxnev;
        }

        static void GyuruEredmenyKereso()
        {
            Console.Write("4. feladat\n Kérem a versenyző rajtszámát:");
            int megadott = int.Parse(Console.ReadLine());
            bool megvan = false;
            foreach (var item in versenyzok)
            {
                if (megadott == item.Rajtszam)
                {
                    Console.WriteLine($"A {megadott} rajtszámú versenyző gyűrűn elért eredménye {item.Eredmenyek.Gyuru} volt.");
                    megvan = true;
                    break;
                }
            }
            if (!megvan) Console.WriteLine("Nincs ilyen versenyző!");
        }

        static void NemJutottBe()
        {
            Console.WriteLine("5. feladat\n A gyűrű döntőbe be nem jutottak listája:");
            foreach (var item in versenyzok)
            {
                if (item.Eredmenyek.Lolenges <= 14.5) Console.WriteLine($"{item.Nev}");
            }
        }

        static void FoldreszIndult()
        {
            List<string> foldreszek = new List<string>();
            foreach (var item in versenyzok)
            {
               if(!foldreszek.Contains(item.Foldresz))foldreszek.Add(item.Foldresz);
            }
            //sorba rendező
            foldreszek.Sort();
            Console.Write("6. feladat\n A fölrészek ahonnan indultak versenyzők:");
            foreach (var item in foldreszek)
            {
                Console.Write($"{item} ");
            }
        }

        static void OrszagLista()
        {
            Dictionary<string, int> orszagok_szerint = new Dictionary<string, int>();
            foreach (var item in versenyzok)
            {
                if(!orszagok_szerint.ContainsKey(item.OrszagKod))
                {
                    orszagok_szerint[item.OrszagKod] = 1;
                }
                else
                {
                    orszagok_szerint[item.OrszagKod]++;
                }
            }
            Console.WriteLine("\n7. feladat");
            foreach (var item in orszagok_szerint)
            {
                Console.WriteLine($"\t{item.Key}:{item.Value} fő");
            }
        }

        static void FileWrite()
        {
            StreamWriter sw = new StreamWriter("francia.txt");
            foreach (var item in versenyzok)
            {
                double osszpontszam = item.Eredmenyek.Gyuru + item.Eredmenyek.Korlat + item.Eredmenyek.Lolenges + item.Eredmenyek.Nyujto + item.Eredmenyek.Talaj+item.Eredmenyek.Ugras;
                if(item.OrszagKod=="FRA")
                {
                    sw.WriteLine($"{item.Rajtszam};{item.Nev};{osszpontszam}");
                }
            }
            sw.Close();
        }

    }
}
