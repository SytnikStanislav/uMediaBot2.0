using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uMediaBotAPI.DAL.Data;
using uMediaBotAPI.DAL.Interfaces;
using uMediaBotAPI.DAL.Repositories;

namespace uMediaBotAPI.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(MediaBotDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private MediaBotDbContext _context;
        private IMapper _mapper;
        private FoldersRepository _foldersRepository;

        public FoldersRepository FoldersRepository 
            => _foldersRepository ?? (_foldersRepository = 
                                            new FoldersRepository(_context, _mapper));

        public bool Save()
        {
            try
            {
                var changes = _context.ChangeTracker.Entries().Count(
                    p => p.State == EntityState.Modified 
                      || p.State == EntityState.Deleted
                      || p.State == EntityState.Added);

                if (changes == 0) return true;
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
