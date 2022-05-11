namespace Feladat11
{
    public class Elovilag
    {
        private KoloniaKeszito[] koloniakeszitok;
        private List<Kolonia> koloniak;
        private static Elovilag? current = null;

        private Elovilag()
        {
            koloniakeszitok = new KoloniaKeszito[6] { new LemmingKeszito(),new UrgeKeszito(),new NyulKeszito(),new SarkiRokaKeszito(),new HobagolyKeszito(),new FarkasKeszito()};
            koloniak = new List<Kolonia>();
        }

        public static Elovilag Current()
        {
            if (current is null)
            {
                current = new Elovilag();
            }
            return current;
        }

        public void KoloniatHozzaad(string becenev,Faj faj,int egyedszam)
        {
            koloniak.Add(koloniakeszitok[(int)faj].KoloniatKeszit(becenev,egyedszam));
        }

        private bool KoloniaBenneVanE(Kolonia kolonia)
        {
            bool l = false;
            var t = koloniak.GetEnumerator();
            while (!l && t.MoveNext())
            {
                Kolonia elem = t.Current;
                l = elem == kolonia;
            }
            return l;
        }

        public void KoloniatEllenoriz(Kolonia kolonia)
        {
            if (kolonia.Egyedszam() < 0 && KoloniaBenneVanE(kolonia))
            {
                koloniak.Remove(kolonia);
            }
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
    }
}
