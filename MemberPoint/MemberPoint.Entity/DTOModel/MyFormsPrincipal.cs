using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Web.Security;


namespace MemberPoint.Entity.DTOModel
{
    public class MyFormsPrincipal<T> : IPrincipal where T : class, new()
    {

        //1. 定义MyFormsPrincipal<T> 实现IPrincipal接口
        //2. 定义两个属性和字段 IIdentity，并且构造Get访问器
        //3. 创建一个构造函数MyFormsPrincipal(FormsAuthenticationTicket ticket, T userData)
        //对_identity进行实例化 new FormsIdentity(ticket);
        //userData进行赋值
        //4. 实现IsInRole方法 public bool IsInRole(string role)
        //将_userData 转为IPrincipal接口
        //调用IsInRole方法 
        public IIdentity Identity
        {
            get;
            private set;
        }
        public T UserData
        {
            get;
            private set;
        }
        public MyFormsPrincipal(FormsAuthenticationTicket ticket, T userData)
        {
            this.Identity = new FormsIdentity(ticket);
            this.UserData = userData;
        }
        //public bool IsInRole(string role)
        //{
        //    //IPrincipal principal = UserData as IPrincipal;
        //    //if (principal == null)
        //    //    throw new ArgumentNullException("principal");
        //    //return principal.IsInRole(role);
        //    throw new NotImplementedException();
        //}

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
