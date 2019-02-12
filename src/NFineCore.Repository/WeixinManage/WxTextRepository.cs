using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.EntityFramework.Models.WeixinManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFineCore.Repository.WeixinManage
{
    public class WxTextRepository : ConfigurationBasedRepository<WxText, long>
    {
        public WxTextRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
