using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.EntityFramework.Entity.WeixinManage;

namespace NFineCore.EntityFramework.Map.SystemManage
{
    public class WxNewsMap : IEntityTypeConfiguration<WxNews>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WxNews> builder)
        {
            builder.ToTable("wx_news");

            //添加主键
            builder.HasKey(t => new { t.Id });

            //配置一对多关系
            builder.HasMany(p => p.WxNewsItems)
                                  .WithOne(p => p.WxNews)
                                  .HasForeignKey(p => p.NewsId);

            //配置过滤器
            builder.HasQueryFilter(wxNews => EF.Property<bool>(wxNews, "DeletedMark") == false);

        }
    }
}
