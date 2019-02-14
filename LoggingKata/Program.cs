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

            var lines = File.ReadAllLines(csvPath);
                logger.LogInfo($"Lines: {lines[0]}");

            if (lines.Length == 0)
            {
                logger.LogError("Error: No lines returned");
            }

            if (lines.Length == 1)
            {
                logger.LogWarning("Warning: This only has one line");
            }

            TacoParser parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable locationA;
            ITrackable locationB;
            double distanceBetweenLocations;

            GeoCoordinate coordinateA = new GeoCoordinate();

            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops

            for (Point location; 0 < location.Length-1; locations)
            {
                locationA = location;
                coordinateA = locationA.Location;

                foreach (var otherLocation in locations)
                {
                    locationB = otherLocation;
                    Point coordinateB = locationB.Location;

                    distanceBetweenLocations = coordinateA.GetDistanceTo(coordinateB);
                }
            }
        }
    }
}