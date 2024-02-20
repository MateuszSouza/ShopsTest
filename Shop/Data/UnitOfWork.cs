namespace Shop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly DataContext _dataContext; 
        public UnitOfWork(DataContext data)
        {
            _dataContext = data;
        }

        public void Commit()
        {
            _dataContext.SaveChanges();
        }

        public void RollBack()
        {
            //
        }
    }
}
