namespace Feladat11
{
    public class HobagolyKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(Elovilag elo, string becenev, int egyedszam)
        {
            return new Hobagoly(elo, becenev,egyedszam);
        }
    }
}