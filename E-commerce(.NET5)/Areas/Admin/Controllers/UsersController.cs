using e_commerce_.net5.Models.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;
using XAct.Users;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using E_commerce_.NET5_.Models.Entities.Membership;

namespace E_commerce_.NET5_.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly Dbcontext _context;
        public UsersController(Dbcontext context)
        {
            _context = context;
        }
        [Authorize("admin.users.index")]
        public async Task<IActionResult> Index()
        {

            var data = await _context.Users.ToListAsync();
            return View(data);
        }
        [Authorize("admin.users.details")]
        public async Task<IActionResult> Details(int id)
        {

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            ViewBag.Roles = await (from r in _context.Roles
                                   join ur in _context.UserRoles on new { RoleId = r.Id, UserId = user.Id } equals new { ur.RoleId, ur.UserId }
                                   into lJoin
                                   from Lj in lJoin.DefaultIfEmpty()
                                   select Tuple.Create(r.Id, r.Name, Lj != null)).ToListAsync();


            ViewBag.Principals = (from p in Program.principials
                                  join uc in _context.UserClaims on new { ClaimValue = "1", ClaimType = p, UserId = user.Id } equals new { uc.ClaimValue, uc.ClaimType, uc.UserId } into lJoin
                                  from lj in lJoin.DefaultIfEmpty()
                                  select Tuple.Create(p, lj != null)).ToList();
            return View(user);
        }

        [HttpPost]
        [Route("/user-set-role")]
        [Authorize("admin.users.setrole")]
        public async Task<IActionResult> SetRole(int userId, int roleId, bool selected)
        {

            #region Check user and role
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var role = await _context.Roles.FirstOrDefaultAsync(u => u.Id == roleId);
            if (user == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Xətalı sorğu"
                });
            }

            if (role == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Xətalı sorğu"
                });
            }
            #endregion

            if (selected)
            {
                if (await _context.UserRoles.AnyAsync(ur=>ur.UserId == userId &&ur.RoleId==roleId))
                {
                    return Json(new
                    {
                        error = true,
                        message = $"'{user.Name} {user.Surname}' adlı istifadəçi '{role.Name}'adlı roldadır!"
                    });
                        
                }
                else
                {
                    _context.UserRoles.Add(new RiodeUserRole
                    {
                        UserId = userId,
                        RoleId = roleId
                    });

                     _context.SaveChanges();

                    return Json(new
                    {
                        error = false,
                        message = $"'{user.Name} {user.Surname}' adlı istifadəçi '{role.Name}'rola əlavə edildi!"
                    }

                    );
                }
            }

            else
            {
                var userRole= await _context.UserRoles.FirstOrDefaultAsync(ur=>ur.UserId == userId && ur.RoleId==roleId);
                if (userRole== null)
                {
                    return Json(new
                    {
                        error = false,
                        message = $"'{user.Name} {user.Surname}' adlı istifadəçi '{role.Name}'rolda deyil!"
                    });

                }

                else
                {
                    _context.UserRoles.Remove(userRole);

                    _context.SaveChanges();

                    return Json(new
                    {
                        error = false,
                        message = $"'{user.Name} {user.Surname}' adlı istifadəçi '{role.Name}'roldan çıxarıldı!"
                    }

                    );
                }
            }

        }

        [HttpPost]
        [Route("/user-set-principal")]
        [Authorize("admin.users.setprincipal")]
        public async Task<IActionResult> SetPrincipal(int userId, string principalName, bool selected)
        {

            #region Check user and principal
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var hasPrincipal = Program.principials.Contains(principalName);
            if (user == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Xətalı sorğu"
                });
            }

            if (!hasPrincipal)
            {
                return Json(new
                {
                    error = true,
                    message = "Xətalı sorğu"
                });
            }
            #endregion

            if(selected)
            {
                if(await _context.UserClaims.AnyAsync(uc=>uc.UserId==userId && uc.ClaimType.Equals(principalName)&&uc.ClaimValue.Equals("1")))
                {
                    return Json(new
                    {
                        error=true,
                        message=$"'{user.Name} {user.Surname}' adlı istifadəçi '{principalName}' adlı səlahiyyətə malikdir"
                    });
                }
                else
                {
                    _context.UserClaims.Add(new RiodeUserClaim
                    {
                        UserId = userId,
                        ClaimType = principalName,
                        ClaimValue="1"
                    });

                    await _context.SaveChangesAsync();

                    return Json(new
                    {
                        error = false,
                        message = $"'{principalName}' adlı səlahiyyətə '{user.Name} {user.Surname}' adlı istifadəçi şamil edildi"
                    });
                }
            }
          
            else
            {
                var userClaim =await _context.UserClaims.FirstOrDefaultAsync(uc => uc.UserId == userId && uc.ClaimType.Equals(principalName) && uc.ClaimValue.Equals("1"));
                if(userClaim == null)
                {
                    return Json(new
                    {
                        error = true,
                        message = $"'{user.Name} {user.Surname}' adlı istifadəçi '{principalName}' adlı səlahiyyətə malik deyil"
                    });
                }
                else
                {
                    _context.UserClaims.Remove(userClaim);
                    await _context.SaveChangesAsync();
                    return Json(new
                    {
                        error = true,
                        message = $"'{user.Name} {user.Surname}' adlı istifadəçidən  '{principalName}' adlı səlahiyyət alındı"
                    });
                }
            }
        }
    }
}
