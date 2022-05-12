namespace Feladat11
{
    class Program 
    {
        static void Main(string [] args)
        {
            Tundra.Instance.ReadFile("Input.txt");
            Console.WriteLine(Tundra.Instance);
            while (!Tundra.Instance.SzimulacioVegeE())
            {
                Tundra.Instance.KortVegrehajt();
                Console.WriteLine(Tundra.Instance);
            }
        }
    }
}
