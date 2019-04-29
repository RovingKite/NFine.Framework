using NFineCore.EntityFramework.Entity.OAManage;
using NFineCore.EntityFramework.Entity.SystemManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFineCore.Repository.OAManage
{
    public class ResFileRecycleRepository : ConfigurationBasedRepository<ResFileRecycle, long>
    {
        public ResFileRecycleRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
