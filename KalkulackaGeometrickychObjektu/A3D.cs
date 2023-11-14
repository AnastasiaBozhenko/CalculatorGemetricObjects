
namespace KalkulackaGeometrickychObjektu
{
    public abstract class A3D:AGeometricObject
    {
        [CalculationOperation("Volume", "cubic centimeters")]
        public abstract double CalculateVolume();
        [CalculationOperation("Surface", "square centimeters")]
        public abstract double CalculateSurface();
    }
}
