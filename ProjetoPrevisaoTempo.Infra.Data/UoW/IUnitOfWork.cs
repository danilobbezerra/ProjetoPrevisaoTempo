namespace ProjetoPrevisaoTempo.Infra.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
