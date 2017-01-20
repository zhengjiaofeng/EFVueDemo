using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Common
{
    public class UnitOfWork : IDisposable
    {

        private readonly EFContext context;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public UnitOfWork(EFContext efContext)
        {
            this.context = efContext;
        }

        public UnitOfWork() {
            context = new EFContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Save() {
            this.context.SaveChanges();
        }

         public Repository<T> Repository<T>() where T : BaseEntity
       {
           if (repositories == null)
           {
               repositories = new Dictionary<string, object>();
           }

           var type = typeof(T).Name;

           if (!repositories.ContainsKey(type))
           {
               var repositoryType = typeof(Repository<>);
               var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
               repositories.Add(type, repositoryInstance);
           }
           return (Repository<T>)repositories[type];
       }

    
    }
}