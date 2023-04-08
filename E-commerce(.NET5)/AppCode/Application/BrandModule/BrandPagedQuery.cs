using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.Models.Entities;
using E_commerce_.NET5_.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E_commerce_.NET5_.AppCode.Application. BrandModule
{
    public class BrandPagedQuery : IRequest<PagedViewModel<Brand>>
    {
        int pageIndex;
        int pageSize;
        public int? Id { get; set; }
        public int PageIndex
        {
            get
            {
                if (pageIndex > 0)
                    return pageIndex;

                return 1;

            }
            set
            {
                if (value > 0)
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
        public class  BrandPagedQueryHandler : IRequestHandler<BrandPagedQuery, PagedViewModel<Brand>>
        {
            readonly Dbcontext _dbcontext;
            public BrandPagedQueryHandler(Dbcontext dbcontext)
            {
                _dbcontext = dbcontext; 
            }
            public async Task<PagedViewModel<Brand>>Handle(BrandPagedQuery request, CancellationToken cancellationToken)
            {
                var query = _dbcontext.Brands.Where(m => m.DeletedByUserId == null);
                var pagedModel = new PagedViewModel<Brand>(query,request.PageIndex,request.PagedSize);
                return pagedModel;
            }
        }
    }


    
}
