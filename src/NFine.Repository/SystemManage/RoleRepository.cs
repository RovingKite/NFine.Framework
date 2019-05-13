using NFine.EntityFramework.Entity.SystemManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFine.Repository.SystemManage
{
    public class RoleRepository : ConfigurationBasedRepository<Role, long>
    {
        public RoleRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}