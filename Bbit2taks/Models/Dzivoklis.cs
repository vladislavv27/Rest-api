namespace Bbit2taks.Model
{
    public class Dzivoklis
    {
        public long Id { get; set; }
        public int Numurs { get; set; }
        public int Stavs { get; set; }
        public int IstabuSkaits { get; set; }
        public int IedzivotajuSkaits { get; set; }
        public double PilnaPlatiba { get; set; }
        public double DzivojamaPlatiba { get; set; }

        public long MajaId { get; set; }
        public Maja Maja { get; set; }

    }
}
