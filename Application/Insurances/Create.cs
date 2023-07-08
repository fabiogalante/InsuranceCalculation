using Application.Core;
using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Response;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Insurances
{
    public static class Create
    {
        public class Command : IRequest<Result<CreateInsuranceResponse>>
        {
            public Command(AddInsuranceRequest request)
            {
                Request = request;
            }

            public AddInsuranceRequest Request { get; }
        }

        public class Handler : IRequestHandler<Command, Result<CreateInsuranceResponse>>
        {
            private readonly InsuranceContext _context;
            private readonly IInsuranceData _insuranceData;

            public Handler(InsuranceContext context, IInsuranceData insuranceData)
            {
                _context = context;
                _insuranceData = insuranceData;
            }

            public async Task<Result<CreateInsuranceResponse>> Handle(Command request, CancellationToken cancellationToken)
            {
                var insured = await GetInsuredAsync(request.Request.InsuredDocument, cancellationToken);

                if (insured is null)
                {
                    return Result<CreateInsuranceResponse>.Failure("Insured error");
                }

                var vehicle = await GetVehicleAsync(request.Request.VehicleId, cancellationToken);

                if (vehicle is null)
                {
                    return Result<CreateInsuranceResponse>.Failure("Error car");
                }

                var insurancePrice = CalculateInsurancePrice(vehicle.Value);

                var insuranceToCreate = new Insurance
                {
                    InsurancePrice = insurancePrice,
                    VehicleId = request.Request.VehicleId,
                    InsuredId = insured.Id
                };

                await AddInsuranceAsync(insuranceToCreate, cancellationToken);

                return Result<CreateInsuranceResponse>.Success(new CreateInsuranceResponse("OK"));
            }

            private async Task<Insured> GetInsuredAsync(string insuredDocument, CancellationToken cancellationToken)
            {
                return await _context.Insureds
                    .FirstOrDefaultAsync(_ => _.Document == insuredDocument, cancellationToken: cancellationToken);
            }

            private async Task<Vehicle> GetVehicleAsync(Guid vehicleId, CancellationToken cancellationToken)
            {
                return await _context.Vehicles.FindAsync(vehicleId, cancellationToken);
            }

            private decimal CalculateInsurancePrice(decimal value)
            {
                _insuranceData.ValueOfTheVehicle = value;

                return _insuranceData.CalculateInsurancePrice();
            }

            private async Task AddInsuranceAsync(Insurance insurance, CancellationToken cancellationToken)
            {
                await _context.Insurances.AddAsync(insurance, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}