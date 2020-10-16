using System;
using System.Collections.Generic;
using System.Text;

namespace ISTA422Exercise.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPeopleRepository People { get; }

        void Save();
    }
}
