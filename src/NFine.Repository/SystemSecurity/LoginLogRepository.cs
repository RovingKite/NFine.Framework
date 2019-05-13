using NFine.EntityFramework.Entity.SystemSecurity;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFine.Repository.SystemSecurity
{
    public class LoginLogRepository : ConfigurationBasedRepository<LoginLog, long>
    {
        public LoginLogRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
