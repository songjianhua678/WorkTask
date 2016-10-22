using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkWebCore.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(string username, string password)
        {
            if (ModelState.IsValid)
            {
                Cms_User user = CmsUserData.GetUser(model.UserName, password);
                if (user != null)
                {
                    //FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddHours(8), false, model.UserName, "/");
                    string strEncryptTicket = FormsAuthentication.Encrypt(Ticket);
                    HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, strEncryptTicket);
                    if (model.RememberMe)
                    {
                        UserCookie.Expires = Ticket.Expiration;
                    }
                    System.Web.HttpContext.Current.Response.Cookies.Add(UserCookie);
                    Cms_User cmsuser = CmsUserData.GetUser(model.UserName);
                    SaveUserCookie(model.UserName, cmsuser.User_name, cmsuser.User_passwd);//2.0登录用

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "");
                    }
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    ModelState.AddModelError("", "用户名或密码不正确。");
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }
    }
}
