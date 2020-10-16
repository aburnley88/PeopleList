using System;
using System.Collections.Generic;
using System.Text;
using ISTA422Exercise.Data.Data;
using ISTA422Exercise.Data.Repository.IRepository;

namespace ISTA422Exercise.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            People = new PeopleRepository(_db);
           
        }

        public IPeopleRepository People { get; private set; }
        

        //Only place to save DB becauase unitofwork is a container and calls save at the parent level. Add unit of work to startup class 
        public void Save()
        {
            _db.SaveChanges();
        }


        void IDisposable.Dispose()
        {
            _db.Dispose();
        }
    }
}
