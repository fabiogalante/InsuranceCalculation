using Domain.Core.Models;

namespace Domain.Entities
{
    public class Insurance : BaseEntity
    {
        public Insurance()
        {
            
        }

        public decimal InsurancePrice { get; set; }

        public Guid InsuredId { get; set; }
        public Insured Insured { get; set; }

        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
