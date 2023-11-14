
namespace KalkulackaGeometrickychObjektu
{
    [GeomObject("Sphere")]
    public class Sphere : A3D
    {
        /// <summary>
        /// Radius(poloměr) koule
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Zjistí radius koule
        /// </summary>
        public override void LoadValues(params double[] sides)
        {
            if (sides is null||sides.Length == 0)
            {
                Utils.FindOutSide("length of the radius", "sphere", out double radius);
                Radius = radius;
            }
            else
            {
                Radius=sides[0];
            }
        }
        /// <summary>
        /// Vypočítá povrch koule
        /// </summary>
        /// <returns>Povrch koule</returns>
        public override double CalculateSurface()
        {
            double S = 4  * Math.PI * Math.Pow(Radius, 2);
            return S;
        }
        /// <summary>
        /// Vypočítat objem koule
        /// </summary>
        /// <returns>Objem koule</returns>
        public override double CalculateVolume()
        {
            double V = (4.0 / 3.0) * Math.PI *Math.Pow(Radius, 3);
            return V;
        }
    }
}
