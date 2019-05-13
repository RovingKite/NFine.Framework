using NFine.EntityFramework.Entity.OAManage;
using NFine.EntityFramework.Entity.SystemManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFine.Repository.OAManage
{
    public class ResFileRecycleRepository : ConfigurationBasedRepository<ResFileRecycle, long>
    {
        public ResFileRecycleRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
