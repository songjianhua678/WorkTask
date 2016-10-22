using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkWebCore.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkWebCore.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Unauthorized(string username,string password,string returnUrl = null)
        {
            try
            {
                using (var DB = new WorkRecordsContext())
                {
                    var usermodel = (from t in DB.WorkUser where t.username == username && t.password == password select t).FirstOrDefault();
                    if (usermodel != null)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, username, ClaimValueTypes.String, ""));
                        var userIdentity = new ClaimsIdentity("管理员");
                        userIdentity.AddClaims(claims);
                        var userPrincipal = new ClaimsPrincipal(userIdentity);
                        await HttpContext.Authentication.SignInAsync("MyCookieMiddlewareInstance", userPrincipal,
                            new AuthenticationProperties
                            {
                                ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                                IsPersistent = false,
                                AllowRefresh = false
                            });

                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Account");//登录失败
                    }

                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Account");//失败
            }

        }

        public IActionResult Forbidden()
        {
            return View();
        }



    }
}
