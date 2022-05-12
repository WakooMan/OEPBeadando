namespace Feladat11
{
    public class SarkiRoka : Ragadozo
    {
        public SarkiRoka(Elovilag elo,string b, int e) : base(elo, b, e,175)
        {
        }

        public override Faj Faj()
        {
            return Feladat11.Faj.SarkiRoka;
        }
    }
}