using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.EntityFramework.Entity.WeixinManage;

namespace NFineCore.EntityFramework.Map.SystemManage
{
    public class WxVideoMap : IEntityTypeConfiguration<WxVideo>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WxVideo> builder)
        {
            builder.ToTable("wx_video");

            //添加主键
            builder.HasKey(t => new { t.Id });

            //配置过滤器
            builder.HasQueryFilter(wxVideo => EF.Property<bool>(wxVideo, "DeletedMark") == false);
        }
    }
}
