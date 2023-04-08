using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.AppCode.Extensions;
using E_commerce_.NET5_.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace E_commerce_.NET5_.AppCode.Application.SpecificationModule
{
    public class SpecificationCreateCommand:IRequest<int>
    {
        [Required]
        public string Name { get; set; }

        public class SpecificationCreateCommandHandler : IRequestHandler<SpecificationCreateCommand, int>
        {
            readonly Dbcontext _dbcontext;
            readonly IActionContextAccessor _accessor;
            public SpecificationCreateCommandHandler(Dbcontext dbcontext, IActionContextAccessor accessor  )
            {
                _dbcontext = dbcontext;
                _accessor = accessor;
            }

            public async Task<int> Handle(SpecificationCreateCommand request, CancellationToken cancellationToken)
            {
                if (_accessor.IsModelStateValid())
                {
                    Specification result = new Specification();
                    result.Name = request.Name;
                   

                    _dbcontext.Add(result);
                    await _dbcontext.SaveChangesAsync(cancellationToken);
                    return result.Id;
                }
                return 0;

            }
        }
    }
}
