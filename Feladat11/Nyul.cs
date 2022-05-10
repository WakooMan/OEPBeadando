namespace Feladat11
{
    public class Nyul : Zsakmany
    {
        public Nyul(string b, int e) : base(b, e,150,2,100,20,200)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.Nyul;
        }
    }
}