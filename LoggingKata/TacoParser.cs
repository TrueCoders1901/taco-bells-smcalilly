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

            // split line into array of strings
            string[] cells = line.Split(',');


            // Do not fail if one record parsing fails, return null
            if (cells.Length < 3)
            {
                return null;
            }


            // converting latitude and longitude to double
            double latitude = double.Parse(cells[0]);
            double longitude = double.Parse(cells[1]);

            string locationName = cells[2];

            Point coordinates = new Point();
            coordinates.Latitude = latitude;
            coordinates.Longitude = longitude;


            // so now i have my latitude, longitude, and locationName
            // and need to apply that information to my Taco Bell instance


            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = locationName;
            tacoBell.Location = coordinates;

            return tacoBell;

        }
    }
}