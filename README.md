## What is it?
The purpose of the library is to check whether or not a coordinate point (Latitude, Longitude) is on water. It also provides a method to generate a random `GeoPoint(double latitude, double longitude)` with a OnWater boolean as a parameter.

## Project structure
- [OnWater](/OnWater/): C# Library project.
	- [OnWaterLib.cs](/OnWater/OnWaterLib.cs): Main library which contains `IsOnWater(GeoPoint p)` and `GenerateRandomGeoPoint(bool OnWater = false)` methods.
	- [Utilities.cs](/OnWater/Utilities.cs): utility classes such as `PixelPoint`, `GeoPoint` and some utility methods.
	- [water_8k.png](/OnWater/water_8k.png): 8k world water image used to check the point.

- [OnWater.Tests](/OnWater.Tests/): Console application used to test the library mentioned above.

## How it works?
It follows these steps:
- Get `GeoPoint (double latitude, double longitude)` point.
- Convert it into `PixelPoint(int X, int Y)` point using `CoordsToPixels(double latitude, double longitude)` inside [Utilities.cs](/OnWater/Utilities.cs).
- Check the `(X, Y)` pixel's color inside [water_8k.png](/OnWater/water_8k.png).
- If it is white the point is on water, otherwise it is on land.

```csharp
private bool IsOnWater(PixelPoint p)
{
    Color color = Bmp.GetPixel(p.X, p.Y);
    if (color.Name == "ffffffff")
	return true;

    return false;
}
```

## How it converts GeoPoint to PixelPoint

```csharp
public static PixelPoint CoordsToPixels(double latitude, double longitude)
{
	var x = (longitude + 180) / 360 * 8192;
	var y = 4096 / 2 - latitude * 4096 / 180;
	return new PixelPoint((int)x, (int)y);
}
```
It is a simple proportion knowing that longitude goes from -180 to +180 and latitude goes from -90 to +90. You can get additional information about how latitude and longitude works following this [link](https://journeynorth.org/tm/LongitudeIntro.html). 8192 and 4096 are [water_8k.png](/OnWater/water_8k.png) dimensions.

## Changelog
- 02 March 2019: First release
