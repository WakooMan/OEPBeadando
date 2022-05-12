namespace Feladat11
{
    public class Hobagoly : Ragadozo
    {
        public Hobagoly(Elovilag elo,string b, int e) : base(elo,b, e,125)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.Hobagoly;
        }
    }
}