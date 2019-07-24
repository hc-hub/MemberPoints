using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemberPoint.Business;
using MemberPoint.Common;
using MemberPoint.Entity.POCOModel;
using MemberPoint.Entity.ViewModel;

namespace MemberPoint.Controllers
{
    public class UsersController : Controller
    {
        private UserService _UserService = new UserService();
        #region  用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                OperateResult result = _UserService.Login(loginModel);
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
                ModelState.AddModelError("", "验证信息不通过"); ;
            }
            return View(loginModel);
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
        #endregion       
        #region  用户列表展示
        // GET: Users
        /// <summary>
        /// 用户默认列表信息查询（无分页）
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var result = _UserService.GetUserList();
            return View(result.Data);
        }
        #region  Table分页
        public ActionResult UsersManage()
        {
            return View();
        }
        public ActionResult UsersList(GetPageUsersListViewModel pageModel)
        {
            var result = _UserService.GetUserList(pageModel);
            return Json(result.Data);
        }
        #endregion Table分页
        #endregion 用户列表展示
        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(Users usersModel)
        {
            try
            {
                // TODO: Add insert logic here
                var result = _UserService.AddUsers(usersModel);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("添加失败");
                }
            }
            catch
            {
                return View();
            }
        }
        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
