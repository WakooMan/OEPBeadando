namespace Feladat11
{
    public class SarkiRoka : Ragadozo
    {
        public SarkiRoka(string b, int e) : base(b, e,175)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.SarkiRoka;
        }
    }
}