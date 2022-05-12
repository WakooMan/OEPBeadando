namespace Feladat11
{
    public class SarkiRokaKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(Elovilag elo,string becenev, int egyedszam)
        {
            return new SarkiRoka(elo, becenev,egyedszam);
        }
    }
}