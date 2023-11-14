
namespace KalkulackaGeometrickychObjektu
{
    [GeomObject("Rectangle")]
    public class Rectangle : A2D
    {
        /// <summary>
        /// Délka obdelníku
        /// </summary>
        public virtual double SideA { get; set; }
        /// <summary>
        /// Šiřka obdélníku
        /// </summary>
        public virtual double SideB { get; set; }

        /// <summary>
        /// Zjisti parametry obdelníku 
        /// </summary>
        /// <returns>obdelnik s parametry(strany)</returns>
        public override void LoadValues(params double[] sides)
        {
            if (sides is null || sides.Length == 0)
            {
                Utils.FindOutSide("length of the side", "rectangle", out double sideA);
                Utils.FindOutSide("width of the side", "rectangle", out double sideB);
                SideA = sideA;
                SideB = sideB;
            }
            else
            {
                SideA = sides[0];
                SideB = sides[1];
            }      
        }
        /// <summary>
        /// Vypočítá obsah obdelníku
        /// </summary>
        /// <returns>obsah obdelníku</returns>
        public override double CalculateContent( )
        {
            double S = SideA * SideB;
            return S;
        }
        /// <summary>
        /// Vypočítá obvod obdelníku
        /// </summary>
        /// <returns>obvod obdelníku</returns>
        public override double CalculatePerimeter()
        {
            double O = 2 * SideA + 2 * SideB;
            return O;
        }


    }
}
