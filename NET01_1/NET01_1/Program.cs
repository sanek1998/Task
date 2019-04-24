using System;
using NET01_1.Enums;
using NET01_1.Materials;

namespace NET01_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var to = new Training("descriptionf");
                to.Add(new Text("some text",
                    "description"));
                to.Add(new Video(VideoType.Avi, "some text", "some text", "description"));
                to.Add(new Reference("some text", ReferenceType.Image, "description"));
                to.Add(new Video(VideoType.Mp4, "ref", description: "description"));

                var to2 = to.Clone();
                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
/*
 * +"\r\nDefinition - What does C# (C Sharp) mean?\r\nC# is " +
   "a general object-oriented programming (OOP) language for networking\n " +
   "and Web development. C# is specified as a common language infrastructure\n" +
   "(CLI) language.\r\n\r\nIn January 1999, Dutch software engineer Anders" +
   "Hejlsberg formed a team \n to develop C# as a complement to Microsoft’s NET \n" +
   "framework. Initially, C# was developed as C-Like Object Oriented Language (Cool).\n " +
   "The actual name was changed to avert potential trademark issues. In January 2000, \n" +
   "NET was released as C#. Its NET framework promotes multiple Web technologies.\n" +
   "\r\n\r\nThe term is sometimes spelled as C Sharp or C-Sharp."
 */