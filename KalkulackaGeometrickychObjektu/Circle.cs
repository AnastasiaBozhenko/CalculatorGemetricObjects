
namespace KalkulackaGeometrickychObjektu
{
    [GeomObject("Circle")]
    public  class Circle: A2D
    {
        /// <summary>
        /// Radius(poloměr) kruhu
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Zjisti od uživatele délku radiánu(poloměru) kruhu pro výpočet v cm
        /// </summary>
        public override void LoadValues(params double[] sides)
        {
            if (sides is null || sides.Length == 0)
            {
                Utils.FindOutSide("length of the radius", "circle", out double radius);
                Radius = radius;
            }
            else
            {
                Radius = sides[0];
            }
        }
        /// <summary>
        /// Vypočitá obsah kruhu
        /// </summary>
        /// <returns>Obsah kruhu</returns>
        public override double CalculateContent()
        {
            double S = Math.PI * Math.Pow(Radius, 2);
            return S;
        }
        /// <summary>
        /// Vypočitá Obvod kruhu
        /// </summary>
        /// <returns>Obvod kruhu</returns>
        public override double CalculatePerimeter()
        {
            double O = 2 * Math.PI * Radius;
            return O;
        }
    }
}
