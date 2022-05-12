namespace Feladat11
{
    public class NyulKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(Elovilag elo, string becenev, int egyedszam)
        {
            return new Nyul(elo, becenev,egyedszam);
        }
    }
}