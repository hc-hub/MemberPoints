using MemberPoint.Business;
using MemberPoint.Common;
using MemberPoint.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPMS.Web.Controllers
{
    //AuthorizeFilter是扩展特性，自定义特性名称是根据上面的类MemberCheckAttribute名进行变化

    //当访问/user/index时，程序会先走自定义特性AuthorizeFilter然后再走Index

    //[AuthorizeFilter]
    public class HomeController : Controller
    {
        private UserService _UserService = new UserService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            //1.模型校验
            if (ModelState.IsValid)
            {
                //2.如果校验通过处理登录流程
                var result = _UserService.Login(viewModel);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var returnUrl = Request["ReturnUrl"];
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Msg);
                }
            }
            else
            {
                ModelState.AddModelError("", "输入的用户名或密码有误");
            }

            //3.如果不通过则提示用户
            return View(viewModel);
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            _UserService.Logout();
            return RedirectToAction("Login");
        }
        public ActionResult ExchangPassword()
        {
            return View();
        }
        public ActionResult ExchangeMessage()
        {
            return View();
        }
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}