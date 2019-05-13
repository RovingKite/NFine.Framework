using NFine.EntityFramework.Entity.SystemManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFine.Repository.SystemManage
{
    public class DictRepository : ConfigurationBasedRepository<Dict, long>
    {
        public DictRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
