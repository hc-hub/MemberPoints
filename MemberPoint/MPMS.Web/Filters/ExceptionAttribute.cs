using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace MPMS.Web.Filters
{
    /// <summary>
    /// 异常处理过滤器，使用log4net记录日志，并跳转至错误页面
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class ExceptionAttribute : HandleErrorAttribute
    {
        ILog log = LogManager.GetLogger(typeof(ExceptionAttribute));
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                string message = string.Format("消息类型：{0}\r\n消息内容：{1}\r\n引发异常的方法：{2}\r\n引发异常源：{3}"
                    , filterContext.Exception.GetType().Name
                    , filterContext.Exception.Message
                     , filterContext.Exception.TargetSite
                     , filterContext.Exception.Source + filterContext.Exception.StackTrace
                     );

                //记录日志
                log.Error(message);
                //转向
                filterContext.ExceptionHandled = true;
                filterContext.Result = new RedirectResult("/Common/Error");
            }
            base.OnException(filterContext);
        }
    }
}