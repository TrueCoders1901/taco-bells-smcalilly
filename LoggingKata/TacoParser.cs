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
                logger.LogError(line);
                return null;
            }

            // converting latitude and longitude to double
            double latitude = double.Parse(cells[0]);
            double longitude = double.Parse(cells[1]);

            if (latitude > 180 || longitude > 180)
            {
                logger.LogError(line, null);
                return null;
            }

            string locationName = cells[2];

            Point coordinates = new Point();
            coordinates.Latitude = latitude;
            coordinates.Longitude = longitude;

            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = locationName;
            tacoBell.Location = coordinates;

            Console.WriteLine(locationName);
            Console.WriteLine(coordinates);
            

            logger.LogITrackableInfo(tacoBell);

            return tacoBell;
        }
    }
}