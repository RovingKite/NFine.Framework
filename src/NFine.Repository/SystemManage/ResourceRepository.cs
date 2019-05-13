using NFine.EntityFramework.Entity.SystemManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFine.Repository.SystemManage
{
    public class ResourceRepository : ConfigurationBasedRepository<Resource, long>
    {
        public ResourceRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}