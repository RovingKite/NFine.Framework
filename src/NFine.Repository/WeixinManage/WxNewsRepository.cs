using NFine.EntityFramework.Entity.SystemManage;
using NFine.EntityFramework.Entity.WeixinManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFine.Repository.WeixinManage
{
    public class WxNewsRepository : ConfigurationBasedRepository<WxNews, long>
    {
        public WxNewsRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
