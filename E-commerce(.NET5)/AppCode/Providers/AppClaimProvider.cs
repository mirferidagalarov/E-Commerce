using e_commerce_.net5.Models.DataContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using XAct.Library.Settings;

namespace E_commerce_.NET5_.AppCode.Providers
{
    public class AppClaimProvider : IClaimsTransformation
    {
        private readonly Dbcontext _dbcontext;
        public AppClaimProvider(Dbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity.IsAuthenticated && principal.Identity is ClaimsIdentity curentIdentity)
            {
                var userId = Convert.ToInt32(curentIdentity.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value);

                var user= await _dbcontext.Users.FirstOrDefaultAsync(c => c.Id == userId);

                if (user!=null)
                {
                    curentIdentity.AddClaim(new Claim("name", user.Name));
                    curentIdentity.AddClaim(new Claim("surname", user.Surname));
                }
                #region Reload roles for current user
                var role= curentIdentity.Claims.FirstOrDefault(c =>c.Type.Equals(ClaimTypes.Role));
                while (role != null)
                {
                    curentIdentity.RemoveClaim(role);
                    role = curentIdentity.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role));
                }
                var currentRoles = (from ur in _dbcontext.UserRoles
                                    join r in _dbcontext.Roles on ur.RoleId equals r.Id
                                    where ur.UserId == userId
                                    select r.Name).ToArray();
                foreach (var roleName in currentRoles)
                {
                    curentIdentity.AddClaim(new Claim(ClaimTypes.Role,roleName));
                }
                #endregion


                #region Reload claims for current user

                var currentClaims = curentIdentity.Claims.Where(c => Program.principials.Contains(c.Type)).ToArray();
                foreach (var claim in currentClaims)
                {
                    curentIdentity.RemoveClaim(claim);
                }
                var currentPolicies = await (from uc in _dbcontext.UserClaims
                                             where uc.UserId == userId && uc.ClaimValue == "1"
                                             select uc.ClaimType)
                                          .Union(from rc in _dbcontext.RoleClaims
                                                 join ur in _dbcontext.UserRoles on rc.RoleId equals ur.RoleId
                                                 where ur.UserId == userId && rc.ClaimValue == "1"
                                                 select rc.ClaimType).ToListAsync();

                foreach (var policy in currentPolicies)
                {
                    curentIdentity.AddClaim(new Claim(policy,"1"));
                }

                #endregion

            }

            return  principal;
        }
    }
}
