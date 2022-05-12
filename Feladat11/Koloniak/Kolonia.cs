namespace Feladat11
{
    public abstract class Kolonia
    {
        private string becenev;
        protected int egyedszam;
        private int FialKor;
        private int FialSzazalek;
        protected Elovilag elovilag;

        protected Kolonia(Elovilag elo,string b, int e,int fsz,int fk)
        {
            becenev = b;
            egyedszam = e;
            FialSzazalek = fsz;
            FialKor = fk;
            elovilag = elo;
        }

        private void Fial()
        {
            egyedszam = (int)(egyedszam * ((double)FialSzazalek / 100));
        }

        public string Becenev() { return becenev; }
        public int Egyedszam() { return egyedszam; }
        public virtual void Cselekszik(int kor)
        {
            if (Egyedszam() <= 0)
            {
                return;
            }
            if (kor % FialKor == 0)
            {
                Fial();
            }
        }
        public abstract Faj Faj();
        public abstract bool Ragadozo_e();
    }
}