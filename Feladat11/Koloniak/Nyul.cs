namespace Feladat11
{
    public class Nyul : Zsakmany
    {
        public Nyul(Elovilag elo,string b, int e) : base(elo, b, e,150,2,100,20,200)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.Nyul;
        }
    }
}