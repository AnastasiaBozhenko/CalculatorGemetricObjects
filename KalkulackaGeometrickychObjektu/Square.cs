
namespace KalkulackaGeometrickychObjektu
{
    [GeomObject("Square")]
    public class Square : Rectangle
    {
        /// <summary>
        /// Strana čtverce
        /// </summary>
        public override double SideA { get; set; }
        public override double SideB { 
            get => SideA; 
            set => SideA = value;
        }
        /// <summary>
        /// Zjisti parametr(stranu) čtverce
        /// </summary>
        /// <returns>čtverec s parametrem(stranou)</returns>
        public override void LoadValues(params double[] sides)
        {
            if (sides is null || sides.Length == 0)
            {
                Utils.FindOutSide("length of the side", "square", out double sideA);
                SideA = sideA;
            }
            else
            {
                SideA = sides[0];
            }
        }
        /// <summary>
        /// Vypočítá obsah čtverce
        /// </summary>
        /// <returns>Obsah čtverce</returns>
        public override double CalculateContent()
        {
            double S =Math.Pow(SideA, 2);
            return S;
        }
        /// <summary>
        /// Vypočítá perimetr čtverce
        /// </summary>
        /// <returns>Perimetr čtverce</returns>
        public override double CalculatePerimeter()
        {
            double O = 4 * SideA;
            return O;
        }
    }
}
