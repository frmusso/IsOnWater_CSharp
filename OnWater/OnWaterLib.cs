using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnWater.Lib
{
    public class OnWaterLib
    {
        private Bitmap Bmp;
        private readonly Random Rand;

        public OnWaterLib()
        {
            Bmp = new Bitmap("water_8k.png");
            Rand = new Random();
        }

        /// <summary>
        /// Generate random point which will be on land or water based on the parameter
        /// </summary>
        /// <param name="onWater">True = generates water point, False = generate land point</param>
        /// <returns></returns>
        public GeoPoint GenerateRandomGeoPoint(bool onWater = false)
        {
            int latRange = 90; // Between -90 and +90
            int lngRange = 180; // Between -180 and +180

            double rndLat = 0.0;
            double rndLng = 0.0;
            PixelPoint result = new PixelPoint(0, 0);
            do
            {
                rndLat = Rand.NextDouble() * latRange * (Rand.Next(0, 2) * 2 - 1);
                rndLng = Rand.NextDouble() * lngRange * (Rand.Next(0, 2) * 2 - 1);

                result = Utility.CoordsToPixels(rndLat, rndLng);
            } while (onWater ? !IsOnWater(result) : IsOnWater(result));

            return new GeoPoint(rndLat, rndLng);
        }

        /// <summary>
        /// Check if a geo point (latitude, longitude) in on water
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public bool IsOnWater(double latitude, double longitude)
        {
            return IsOnWater(new GeoPoint { Latitude = latitude, Longitude = longitude });
        }

        /// <summary>
        /// Check if a geo point (latitude, longitude) in on water
        /// </summary>
        /// <param name="p">GeoPoint (latitude, longitude)</param>
        /// <returns></returns>
        public bool IsOnWater(GeoPoint p)
        {
            return IsOnWater(Utility.CoordsToPixels(p));
        }

        /// <summary>
        /// Check if a pixel point is on land through its color
        /// </summary>
        /// <param name="p">Point on world image</param>
        /// <returns></returns>
        private bool IsOnWater(PixelPoint p)
        {
            Color color = Bmp.GetPixel(p.X, p.Y);
            if (color.Name == "ffffffff")
                return true;

            return false;
        }
    }
}
