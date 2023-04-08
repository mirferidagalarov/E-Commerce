using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.AppCode.Extensions;
using E_commerce_.NET5_.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace E_commerce_.NET5_.AppCode.Application. BrandModule
{
    public class BrandCreateCommand:IRequest<int>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public class  BrandCreateCommandHandler : IRequestHandler<BrandCreateCommand, int>
        {
            readonly Dbcontext _dbcontext;
            readonly IActionContextAccessor _accessor;
            public  BrandCreateCommandHandler(Dbcontext dbcontext, IActionContextAccessor accessor  )
            {
                _dbcontext = dbcontext;
                _accessor = accessor;
            }

            public async Task<int> Handle(BrandCreateCommand request, CancellationToken cancellationToken)
            {
                if (_accessor.IsModelStateValid())
                {
                     Brand  Brand = new  Brand();
                     Brand.Name = request.Name;
                     Brand.Description = request.Description;

                    _dbcontext.Add( Brand);
                    await _dbcontext.SaveChangesAsync(cancellationToken);
                    return  Brand.Id;
                }
                return 0;

            }
        }
    }
}
