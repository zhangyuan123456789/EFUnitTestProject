using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL<T> where T : EFEntity
    {
        //private static ILog m_Log = log4net.LogManager.GetLogger("Errorlogger");
        //private static ILog m_Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DbContext _context;

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public void UsTransctions(T entity)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Entry<T>(entity).State = EntityState.Added;
                    _context.SaveChanges();
                    //throw new Exception();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
        public void NotUsTransctions(T entity)
        {

            try
            {
                _context.Entry<T>(entity).State = EntityState.Added;
                _context.SaveChanges();
                //throw new Exception();

            }
            catch
            {

            }

        }



        /// <summary>
        /// 返回两个序列得差集合
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IQueryable<T> GetExcept(List<T> source)
        {
            return _context.Set<T>().Except<T>(source);
        }
        //public int ExecuteSqlCommand(string sql, object[] paras)
        //{
        //    return _context.Database.ExecuteSqlCommand(sql, paras);
        //}

        #region 添加
        /// <summary>
        /// 新增一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Added;
            return _context.SaveChanges();
        }

        public void Add(params T[] entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }
        public void Add(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">待删除的实体</param>
        /// <returns></returns>
        public int Delete(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Deleted;
            return _context.SaveChanges();
        }

        public void Delete(params T[] entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
        public void Delete(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        #endregion

        #region 更新
        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
        public void Update(params T[] entities)
        {
            _context.Set<T>().UpdateRange(entities);
            _context.SaveChanges();
        }
        public void Update(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            _context.SaveChanges();
        }

        #endregion

        #region 查询
        public List<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking<T>().ToList<T>();
        }
        public T FindByID(Guid id)
        {
            return FindSingle(x => x.ID == id);
        }

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T FindSingle(Expression<Func<T, bool>> where)
        {

            var result = _context.Set<T>().Where(where);
            return result == null ? null : result.FirstOrDefault<T>();

        }
        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="whereExpr"></param>
        /// <returns></returns>
        public int Count(Expression<Func<T, bool>> whereExpr)
        {
            return _context.Set<T>().Count(whereExpr);
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="whereExpr"></param>
        /// <returns></returns>
        public bool Exist(Expression<Func<T, bool>> whereExpr)
        {
            return (_context.Set<T>().Count(whereExpr) > 0);
        }
        #endregion

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<T> FindList(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where);
        }


        /// <summary>
        /// 按条件查询，排序
        /// </summary>
        /// <typeparam name="S"><peparam>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> FindList<S>(Expression<Func<T, bool>> where, Expression<Func<T, S>> orderBy, bool isAsc)
        {

            var list = _context.Set<T>().Where(where);
            if (isAsc)
                list = list.OrderBy<T, S>(orderBy);
            else
                list = list.OrderByDescending<T, S>(orderBy);
            return list;
        }
        /// <summary>
        /// 按条件查询，分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<T> FindPagedList(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, bool>> where)
        {
            var list = _context.Set<T>().Where(where);
            rowCount = list.Count();
            list = list.Skip(pageSize * pageIndex).Take(pageSize);
            return list;
        }
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
        public IQueryable<T> FindPagedList<S>(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, bool>> where, Expression<Func<T, S>> orderBy, bool isAsc)
        {

            var list = _context.Set<T>().Where(where);
            rowCount = list.Count();
            if (isAsc)
                list = list.OrderBy<T, S>(orderBy).Skip(pageSize * pageIndex).Take(pageSize);
            else
                list = list.OrderByDescending<T, S>(orderBy).Skip(pageSize * pageIndex).Take(pageSize);
            return list;
        }
        public IQueryable<T> FindPagedList<S>(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, S>> orderBy, bool isAsc)
        {

            IQueryable<T> list = null;
            rowCount = _context.Set<T>().Count();
            if (isAsc)
                list = _context.Set<T>().OrderBy<T, S>(orderBy).Skip(pageSize * pageIndex).Take(pageSize);
            else
                list = _context.Set<T>().OrderByDescending<T, S>(orderBy).Skip(pageSize * pageIndex).Take(pageSize);
            return list;
        }
        public IQueryable<T> FindPagedList(int pageIndex, int pageSize, out int rowCount)
        {

            IQueryable<T> list = null;
            rowCount = _context.Set<T>().Count();

            list = _context.Set<T>().Skip(pageSize * pageIndex).Take(pageSize);

            return list;
        }
       
    }
}
