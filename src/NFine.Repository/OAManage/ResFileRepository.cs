using NFine.EntityFramework.Entity.OAManage;
using NFine.EntityFramework.Entity.SystemManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFine.Repository.OAManage
{
    public class ResFileRepository : ConfigurationBasedRepository<ResFile, long>
    {
        public ResFileRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
