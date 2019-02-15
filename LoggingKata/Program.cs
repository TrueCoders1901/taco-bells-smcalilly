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
            var lines = File.ReadAllLines(csvPath);

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
            ITrackable permLocA = null;
            ITrackable permLocB = null;
            double distanceBetweenLocations;
            double permanentDistanceBtw = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                locationA = locations[i];
                double latitudeA = locationA.Location.Latitude;
                double longitudeA = locationA.Location.Longitude;

                GeoCoordinate coordinateA = new GeoCoordinate(latitudeA, longitudeA);

                foreach (var otherLocation in locations)
                {
                    locationB = otherLocation;
                    double latitudeB = locationB.Location.Latitude;
                    double longitudeB = locationB.Location.Longitude;

                    GeoCoordinate coordinateB = new GeoCoordinate(latitudeB, longitudeB);

                    distanceBetweenLocations = coordinateA.GetDistanceTo(coordinateB);
                    if (distanceBetweenLocations > permanentDistanceBtw)
                    {
                        permLocA = locationA;
                        permLocB = locationB;
                        permanentDistanceBtw = distanceBetweenLocations;
                    }
                }
            }

            Console.WriteLine(permLocA.Name);
            Console.WriteLine(permLocB.Name);

        }
    }
}