namespace Carwash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Voiture voiture = new Voiture("1-ABC-123");

            MyCarwash myCarwash = new MyCarwash();
            myCarwash.Traiter(voiture);

        }
    }
}
