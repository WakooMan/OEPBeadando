namespace Feladat11
{
    public class UrgeKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(Elovilag elo, string becenev, int egyedszam)
        {
            return new Urge(elo, becenev,egyedszam);
        }
    }
}