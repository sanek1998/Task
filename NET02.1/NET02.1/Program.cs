using System;

namespace NET02._1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var FyodorDostoyevsky = new Author("Fyodor", "Dostoyevsky");
                var LevTolstoy = new Author("Lev", "Tolstoy");
                var AlexanderPushkin = new Author("Alexander", "Pushkin");

                var CrimeAndPunishment = new Book("Crime and punishment", "978-5-17-112393-2",
                    new DateTime(1997, 07, 25),
                    FyodorDostoyevsky, AlexanderPushkin, LevTolstoy);
                var Idiot = new Book("Idiot", "978-5-38-904730-3", new DateTime(1657, 11, 04), FyodorDostoyevsky);
                var Devils = new Book("Devils", "978-5-92-682607-1", new DateTime(2000, 12, 31), FyodorDostoyevsky);

                var catalog = new Catalog {CrimeAndPunishment, Idiot, Devils};

                foreach(var val in catalog) Console.WriteLine(val);

                Console.WriteLine(new string('=', 120));

                foreach(var v in catalog.GetBooksByFirstNameLastName("Lev", "tolstoy"))
                    Console.WriteLine(v);

                Console.WriteLine(new string('=', 120));
                foreach(var c in catalog.GetBooksSortedByDate())
                    Console.WriteLine(c);

                Console.WriteLine(new string('=', 120));
                foreach(var c in catalog.GetTupleAuthorAndNumber())
                    Console.WriteLine(c);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}