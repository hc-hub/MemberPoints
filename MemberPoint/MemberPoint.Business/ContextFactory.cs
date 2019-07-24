using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberPoint.Entity.POCOModel;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace MemberPoint.Business
{
    /// <summary>
    /// 从线程中获取数据访问上下文，保证线程内实例唯一
    /// </summary>
    public class ContextFactory
    {
        public static DbContext GetCurrentContext()
        {
            //查询一个列表信息（数据常年不变）
            
            //直接访问数据库查询数据并显示页面

            //1、直接访问缓存内存的数据
            //2.1 有数据，直接读取显示
            //2.2 没数据，访问数据库显示页面，把得到的数据放入缓存内


            //从线程中取dbcontext
            DbContext context = CallContext.GetData("MemberPointModel") as DbContext;
            //如果获取不到
            if (context == null)
            {
                context = new MemberPointModel();//直接从MemberPointModel中取dbcontext
                CallContext.SetData("MemberPointModel", context);//存入线程中dbcontext
            }
            return context;
        }
    }
}
