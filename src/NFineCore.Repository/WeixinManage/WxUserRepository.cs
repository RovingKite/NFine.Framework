using NFineCore.EntityFramework.Dtos.WeixinManage;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.EntityFramework.Models.WeixinManage;
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
