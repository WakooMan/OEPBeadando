namespace Feladat11
{
    public class Farkas : Ragadozo
    {
        public Farkas(Elovilag elo,string b, int e) : base(elo,b, e,150)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.Farkas;
        }
    }
}