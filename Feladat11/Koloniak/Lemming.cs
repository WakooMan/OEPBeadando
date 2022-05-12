namespace Feladat11
{
    public class Lemming : Zsakmany
    {
        public Lemming(Elovilag elo,string b, int e) : base(elo, b, e,200,2,200,30,400)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.Lemming;
        }
    }
}