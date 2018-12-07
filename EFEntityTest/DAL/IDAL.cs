using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL<T> where T : EFEntity
    {
        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<T> FindList(Expression<Func<T, bool>> where);

        /// <summary>
        /// 按条件查询，排序
        /// </summary>
        /// <typeparam name="S"><peparam>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IQueryable<T> FindList<S>(Expression<Func<T, bool>> where, Expression<Func<T, S>> orderBy, bool isAsc);

        /// <summary>
        /// 按条件查询，分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<T> FindPagedList(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, bool>> where);

        /// <summary>
        /// 按条件查询，分页，排序
        /// </summary>
        /// <typeparam name="S"><peparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IQueryable<T> FindPagedList<S>(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, bool>> where, Expression<Func<T, S>> orderBy, bool isAsc);

        IQueryable<T> FindPagedList<S>(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, S>> orderBy, bool isAsc);

        IQueryable<T> FindPagedList(int pageIndex, int pageSize, out int rowCount);
    }
}
