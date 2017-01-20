using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Repository.Common
{
    public class Repository<T> where T : BaseEntity
    {
        private EFContext efContext;
        private IDbSet<T> entity;

        public string errorMsg = string.Empty;
        public Repository(EFContext context)
        {
            this.efContext = context;
        }

        public T GetById(object id)
        {
          
            return entity.Find(id);
        }

        public void Insert(T model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("实体为空");
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

        public void upDate(T model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("实体为空");
                }
                this.efContext.SaveChanges();
            }
            catch (DbEntityValidationException ex) {
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

        /// <summary>
        /// 查找所有
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll() {
            if (entity == null) {
             return   efContext.Set<T>();
            }
            return entity;
        }
    }
}