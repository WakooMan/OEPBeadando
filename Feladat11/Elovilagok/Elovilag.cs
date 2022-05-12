namespace Feladat11
{
    public abstract class Elovilag
    {
        private static Dictionary<string, Faj> Fajok;
        static Elovilag()
        {
            Fajok = new Dictionary<string, Faj>();
            Fajok.Add("l", Faj.Lemming);
            Fajok.Add("h", Faj.Hobagoly);
            Fajok.Add("n", Faj.Nyul);
            Fajok.Add("f", Faj.Farkas);
            Fajok.Add("s", Faj.SarkiRoka);
            Fajok.Add("u", Faj.Urge);
        }
        public int Kor;
        private int SumKezdetnel;
        private KoloniaKeszito[] koloniakeszitok;
        private List<Kolonia> koloniak;

        protected Elovilag()
        {
            koloniakeszitok = new KoloniaKeszito[6] { new LemmingKeszito(),new UrgeKeszito(),new NyulKeszito(),new SarkiRokaKeszito(),new HobagolyKeszito(),new FarkasKeszito()};
            koloniak = new List<Kolonia>();
            Kor = 0;
            SumKezdetnel = -1;
        }

        public void KoloniatHozzaad(string becenev,Faj faj,int egyedszam)
        {
            koloniak.Add(koloniakeszitok[(int)faj].KoloniatKeszit(this,becenev,egyedszam));
        }

        public override string ToString()
        {
            string message = "";
            message += $"{Tundra.Instance.Kor}. kör:\n";
            foreach (Kolonia kolonia in Koloniak())
            {
                message += $"{kolonia.Becenev()} {kolonia.Faj()} {kolonia.Egyedszam()}\n";
            }
            return message;
        }

        private void KoloniakatEllenoriz()
        {
            var torlendok = koloniak.Where(k => k.Egyedszam() <= 0).ToList();
            foreach (Kolonia kolonia in torlendok)
            {
                koloniak.Remove(kolonia);
            }
        }

        public void KortVegrehajt()
        {
            if (Kor==0)
            {
                SumKezdetnel = SumRagadozoEgyedszam();
            }
            foreach (Kolonia k in koloniak)
            {
                k.Cselekszik(Kor);
            }
            KoloniakatEllenoriz();
            Kor++;
        }

        public bool SzimulacioVegeE()
        {
            return (SumRagadozoEgyedszam() >= SumKezdetnel * 2 && Kor > 0 ) || RagadozokKisebbMintNegy();
        }

        private int SumRagadozoEgyedszam()
        {
            int s = 0;
            var t = RagadozoKoloniak().GetEnumerator();
            while (t.MoveNext())
            {
                s += t.Current.Egyedszam();
            }
            return s;
        }

        private bool RagadozokKisebbMintNegy()
        {
            bool l = true;
            var t = RagadozoKoloniak().GetEnumerator();
            while (l && t.MoveNext())
            {
                Kolonia elem = t.Current;
                l = elem.Egyedszam() < 4;
            }
            return l;
        }

        public IReadOnlyList<Zsakmany> ZsakmanyKoloniak()
        {
            List<Zsakmany> s = new();
            var t = koloniak.GetEnumerator();
            while (t.MoveNext())
            {
                if(!t.Current.Ragadozo_e())
                {
                    s.Add((Zsakmany)t.Current);
                }
            }
            return s.AsReadOnly();
        }

        public IReadOnlyList<Ragadozo> RagadozoKoloniak()
        {
            List<Ragadozo> s = new();
            var t = koloniak.GetEnumerator();
            while (t.MoveNext())
            {
                if (t.Current.Ragadozo_e())
                {
                    s.Add((Ragadozo)t.Current);
                }
            }
            return s.AsReadOnly();
        }

        public IReadOnlyList<Kolonia> Koloniak()
        {
            return koloniak.AsReadOnly();
        }

        public void Clear()
        {
            koloniak.Clear();
            SumKezdetnel = -1;
            Kor = 0;
        }

        public void ReadFile(string filename)
        {
            Console.WriteLine("Fájl Tartalma:");
            using (StreamReader reader = new StreamReader(filename))
            {
                string firstline = reader.ReadLine();
                Console.WriteLine(firstline);
                string[] splittedfirst = firstline.Split(' ');
                int zs = int.Parse(splittedfirst[0]), r = int.Parse(splittedfirst[1]);
                int i = 0;
                while (i<zs+r)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                    string[] splitted = line.Split(' ');
                    KoloniatHozzaad(splitted[0], Fajok[splitted[1]], int.Parse(splitted[2]));
                    i++;
                }
            }
            Console.WriteLine("Fájl vége\n");
        }

    }
}
