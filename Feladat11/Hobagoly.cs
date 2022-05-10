namespace Feladat11
{
    public class Hobagoly : Ragadozo
    {
        public Hobagoly(string b, int e) : base(b, e,125)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.Hobagoly;
        }
    }
}