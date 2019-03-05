using NFineCore.EntityFramework.Dto.WeixinManage;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.EntityFramework.Entity.WeixinManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFineCore.Repository.WeixinManage
{
    public class WxUserRepository : ConfigurationBasedRepository<WxUser, long>
    {
        public WxUserRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
