using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace MPMS.Web.App_Start
{
    public class AuthorizeFilterAttribute : AuthorizeAttribute
    {
        //AuthorizeAttribute的OnAuthorization方法内部调用了AuthorizeCore方法，
        //这个方法是实现验证和授权逻辑的地方，
        //如果这个方法返回true，表示授权成功，
        //如果返回false， 表示授权失败, 会给上下文设置一个HttpUnauthorizedResult，
        //这个ActionResult执行的结果是向浏览器返回一个401状态码,但是返回状态码没什么意思，
        //通常是跳转到一个登录页面，可以重写AuthorizeAttribute的HandleUnauthorizedRequest跳转到相应的页面
        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    base.AuthorizeCore(httpContext);
        //    if (true)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //如果AuthorizeCore返回false才会执行HandleUnauthorizedRequest

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    base.HandleUnauthorizedRequest(filterContext);
        //    if (filterContext == null)
        //    {
        //        throw new ArgumentNullException("filterContext");
        //    }
        //    else
        //    {
        //        filterContext.HttpContext.Response.Redirect("/Home/Login");
        //    }
        //}
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var isAuth = false;
            if (!filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                isAuth = false;
            }
            else
            {
                if (filterContext.RequestContext.HttpContext.User.Identity != null)
                {
                    //var roleApi = new RoleApi();
                    //var actionDescriptor = filterContext.ActionDescriptor;
                    //var controllerDescriptor = actionDescriptor.ControllerDescriptor;
                    //var controller = controllerDescriptor.ControllerName;
                    //var action = actionDescriptor.ActionName;
                    //var ticket = (filterContext.RequestContext.HttpContext.User.Identity as FormsIdentity).Ticket;
                    //var role = roleApi.GetById(ticket.Version);
                    //if (role != null)
                    //{
                    //    isAuth = role.Permissions.Any(x => x.Permission.Controller.ToLower() == controller.ToLower() && x.Permission.Action.ToLower() == action.ToLower());
                    //}
                }
            }
            if (!isAuth)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "account", action = "login", returnUrl = filterContext.HttpContext.Request.Url, returnMessage = "您无权查看." }));
                return;
            }
            else
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
}