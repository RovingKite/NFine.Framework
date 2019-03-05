using NFineCore.EntityFramework.Entity.SystemManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFineCore.Repository.SystemManage
{
    public class PositionRepository : ConfigurationBasedRepository<Position, long>
    {
        public PositionRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}