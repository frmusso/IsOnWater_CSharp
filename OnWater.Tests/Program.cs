using OnWater.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnWater.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            OnWaterLib ow = new OnWaterLib();

            Console.WriteLine("Random land points:");
            // Generates 5 land points
            for(int i = 0; i < 5; i++)
            {
                GeoPoint p = ow.GenerateRandomGeoPoint();
                Console.WriteLine("Lat: {0} - Lng: {1} | IsOnWater result: {2}", p.Latitude, p.Longitude, ow.IsOnWater(p));
            }

            Console.WriteLine("\nRandom water points:");
            // Generates 5 water points
            for (int i = 0; i < 5; i++)
            {
                GeoPoint p = ow.GenerateRandomGeoPoint(true);
                Console.WriteLine("Lat: {0} - Lng: {1} | IsOnWater result: {2}", p.Latitude, p.Longitude, ow.IsOnWater(p));
            }

            Console.ReadLine();
        }
    }
}
