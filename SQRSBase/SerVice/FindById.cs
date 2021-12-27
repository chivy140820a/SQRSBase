using MediatR;
using Microsoft.EntityFrameworkCore;
using SQRSBase.Cache;
using SQRSBase.Catalog;
using SQRSBase.Data;
using SQRSBase.Validation;

namespace SQRSBase.SerVice
{
    public static class FindById<T> where T : class
    {
        public record Query(int Id) : IRequest<FindResponse<T>>, ICacheable
        {
            public string CacheKey => $"Id{Id}";
        }

        public class Validator : IValidationHandler<Query>
        {
            private readonly AppDbContext _context1;
            private DbSet<T> table1;
            public Validator(AppDbContext context1)
            {
                _context1 = context1;
                table1 = _context1.Set<T>();
            }
            public async Task<ValidationResult> Validate(Query request)
            {
                var list = await table1.ToListAsync();
                var findById = await table1.FindAsync(request.Id);
                if (!list.Contains(findById))
                {
                    return ValidationResult.Fail("Not found");
                }
                return ValidationResult.Success;
            }
        }
        public class Handler : IRequestHandler<Query, FindResponse<T>>
        {
            private readonly AppDbContext _context;
            private DbSet<T> table;
            public Handler(AppDbContext context)
            {
                _context = context;
                table = _context.Set<T>();
            }

            public async Task<FindResponse<T>> Handle(FindById<T>.Query request, CancellationToken cancellationToken)
            {
                var find = await table.FindAsync(request.Id);
                var res = new FindResponse<T>()
                {
                    entity = find
                };
                return res;
            }
        }

    }
}
