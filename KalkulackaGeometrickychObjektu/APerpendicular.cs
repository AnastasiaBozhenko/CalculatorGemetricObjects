
namespace KalkulackaGeometrickychObjektu
{
    public abstract class APerpendicular<TPedestal> : A3D where TPedestal : A2D
    {
        /// <summary>
        /// Strana geometrického objektu v cm
        /// </summary>
        public virtual double Height { get; set; }

        public TPedestal Pedestal { get; protected set; }

        /// <summary>
        /// Podstavec 3d objektu
        /// </summary>
        /// <returns></returns>
        protected double PedestalContent()
        {
            return Pedestal.CalculateContent();
        }
        /// <summary>
        /// Vypočítá objem objektu na základě vyšky a podstavce
        /// </summary>
        /// <returns>Objem objektu</returns>
        public override double CalculateVolume()
        {
            return Height * PedestalContent();
        }
    }
}
