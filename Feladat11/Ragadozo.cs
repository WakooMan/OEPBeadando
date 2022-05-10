namespace Feladat11
{
    public abstract class Ragadozo : Kolonia
    {
        protected Ragadozo(string b, int e,int fsz) : base(b,e,fsz,8)
        {
        }

        public override void Cselekszik(int kor)
        {
            base.Cselekszik(kor);
            Zsakmany? zs = ZsakmanytKeres();
            if (zs is not null)
            {
                ZsakmanytMegtamad(zs);
            }
        }

        public override bool Ragadozo_e()
        {
            return true;
        }

        private Zsakmany? ZsakmanytKeres()
        {
            Random rnd = new Random();
            var list = Elovilag.Current().ZsakmanyKoloniak();
            return (list.Count>0)?list[rnd.Next(list.Count)]:null;
        }

        private void ZsakmanytMegtamad(Zsakmany zsakmany)
        {
            zsakmany.Reagal(egyedszam);
            if (zsakmany.Egyedszam() < 0)
            {
                egyedszam = egyedszam * 3 / 4;
                Elovilag.Current().KoloniatEllenoriz(zsakmany);
                Elovilag.Current().KoloniatEllenoriz(this);
            }
        }

        public abstract override Faj Faj();
    }
}