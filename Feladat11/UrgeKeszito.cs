namespace Feladat11
{
    public class UrgeKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(string becenev, int egyedszam)
        {
            return new Urge(becenev,egyedszam);
        }
    }
}