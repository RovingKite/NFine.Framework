using NFine.EntityFramework.Entity.SystemSecurity;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFine.Repository.SystemSecurity
{
    public class OperateLogRepository : ConfigurationBasedRepository<OperateLog, long>
    {
        public OperateLogRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
