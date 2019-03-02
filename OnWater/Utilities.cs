using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnWater.Lib
{
    public class GeoPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoPoint()
        {

        }

        public GeoPoint(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    public class PixelPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PixelPoint()
        {

        }

        public PixelPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// Utility static functions
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Trasform a GeoPoint (Latitude and Longitude) in pixels
        /// </summary>
        /// <param name="latitude">Latitude of the point</param>
        /// <param name="longitude">Longitude of the point</param>
        /// <returns></returns>
        public static PixelPoint CoordsToPixels(double latitude, double longitude)
        {
            var x = (longitude + 180) / 360 * 8192;
            var y = 4096 / 2 - latitude * 4096 / 180;
            return new PixelPoint((int)x, (int)y);
        }

        public static PixelPoint CoordsToPixels(GeoPoint p)
        {
            var x = (p.Longitude + 180) / 360 * 8192;
            var y = 4096 / 2 - p.Latitude * 4096 / 180;
            return new PixelPoint((int)x, (int)y);
        }
    }
}
