using NFine.EntityFramework.Entity.SystemManage;
using NFine.EntityFramework.Entity.WeixinManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFine.Repository.WeixinManage
{
    public class WxTextRepository : ConfigurationBasedRepository<WxText, long>
    {
        public WxTextRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}
