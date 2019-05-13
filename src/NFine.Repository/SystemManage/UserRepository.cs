using NFine.EntityFramework.Entity.SystemManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFine.Repository.SystemManage
{
    public class UserRepository : ConfigurationBasedRepository<User, long>
    {
        public UserRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
