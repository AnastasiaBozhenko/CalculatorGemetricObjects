
namespace KalkulackaGeometrickychObjektu
{
    [GeomObject("Cube")]
    public class Cube : Block
    {
        private double _height;
        public override double Height
        {
            get => _height;
            set
            {
                _height = value;
                Pedestal.SideA = value;
                Pedestal.SideB = value;
            }
        }

        public override double SideA
        {
            get => Height;
            set => Height = value;
        }
        public override double SideB
        {
            get => Height;
            set => Height = value;
        }

        public Cube()
        {
            Pedestal = new Square();
        }

        public override void LoadValues(params double[] sides)
        {
            if (sides is null || sides.Length == 0)
            {
                Utils.FindOutSide("height", "cube", out double height);
                Height = height;
            }
            else
            {
                Height = sides[0];
            }
        }

        public override double CalculateSurface()
        {
            return PedestalContent() * 6;
        }



    }
}
