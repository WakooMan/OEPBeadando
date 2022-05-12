namespace Feladat11
{
    public class Urge : Zsakmany
    {
        public Urge(Elovilag elo,string b, int e) : base(elo, b, e,200,4,200,40,200)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.Urge;
        }
    }
}