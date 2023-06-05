using ProjetoPrevisaoTempo.Infra.Data.Contexts;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPrevisaoTempo.Infra.Data.UoW
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            try
            {
                var changeAmount = await _context.SaveChanges();

                return changeAmount > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return false;

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
