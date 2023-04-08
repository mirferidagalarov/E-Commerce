using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.Models.Entities;
using E_commerce_.NET5_.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E_commerce_.NET5_.AppCode.Application.SpecificationModule
{
    public class SpecificationPagedQuery : IRequest<PagedViewModel<Specification>>
    {
        int pageIndex;
        int pageSize;
        public int? Id { get; set; }
        public int PageIndex {
            get
            {
                if (pageIndex > 0)
                    return pageIndex;
            
                   return 1;
            
            }
            set {
                if (value>0)
                {
                    pageIndex = value;
                }
                else
                {
                    pageIndex = 1;
                }
            
            }
        }
        public int PagedSize
        {
            get
            {
                if (pageSize > 0)
                    return pageSize;

                return 15;

            }
            set
            {
                if (value > 0)
                {
                    pageSize = value;
                }
                else
                {
                    pageSize = 15;
                }

            }
        }
        public class  SpecificationPagedQueryHandler : IRequestHandler<SpecificationPagedQuery,PagedViewModel<Specification>>
        {
            readonly Dbcontext _dbcontext;
            public SpecificationPagedQueryHandler(Dbcontext dbcontext)
            {
                _dbcontext = dbcontext; 
            }
            public async Task<PagedViewModel<Specification>>Handle(SpecificationPagedQuery request, CancellationToken cancellationToken)
            {
                var query = _dbcontext.Specifications.Where(m => m.DeletedByUserId == null);
                var pagedModel = new PagedViewModel<Specification>(query, request.PageIndex, request.PagedSize);
                return pagedModel;

            }
        }
    }


    
}
