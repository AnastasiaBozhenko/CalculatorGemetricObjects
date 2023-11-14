
namespace KalkulackaGeometrickychObjektu
{
    [GeomObject("Block")]
    public class Block : APerpendicular<Rectangle>
    {
        public virtual double SideA 
        {
            get => Pedestal.SideA;
            set => Pedestal.SideA = value;
        }

        public virtual double SideB
        {
            get => Pedestal.SideB;
            set => Pedestal.SideB = value;
        }

        public Block()
        {
            Pedestal = new Rectangle();
        }

        public override void LoadValues(params double[] sides)
        {
            if (sides is null || sides.Length == 0)
            {
                Pedestal.LoadValues();
                Utils.FindOutSide("height", "block", out double height);
                Height = height;
            }
            else
            {
                Height = sides[0];
            }
        }
        public override double CalculateSurface()
        {
            double S = 2*( SideA *SideB+SideA*Height+SideB*Height);
            return S;
        }
    }
}
