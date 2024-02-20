namespace Shop.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    }
}
