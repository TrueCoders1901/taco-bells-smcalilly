using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            // var lines = File.ReadAllLines(csvPath);
            var lines = "34.073638,-84.677017,Taco Bell Acwort... (Free trial * Add to Cart for a full POI info)";

                logger.LogInfo($"Lines: {lines[0]}");

            TacoParser parser = new TacoParser();

            //var locations = lines.Select(parser.Parse).ToArray();

            var location = parser.Parse(lines);
            Console.WriteLine(location);

            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops
        }
    }
}