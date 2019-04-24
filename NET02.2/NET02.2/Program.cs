using System;
using System.Collections.Generic;

namespace NET02._2
{
    public class Program
    {
        private static void Main()
        {
            var read = new XmlReader();
            var config = read.XmlRead();
            Console.WriteLine(config);
            var invalidName = new List<string>(config.GetInvalidLogins());
            foreach (var s in invalidName)
            {
                Console.WriteLine(s);
            }

            var jsonWrite = new JsonWriter();
            jsonWrite.Write(config);

            Console.ReadLine();
        }
    }
}