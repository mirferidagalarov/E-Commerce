using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace E_commerce_.NET5_.AppCode.Application. SpecificationModule
{
    public class SpecificationSingleQuery : IRequest< Specification>
    {   
        public int? Id { get; set; }
        public class  SpecificationSingleQueryHandler : IRequestHandler<SpecificationSingleQuery,  Specification>
        {
            readonly Dbcontext _dbcontext;
            public  SpecificationSingleQueryHandler(Dbcontext dbcontext)
            {
                _dbcontext = dbcontext; 
            }
            public async Task< Specification> Handle(SpecificationSingleQuery request, CancellationToken cancellationToken)
            {
                if (request.Id == null || request.Id < 1)
                    return null;

                var  Specification = await _dbcontext.Specifications.FirstOrDefaultAsync(m => m.Id == request.Id);
                return  Specification;
            }
        }
    }


    
}
