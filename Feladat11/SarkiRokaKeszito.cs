namespace Feladat11
{
    public class SarkiRokaKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(string becenev, int egyedszam)
        {
            return new SarkiRoka(becenev,egyedszam);
        }
    }
}