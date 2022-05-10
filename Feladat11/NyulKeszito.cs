namespace Feladat11
{
    public class NyulKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(string becenev, int egyedszam)
        {
            return new Nyul(becenev,egyedszam);
        }
    }
}