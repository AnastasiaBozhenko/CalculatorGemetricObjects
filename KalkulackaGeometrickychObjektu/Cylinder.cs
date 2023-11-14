using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulackaGeometrickychObjektu
{
    [GeomObject("Cylinder")]
    public class Cylinder : APerpendicular<Circle>
    {
        public virtual double _radius
        {
            get => Pedestal.Radius;
            set => Pedestal.Radius = value;
        }

        public Cylinder()
        {
            Pedestal=new Circle();
        }
        public override void LoadValues(params double[] sides)
        {
            if (sides is null || sides.Length == 0)
            {
                Pedestal.LoadValues();
                Utils.FindOutSide("height", "cylinder", out double height);
                Height = height;
            }
            else
            {
                Height = sides[0];
            }
        }
        public override double CalculateSurface()
        {
            double S = 2 * Math.PI *Math.Pow( _radius, 2) + 2 * Math.PI * _radius * Height;
            return S;
        }
    }
}
