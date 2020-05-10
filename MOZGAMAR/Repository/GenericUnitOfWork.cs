﻿using MOZGAMAR.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOZGAMAR.Repository
{
    public class GenericUnitOfWork : IDisposable
    {
        private MOZGAMEREntities DBEntity = new MOZGAMEREntities();

        public IRepository<Tbl_EntityType> GetRepositoryInstance<Tbl_EntityType>() where Tbl_EntityType : class
        {
            return new GenericRepository<Tbl_EntityType>(DBEntity);
        }

        public void SaveChanges()
        {
            DBEntity.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DBEntity.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;


    }
}