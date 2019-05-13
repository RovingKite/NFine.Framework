using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.EntityFramework.Entity.WeixinManage;

namespace NFine.EntityFramework.Map.SystemManage
{
    public class WxImageMap : IEntityTypeConfiguration<WxImage>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WxImage> builder)
        {
            builder.ToTable("wx_image");

            //添加主键
            builder.HasKey(t => new { t.Id });

            //配置过滤器
            builder.HasQueryFilter(wxImage => EF.Property<bool>(wxImage, "DeletedMark") == false);
        }
    }
}
