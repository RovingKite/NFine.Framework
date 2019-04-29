using NFineCore.EntityFramework.Entity.OAManage;
using NFineCore.EntityFramework.Entity.SystemManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFineCore.Repository.OAManage
{
    public class ResFileRepository : ConfigurationBasedRepository<ResFile, long>
    {
        public ResFileRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
