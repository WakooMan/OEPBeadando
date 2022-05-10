namespace Feladat11
{
    public class HobagolyKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(string becenev, int egyedszam)
        {
            return new Hobagoly(becenev,egyedszam);
        }
    }
}