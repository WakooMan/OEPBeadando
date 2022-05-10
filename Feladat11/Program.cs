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
            int sum = Elovilag.Current().RagadozoKoloniak().Sum(r => r.Egyedszam());
            int kor = 0;
            Kiir(kor++);
            while (!Elovilag.Current().RagadozoKoloniak().All(r => r.Egyedszam() < 4) && !(Elovilag.Current().RagadozoKoloniak().Sum(r => r.Egyedszam()) >= 2 * sum))
            {
                for(int i=0;i<Elovilag.Current().Koloniak().Count;i++)
                {
                    Kolonia kolonia = Elovilag.Current().Koloniak()[i];
                    kolonia.Cselekszik(kor);
                }
                Kiir(kor++);
            }
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
