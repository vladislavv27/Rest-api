namespace Bbit2taks.Model
{
    public class Iedzivotajs
    {
        public long Id { get; set; }
        public string Vards { get; set; }
        public string Uzvards { get; set; }
        public string PersonasKods { get; set; }
        public DateTime DzimsanasDatums { get; set; }
        public string Telefons { get; set; }
        public string Email { get; set; }
        public long DzivoklisId { get; set; }
        public Dzivoklis Dzivoklis { get; set; }

    }
}
