using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Validation;

namespace EFDLL
{
    public class Repository<T> where T : BaseEntity
    {
        private EFDbContext efContext;
        private IDbSet<T> entity;
        public string errorMsg = string.Empty;

        public Repository(EFDbContext context)
        {
            this.efContext = context;
        }

        public T GetById(object id)
        {
            if (entity == null)
            {
                entity=efContext.Set<T>();
            }
            return entity.Find(id);
        }


        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            if (entity == null)
            {
                return efContext.Set<T>();
            }
            return entity;
        }

        public virtual IQueryable<T> GetAllByExpression(Expression<Func<T, bool>> expression)
        {
            if (entity == null)
            {
                return efContext.Set<T>().Where(expression);
            }
            return entity;
        }

        public void Insert(T model)
        {

            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("实体为空");
                }
                if (entity == null)
                {
                    entity = efContext.Set<T>();
                }
                entity.Add(model);
                this.efContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //错误处理机制
                foreach (var validationErros in ex.EntityValidationErrors)
                {
                    foreach (var errorInfo in validationErros.ValidationErrors)
                    {
                        errorMsg += string.Format("属性:{0} 错误消息:{1}", errorInfo.PropertyName, errorInfo.ErrorMessage)
                                    + Environment.NewLine;

                    }
                }
                throw new Exception(errorMsg, ex);
            }
        }

        public void Update(T model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("实体为空");
                }
                this.efContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //错误处理机制
                foreach (var validationErros in ex.EntityValidationErrors)
                {
                    foreach (var errorInfo in validationErros.ValidationErrors)
                    {
                        errorMsg += string.Format("属性:{0} 错误消息:{1}", errorInfo.PropertyName, errorInfo.ErrorMessage)
                                    + Environment.NewLine;

                    }
                }
                throw new Exception(errorMsg, ex);
            }
        }

        public void Delete(T model)
        {
            try
            {
                entity.Remove(model);
                this.efContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //错误处理机制
                foreach (var validationErros in ex.EntityValidationErrors)
                {
                    foreach (var errorInfo in validationErros.ValidationErrors)
                    {
                        errorMsg += string.Format("属性:{0} 错误消息:{1}", errorInfo.PropertyName, errorInfo.ErrorMessage)
                                    + Environment.NewLine;

                    }
                }
                throw new Exception(errorMsg, ex);
            }
        }
    }
}
