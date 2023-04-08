using E_commerce_.NET5_.Models.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using e_commerce_.net5.Models.DataContext;
using Microsoft.EntityFrameworkCore;
using E_commerce_.NET5_.AppCode.Infrastructure;
using System;

namespace E_commerce_.NET5_.AppCode.Application.SpecificationModule
{
    public class SpecificationRemoveCommand : IRequest<CommandJsonResponse>
    {
        public int? Id { get; set; }
        public class SpecificationRemoveCommandHandler : IRequestHandler<SpecificationRemoveCommand, CommandJsonResponse>
        {
            readonly Dbcontext _dbcontext;
            public SpecificationRemoveCommandHandler(Dbcontext dbcontext)
            {
                _dbcontext = dbcontext;
            }
            public async Task<CommandJsonResponse> Handle(SpecificationRemoveCommand request, CancellationToken cancellationToken)
            {
                var response = new CommandJsonResponse();

                if (request.Id == null || request.Id < 1)
                {
                    response.Error = true;
                    response.Message = "Məlumat tamlığı qorunmayıb";
                    goto end;
                }
                var brand=await _dbcontext.Specifications.FirstOrDefaultAsync(m=>m.Id==request.Id && m.DeletedByUserId==null);
                if (brand==null)
                {
                    response.Error = true;
                    response.Message = "Məlumat mövcud deyil";
                    goto end;
                }

                brand.DeletedByUserId = 1;  
                brand.DeletedDate = DateTime.Now;
                await _dbcontext.SaveChangesAsync(cancellationToken);


                response.Error = false;
                response.Message = "Uğurlu əməliyyat";
            end:
                return response;
               
            }

           
        }
    }
}
