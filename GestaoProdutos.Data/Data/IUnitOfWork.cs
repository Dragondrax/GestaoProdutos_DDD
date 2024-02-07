namespace GestaoProdutos.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}