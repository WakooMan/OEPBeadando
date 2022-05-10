namespace Feladat11
{
    public class FarkasKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(string becenev,int egyedszam)
        {
            return new Farkas(becenev, egyedszam);
        }
    }
}