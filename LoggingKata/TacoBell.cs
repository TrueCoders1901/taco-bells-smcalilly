﻿namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        public ITrackable GetTrackable(string Name, Point Location)
        {
            return this;
        }
    }
}
