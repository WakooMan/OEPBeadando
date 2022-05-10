namespace Feladat11
{
    public class LemmingKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(string becenev, int egyedszam)
        {
            return new Lemming(becenev,egyedszam);
        }
    }
}