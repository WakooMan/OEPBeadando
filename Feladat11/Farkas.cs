namespace Feladat11
{
    public class Farkas : Ragadozo
    {
        public Farkas(string b, int e) : base(b, e,150)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.Farkas;
        }
    }
}