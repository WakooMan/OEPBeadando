namespace Feladat11
{
    class Program 
    {
        static void Main(string [] args)
        {
            Console.Write("Adjon meg egy bemeneti fájlt a kolóniák beolvasásához: ");
            string filename = Console.ReadLine();
            Console.WriteLine();
            Tundra.Instance.ReadFile(filename);
            Console.WriteLine(Tundra.Instance);
            while (!Tundra.Instance.SzimulacioVegeE())
            {
                Tundra.Instance.KortVegrehajt();
                Console.WriteLine(Tundra.Instance);
            }
        }
    }
}
