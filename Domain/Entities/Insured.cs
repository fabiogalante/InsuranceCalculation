using Domain.Core.Models;

namespace Domain.Entities
{
    public class Insured : BaseEntity
    {
        public Insured()
        {

        }


        public string Name { get; init; }
        public string Document { get; init; }
        public int Age { get; init; }

        public Insurance Insurance { get; set; }

    }
}
