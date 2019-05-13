using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.EntityFramework.Entity.WeixinManage;

namespace NFine.EntityFramework.Map.SystemManage
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
