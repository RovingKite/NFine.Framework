using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.EntityFramework.Entity.WeixinManage;

namespace NFine.EntityFramework.Map.SystemManage
{
    public class WxTextMap : IEntityTypeConfiguration<WxText>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WxText> builder)
        {
            builder.ToTable("wx_text");

            //添加主键
            builder.HasKey(t => new { t.Id });

            //配置过滤器
            builder.HasQueryFilter(wxText => EF.Property<bool>(wxText, "DeletedMark") == false);
        }
    }
}
