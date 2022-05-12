namespace Feladat11
{
    public abstract class Ragadozo : Kolonia
    {
        protected Ragadozo(Elovilag elo,string b, int e,int fsz) : base(elo,b,e,fsz,8)
        {
        }

        public override void Cselekszik(int kor)
        {
            base.Cselekszik(kor);
            if (Egyedszam() <= 0)
            {
                return;
            }
            Zsakmany? zs = ZsakmanytKeres();
            ZsakmanytMegtamad(zs);
        }

        public override bool Ragadozo_e()
        {
            return true;
        }

        private Zsakmany? ZsakmanytKeres()
        {
            Random rnd = new Random();
            var list = elovilag.ZsakmanyKoloniak().Where(zs => zs.Egyedszam()>0).ToList();
            return (list.Count>0)?list[rnd.Next(list.Count)]:null;
        }

        private void ZsakmanytMegtamad(Zsakmany? zsakmany)
        {
            zsakmany?.Reagal(egyedszam);
            if (zsakmany is null || zsakmany.Egyedszam() <= 0)
            {
                egyedszam = egyedszam * 3 / 4;
            }
        }

        public abstract override Faj Faj();
    }
}