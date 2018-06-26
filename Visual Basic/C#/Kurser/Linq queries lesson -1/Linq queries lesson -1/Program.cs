using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq_queries_lesson__1
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] MusicalArtists = { "In flames", "Metallica", "Periphery" };
            IEnumerable<string> Artist =
                from artist in MusicalArtists
                where artist.StartsWith("M")
                select artist;
            foreach (var artist in Artist)
            {
                Console.WriteLine(artist);
            }

               



        }


    }
}
