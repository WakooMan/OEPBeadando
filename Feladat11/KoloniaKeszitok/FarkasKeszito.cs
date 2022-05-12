namespace Feladat11
{
    public class FarkasKeszito : KoloniaKeszito
    {
        public override Kolonia KoloniatKeszit(Elovilag elo,string becenev,int egyedszam)
        {
            return new Farkas(elo,becenev, egyedszam);
        }
    }
}