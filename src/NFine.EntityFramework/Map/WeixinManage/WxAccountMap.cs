using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.EntityFramework.Entity.WeixinManage;

namespace NFine.EntityFramework.Map.SystemManage
{
    public class WxAccountMap : IEntityTypeConfiguration<WxAccount>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WxAccount> builder)
        {
            builder.ToTable("wx_account");

            //添加主键
            builder.HasKey(t => new { t.Id });

            //配置过滤器
            builder.HasQueryFilter(wxOfficial => EF.Property<bool>(wxOfficial, "DeletedMark") == false);
        }
    }
}
