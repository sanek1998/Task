using System;

namespace NET01_2
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var r = new Random();
                
                var SM = new SquareMatrix<int>(7);

                SM.Changed += delegate(object sender, MatrixEventArgs<int> args)
                {
                    Console.WriteLine(
                        $"Element:[{args.I}][{args.J}], old value: {args.Old}, new value: {args.New}");
                };

                for (var i = 0; i < SM.Size; i++)
                {
                    for (var j = 0; j < SM.Size; j++)
                    {
                        SM[i, j] = r.Next(0, 500);
                    }
                }

                Console.WriteLine("\n" + SM);
                Line();
                SM[2, 5] = 256;

                Console.WriteLine("\n" + SM);
                Line();
                
                var DG = new DiagonalMatrix<int>(9);
                DG.Changed += (sender, args) =>
                    Console.WriteLine(
                        $"Element:[{args.I}][{args.J}], old value: {args.Old}, new value: {args.New}");
                for (var i = 0; i < DG.Size; i++) DG[i, i] = r.Next(0, 500);
                Console.WriteLine(DG);
                Console.WriteLine(new string('-', 120));
                DG[0, 0] = 5;
                Console.WriteLine(DG);
                Line();
                
                var SDG = new DiagonalMatrix<char>(5);
                SDG.Changed += ForEvent;
                SDG[0, 0] = 's';
                SDG[1, 1] = 'a';
                SDG[2, 2] = 's';
                SDG[3, 3] = 'h';
                SDG[4, 4] = 'a';
                Console.WriteLine(SDG);
                Line();
                SDG[0, 0] = 'S';
                Console.WriteLine(SDG);
                Line();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static void ForEvent(object sender, MatrixEventArgs<char> args)
        {
            Console.WriteLine($"Element:[{args.I}][{args.J}], old value: {args.Old}, new value: {args.New}");
        }

        private static void Line()
        {
            Console.WriteLine(new string('=', 120));
        }
    }
}