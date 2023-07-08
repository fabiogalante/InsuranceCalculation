using Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Response;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Insurances;

public static class Details
{

    public class Query : IRequest<Result<InsuranceResponse>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<InsuranceResponse>>
    {

        private readonly InsuranceContext _context;

        public Handler(InsuranceContext context)
        {
            _context = context;
        }

        public async Task<Result<InsuranceResponse>> Handle(Query request,
            CancellationToken cancellationToken)
        {
            var insurance = await _context.Insurances
                .Where(_ => _.Id == request.Id)
                .Include(i => i.Insured)
                .Include(i => i.Vehicle)
                .Select(_ => new InsuranceResponse(_.InsurancePrice,_.Vehicle.Brand,_.Vehicle.Model))
                .FirstOrDefaultAsync(cancellationToken);

            return Result<InsuranceResponse>.Success(insurance);

        }
    }
}
    
    
        
    

