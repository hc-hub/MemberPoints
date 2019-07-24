using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using MemberPoint.Common;
using MemberPoint.Entity.DTOModel;

namespace MemberPoint
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(object sender,EventArgs e) {          
            //1.通过sender获取HttpApplication
            HttpApplication app = sender as HttpApplication;
            //2.拿到HTTP上下文         
            HttpContext context = app.Context;
            //3.根据FormsAuthentication.FormsCookieName从上下文请求中获取到Cookie           
            var cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null) {
                if (!string.IsNullOrWhiteSpace(cookie.Value))
                {
                    //4.解密cookie.Value获得票据
                    var ticket = FormsAuthentication.Decrypt(cookie.Value);
                    if (!string.IsNullOrWhiteSpace(ticket.UserData))
                    {
                        //5.判断票据的UserData，如果不为空则反序列化为实体
                        var dtoModel = ticket.UserData.ToObject<LoginUserDTOModel>();
                        //6.将上下文中的User数据实例化，通过MyFormsPrincipal的构造函数
                        context.User = new MyFormsPrincipal<LoginUserDTOModel>(ticket, dtoModel);
                    }
                }
            }
        }
    }
}
