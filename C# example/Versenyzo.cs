using System;
using System.Collections.Generic;
using System.Text;

namespace torna2008_doga
{
    class Eredmeny
    {
        public double Talaj { get;private set; }
        public double Lolenges { get;private set; }
        public double Gyuru { get;private set; }
        public double Nyujto { get;private set; }
        public double Korlat { get;private set; }
        public double Ugras { get;private set; }
        public Eredmeny(string eredmenyek)
        {
            string[] adatok = eredmenyek.Split();
            Talaj = double.Parse(adatok[0]);
            Lolenges = double.Parse(adatok[1]);
            Gyuru = double.Parse(adatok[2]);
            Nyujto = double.Parse(adatok[3]);
            Korlat = double.Parse(adatok[4]);
            Ugras = double.Parse(adatok[5]);
        }
    }
    class Versenyzo
    {
        public int Rajtszam { get;private set; }
        public string Nev { get;private set; }
        public string OrszagKod { get;private set; }
        public string Foldresz { get;private set; }
        public Eredmeny Eredmenyek { get;private set; }

        public Versenyzo(string sor)
        {
            string[] adatok = sor.Split(";");
            Rajtszam = int.Parse(adatok[0]);
            Nev = adatok[1];
            OrszagKod = adatok[2];
            Foldresz = adatok[3];
            Eredmenyek = new Eredmeny($"{adatok[4]} {adatok[5]} {adatok[6]} {adatok[7]} {adatok[8]} {adatok[9]}");
        }

        public void Lofasz()
        {
            Console.WriteLine("Lofasz");
        }
    }
}
