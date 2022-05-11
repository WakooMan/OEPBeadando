namespace Feladat11
{
    class Program 
    {
        static void Main(string [] args)
        {
            Dictionary<string,Faj> fajok = new Dictionary<string,Faj>();
            fajok.Add("l",Faj.Lemming);
            fajok.Add("h", Faj.Hobagoly);
            fajok.Add("n", Faj.Nyul);
            fajok.Add("f", Faj.Farkas);
            fajok.Add("s", Faj.SarkiRoka);
            fajok.Add("u", Faj.Urge);
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                reader.ReadLine();
                string? line = reader.ReadLine();
                while (line != null)
                {
                    string[] splitted = line.Split(' ');
                    Elovilag.Current().KoloniatHozzaad(splitted[0],fajok[splitted[1]],int.Parse(splitted[2]));
                    line = reader.ReadLine();
                }
            }
            int sum = SumRagadozoEgyedszam();
            int kor = 0;
            Kiir(kor++);
            while (!RagadozokKisebbMintNegy() && !(SumRagadozoEgyedszam() >= 2 * sum))
            {
                Elovilag.Current().KortVegrehajt(kor);
                Kiir(kor++);
            }
        }

        private static int SumRagadozoEgyedszam()
        {
            int s = 0;
            var t = Elovilag.Current().RagadozoKoloniak().GetEnumerator();
            while (t.MoveNext())
            {
                s += t.Current.Egyedszam();
            }
            return s;
        }

        private static bool RagadozokKisebbMintNegy()
        {
            bool l = true;
            var t = Elovilag.Current().RagadozoKoloniak().GetEnumerator();
            while (l && t.MoveNext())
            {
                Kolonia elem = t.Current;
                l = elem.Egyedszam() < 4;
            }
            return l;
        }

        private static void Kiir(int kor)
        {
            Console.WriteLine($"{kor}. kör:");
            foreach (Kolonia kolonia in Elovilag.Current().Koloniak())
            {
                Console.WriteLine($"{kolonia.Becenev()} {kolonia.Faj()} {kolonia.Egyedszam()}");
            }
            Console.WriteLine();
        }
    }
}
