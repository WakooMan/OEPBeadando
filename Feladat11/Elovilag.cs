using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void KoloniatEllenoriz(Kolonia kolonia)
        {
            if (kolonia.Egyedszam() < 0 && koloniak.Contains(kolonia))
            {
                koloniak.Remove(kolonia);
            }
        }

        public IReadOnlyList<Zsakmany> ZsakmanyKoloniak()
        {
            return koloniak.Where(k => !k.Ragadozo_e()).Select(k => (Zsakmany)k).ToList().AsReadOnly();
        }

        public IReadOnlyList<Ragadozo> RagadozoKoloniak()
        {
            return koloniak.Where(k => k.Ragadozo_e()).Select(k => (Ragadozo)k).ToList().AsReadOnly();
        }

        public IReadOnlyList<Kolonia> Koloniak()
        {
            return koloniak.AsReadOnly();
        }
    }
}
