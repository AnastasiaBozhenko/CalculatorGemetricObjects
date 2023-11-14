
namespace KalkulackaGeometrickychObjektu
{
    public abstract class A2D : AGeometricObject
    {
        [CalculationOperation("Perimeter", "centimeters")]
        public abstract double CalculatePerimeter();
        [CalculationOperation("Content", "square centimeters")]
        public abstract double CalculateContent();
    }
}
