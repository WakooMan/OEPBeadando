namespace Feladat11
{
    public class LemmingKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(Elovilag elo, string becenev, int egyedszam)
        {
            return new Lemming(elo, becenev,egyedszam);
        }
    }
}