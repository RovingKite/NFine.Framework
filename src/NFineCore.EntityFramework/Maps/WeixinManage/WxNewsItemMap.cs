using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.EntityFramework.Models.WeixinManage;

namespace NFineCore.EntityFramework.Maps.SystemManage
{
    public class WxNewsItemMap : IEntityTypeConfiguration<WxNewsItem>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WxNewsItem> builder)
        {
            //配置实体对应数据库表明
            builder.ToTable("wx_newsitem");

            //添加主键
            builder.HasKey(t => new { t.Id });

            //配置单向一对一关系
            builder.HasOne(p => p.Thumb).WithMany().HasForeignKey(p => p.ThumbId);

            //配置过滤器
            builder.HasQueryFilter(wxNewsItem => EF.Property<bool>(wxNewsItem, "DeletedMark") == false);
        }
    }
}
