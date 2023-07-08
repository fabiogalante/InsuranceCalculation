using Bogus;
using Domain.Entities;
using Bogus.Extensions.Brazil;

namespace InsuredMemberData
{
    public class InsuredsFake
    {
        public Insured GetInsured()
        {
            return new Faker<Insured>("pt_BR")
                .RuleFor(c => c.Age, c => c.Random.Number(18, 110))
                .RuleFor(i => i.Document, i => i.Person.Cpf())
                .RuleFor(u => u.Name, u => u.Name.FullName());

        }
    }
}