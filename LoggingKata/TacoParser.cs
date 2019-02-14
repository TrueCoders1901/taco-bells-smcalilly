using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            logger.LogInfo(line);

            // split line into array of strings
            string[] cells = line.Split(',');
            logger.LogInfoArray(cells);

            System.Console.WriteLine(cells);

            // Do not fail if one record parsing fails, return null
            if (cells.Length < 3)
            {
                logger.LogError(line, null);
                return null;
            }

            // converting latitude and longitude to double
            double latitude = double.Parse(cells[0]);
            double longitude = double.Parse(cells[1]);

            string locationName = cells[2];

            Point coordinates = new Point();
            coordinates.Latitude = latitude;
            coordinates.Longitude = longitude;
            Point geoCoordinates = coordinates.GetPoint(latitude, longitude);

            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = locationName;
            tacoBell.Location = geoCoordinates;

            Console.WriteLine(locationName);
            Console.WriteLine(geoCoordinates);
            
           
            logger.LogITrackableInfo(tacoBell);

            return tacoBell.GetTrackable(locationName, geoCoordinates);
        }
    }
}