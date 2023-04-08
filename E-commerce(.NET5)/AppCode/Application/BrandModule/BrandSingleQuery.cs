using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace E_commerce_.NET5_.AppCode.Application. BrandModule
{
    public class BrandSingleQuery : IRequest< Brand>
    {
        public int? Id { get; set; }
        public class  BrandSingleQueryHandler : IRequestHandler<BrandSingleQuery,  Brand>
        {
            readonly Dbcontext _dbcontext;
            public  BrandSingleQueryHandler(Dbcontext dbcontext)
            {
                _dbcontext = dbcontext; 
            }
            public async Task< Brand> Handle(BrandSingleQuery request, CancellationToken cancellationToken)
            {
                if (request.Id == null || request.Id < 1)
                    return null;

                var  brand = await _dbcontext. Brands.FirstOrDefaultAsync(m => m.Id == request.Id);
                return  brand;
            }
        }
    }


    
}
