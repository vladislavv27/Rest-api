using Bbit2taks.Model;

namespace Bbit2taks.Models
{
    public class CombinedRequestModel
    {
        public Resident Resident { get; set; }
        public string JwtToken { get; set; }
    }
}
