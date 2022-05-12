namespace Feladat11
{
    public abstract class Zsakmany : Kolonia
    {
        private int MaxEgyedszam;
        private int MinEgyedszam;
        private int VadaszatSzazalek;
        public Zsakmany(Elovilag elo,string b, int e,int fsz, int fk, int maxe,int mine,int vadsz) : base(elo, b, e,fsz,fk)
        {
            MaxEgyedszam = maxe;
            MinEgyedszam = mine;
            VadaszatSzazalek = vadsz;
        }

        public override bool Ragadozo_e()
        {
            return false;
        }

        public override void Cselekszik(int kor)
        {
            base.Cselekszik(kor);
            if (egyedszam > MaxEgyedszam)
            {
                egyedszam = MinEgyedszam;
            }
        }

        public void Reagal(int egyedszam)
        {
            this.egyedszam -= (int)(egyedszam * ((double)VadaszatSzazalek/100));
        }

        public abstract override Faj Faj();
    }
}