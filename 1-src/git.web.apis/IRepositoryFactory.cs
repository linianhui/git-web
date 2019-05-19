using LibGit2Sharp;

namespace Git.Web.Apis
{
    public interface IRepositoryFactory
    {
        IRepository GetRepository();
    }
}
