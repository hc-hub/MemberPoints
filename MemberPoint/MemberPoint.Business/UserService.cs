using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberPoint.Entity.POCOModel;
using MemberPoint.Entity.ViewModel;
using MemberPoint.Entity.DTOModel;
using MemberPoint.Common;
using System.Web;
using System.Web.Security;

namespace MemberPoint.Business
{
    public class UserService : BaseService<Users>
    {
        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        public OperateResult Login(LoginViewModel loginViewModel)
        {
            var model = Find(e => e.U_Password == loginViewModel.Password && e.U_LoginName == loginViewModel.UserName);
            if (model != null)
            {
                var dtoUserModel = new LoginUserDTOModel
                {
                    Id = model.U_ID,
                    UserName = model.U_LoginName,
                    RealName = model.U_RealName,
                    RoleId = (int)model.U_Role
                };
                SetUserData(dtoUserModel);
                return new OperateResult(ResultStatus.Success, "登录成功");
            }
            else
            {
                return new OperateResult(ResultStatus.Error, "登录失败");
            }
        }
        /// <summary>
        /// 存入票据信息
        /// </summary>
        /// <param name="dtoUserModel"></param>
        public void SetUserData(LoginUserDTOModel dtoUserModel)
        {
            //1、获取用户数据转成json
            var userData = dtoUserModel.ToJson();

            //2、创建票据FormsAuthenticationTicket(对票据进行加密FormsAuthentication.Encrypt)（https://technet.microsoft.com/zh-cn/library/system.web.security.formsauthenticationticket.version）        
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, "loginUser", DateTime.Now, DateTime.Now.AddDays(1), false, userData);
            //加密
            var ticketEncrypt = FormsAuthentication.Encrypt(ticket);
            //3、创建Cookie  HttpCookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketEncrypt);
            cookie.Expires = DateTime.Now.Add(FormsAuthentication.Timeout);
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            //4、获取HTTP上下文 HttpContext;
            HttpContext context = HttpContext.Current;
            if (context == null)
            {
                throw new ArgumentNullException("context为空");
            }
            //5、写入Cookie（https://www.cnblogs.com/tzyy/p/4151291.html）
            context.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            context.Response.Cookies.Add(cookie);
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        public void Logout()
        {
            //1.删除票据
            FormsAuthentication.SignOut();
            //2.清除Cookie
            HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
        }
        #endregion
        /// <summary>
        /// 获取用户列表信息
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public OperateResult GetUserList()
        {
            //var query1 = PredicateExtensions.True<Users>();
            var query = GetList(e => true).Select(e => new UsersViewModel
            {
                U_ID = e.U_ID,
                S_Name = e.Shops.S_Name,
                U_LoginName = e.U_LoginName,
                U_RealName = e.U_RealName,
                U_Sex = e.U_Sex,
                U_Telephone = e.U_Telephone,
                U_RoleName = ((RoleTypeEnum)e.U_Role).ToString()
            }).ToList();
            return new OperateResult(ResultStatus.Success, "", query);
        }
        /// <summary>
        /// 获取用户列表带分页
        /// </summary>
        /// <param name="pageView"></param>
        /// <returns></returns>
        public OperateResult GetUserList(GetPageUsersListViewModel pageView)
        {
            var query = PredicateExtensions.True<Users>();
            if (!string.IsNullOrWhiteSpace(pageView.U_LoginName))
            {
                query = query.And(e => e.U_LoginName == pageView.U_LoginName.Trim());
            }
            if (!string.IsNullOrWhiteSpace(pageView.U_Telephone))
            {
                query = query.And(e => e.U_Telephone.Contains(pageView.U_Telephone.Trim()));
            }
            int rowCount = 0;
            var pageData = GetList(pageView.pageIndex, pageView.pageSize, ref rowCount, query, e => e.U_ID, true)
                .Select(e => new UsersViewModel
                {
                    U_ID = e.U_ID,
                    S_Name = e.Shops.S_Name,
                    U_LoginName = e.U_LoginName,
                    U_RealName = e.U_RealName,
                    U_Sex = e.U_Sex,
                    U_Telephone = e.U_Telephone,
                    U_RoleName = ((RoleTypeEnum)e.U_Role).ToString()
                }).ToList();
            var dataGridViewModel = new DataGridViewModel { total = rowCount, rows = pageData };
            return new OperateResult(ResultStatus.Success, "", dataGridViewModel);
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="usersModel"></param>
        /// <returns></returns>
        public OperateResult AddUsers(Users usersModel)
        {
            if (Add(usersModel))
            {
                return new OperateResult(ResultStatus.Success, "添加成功");
            }
            else
            {
                return new OperateResult(ResultStatus.Error, "添加失败");
            }

        }
        public OperateResult EditUsers(Users usersModel)
        {
            if (Find(e => e.U_ID == usersModel.U_ID) == null)
            {
                return new OperateResult(ResultStatus.Error, "该数据不存在");
            }
            else if (Update(usersModel))
            {
                return new OperateResult(ResultStatus.Success, "修改成功");
            }
            else
            {
                return new OperateResult(ResultStatus.Error, "修改失败");
            }

        }
        public OperateResult DeleteUsers(int id)
        {
            var userModel = Find(e => e.U_ID == id);
            if (userModel == null)
            {
                return new OperateResult(ResultStatus.Error, "该数据不存在");
            }
            else if (Delete(userModel))
            {
                return new OperateResult(ResultStatus.Success, "删除成功");
            }
            else
            {
                return new OperateResult(ResultStatus.Success, "删除失败");
            }
        }
    }
}
