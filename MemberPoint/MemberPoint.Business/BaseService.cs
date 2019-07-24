using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MemberPoint.Business
{
    public class BaseService<T> where T : class, new()
    {
        protected DbContext db = ContextFactory.GetCurrentContext();
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Added;
            return db.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        /// <summary>
        ///查询实体
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().FirstOrDefault(whereLambda);
        }
        /// <summary>
        /// 查询获取列表
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda);
        }

        /// <summary>
        /// 查询列表带排序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> GetList<Tkey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderBy, bool isAsc = true)
        {
            if (isAsc)
            {
                return db.Set<T>().Where(whereLambda).OrderBy(orderBy);
            }
            else
            {
                return db.Set<T>().Where(whereLambda).OrderByDescending(orderBy);
            }
        }
        /// <summary>
        /// 查询列表分页加排序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> GetList<Tkey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda,Expression<Func<T, Tkey>> orderBy, bool isAsc = true)
        {
            pageIndex = pageIndex - 1 < 0 ? 1 : pageIndex;
            pageSize = pageSize - 1 < 0 ? 10 : pageSize;
            rowCount = db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                return db.Set<T>().Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return db.Set<T>().Where(whereLambda).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }
    }
    //知识点概述
    //.NET支持的类型参数约束有以下五种：
    //where T : struct                               | T必须是一个结构类型
    //where T : class                                | T必须是一个Class类型
    //where T : new()                               | T必须要有一个无参构造函数
    //where T : NameOfBaseClass          | T必须继承名为NameOfBaseClass的类
    //where T : NameOfInterface             | T必须实现名为NameOfInterface的接口

    //http://blog.csdn.net/commandbaby/article/details/51074307
    //out、ref都是引用传递，传递后使用都会改变原有的值
    //out是只出不进。ref是有进有出，
    //out用法，一般用于需要返回多个参数时，如在需要返回分页的数据时 同时返回总条数或者TryParse()会用到
    //ref用法，一般用于在改变一个参数时，把他的改变反应到变量中 如在递归中
    //out传递参数时不用赋值(如果赋值也会被清空)  
}
