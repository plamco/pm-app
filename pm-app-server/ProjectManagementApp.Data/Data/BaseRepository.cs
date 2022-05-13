namespace ProjectManagementApp.Data.Data
{
    public abstract class BaseRepository
    {
        protected readonly IApplicationDbContext Context;

        public BaseRepository(IApplicationDbContext context)
        {
            Context = context;
        }
    }
}
