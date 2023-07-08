using Application.Core;
using MediatR;

namespace Application.Models.Requests
{
    public class AddInsuranceRequest
    {
        public required string InsuredDocument { get; init; }
        public required Guid VehicleId { get; init; }
    }
}
