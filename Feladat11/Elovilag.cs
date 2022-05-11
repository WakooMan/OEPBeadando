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

        private void KoloniakatEllenoriz()
        {
            var torlendok = koloniak.Where(k => k.Egyedszam() <= 0).ToList();
            foreach (Kolonia kolonia in torlendok)
            {
                koloniak.Remove(kolonia);
            }
        }

        public void KortVegrehajt(int kor)
        {
            foreach (Kolonia k in koloniak)
            {
                k.Cselekszik(kor);
            }
            KoloniakatEllenoriz();
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
        }
    }
}
