using Estapar.CarStay.Data.Context;
using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Data.Repositories.Interfaces;

namespace Estapar.CarStay.Data.Repositories.Concrets
{
    public class PassageRepository : BaseRepository<Passage>, IPassageRepository
    {
        public PassageRepository(CarStayContext dbContext) : base(dbContext)
        {
        }

        #region IDisposable Members

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
    }
}
