using Application.Core;
using Application.Models.Response;
using MediatR;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Insurances;

public static class ArithmeticAverages
{
    public class Query : IRequest<Result<AveragesResponse>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<AveragesResponse>>
    {

        private readonly InsuranceContext _context;

        public Handler(InsuranceContext context)
        {
            _context = context;
        }

        public async Task<Result<AveragesResponse>> Handle(Query request,
            CancellationToken cancellationToken)
        {


            var query =
                await _context.Insurances.ToListAsync(
                    cancellationToken: cancellationToken);

            int count = query.Count();
            decimal sum = query.Sum(e => e.InsurancePrice);


            var average = _context.Insurances
                .AsEnumerable()
                .Average(x => x.InsurancePrice);  //SQLite doesn't support the Average function on decimal types directly



            //decimal average = await _context.Insurances.AverageAsync(
            //    e => e.InsurancePrice, cancellationToken: cancellationToken);
            var response = new AveragesResponse(average, sum, count);
            return Result<AveragesResponse>.Success(response);

        }
    }
}