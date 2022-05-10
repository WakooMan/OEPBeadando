namespace Feladat11
{
    public class Lemming : Zsakmany
    {
        public Lemming(string b, int e) : base(b, e,200,2,200,30,400)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.Lemming;
        }
    }
}