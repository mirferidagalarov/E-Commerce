using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.AppCode.Application.SpecificationModule;
using E_commerce_.NET5_.AppCode.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E_commerce_.NET5_.AppCode.Application.SpecificationModule
{
    public class SpecificationEditCommand: SpecificationViewModel,IRequest<int>
    {

        public class BranEditCommandHandler : IRequestHandler<SpecificationEditCommand, int>
        {
            readonly Dbcontext _dbcontext;
            readonly IActionContextAccessor _accessor;
            public BranEditCommandHandler(Dbcontext dbcontext, IActionContextAccessor accessor)
            {
                _dbcontext = dbcontext;
                _accessor = accessor;
            }
            public async Task<int> Handle(SpecificationEditCommand request, CancellationToken cancellationToken)
            {
                if (request.Id==null||request.Id<0)
                {
                    return 0;
                }
                var entity=await _dbcontext.Specifications.FirstOrDefaultAsync(b=>b.Id==request.Id &&b.DeletedByUserId==null);
                if (entity==null)                
                    return 0;

                if (_accessor.IsModelStateValid())
                {
                    entity.Name=request.Name;
                    await _dbcontext.SaveChangesAsync();
                    return entity.Id;
                }
                return 0;
            }
        }
    }
}
