namespace Feladat11
{
    public class Urge : Zsakmany
    {
        public Urge(string b, int e) : base(b, e,200,4,200,40,200)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.Urge;
        }
    }
}