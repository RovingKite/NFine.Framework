using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.EntityFramework.Models.WeixinManage;

namespace NFineCore.EntityFramework.Maps.SystemManage
{
    public class WxMenuMap : IEntityTypeConfiguration<WxMenu>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WxMenu> builder)
        {
            builder.ToTable("wx_menu");

            //添加主键
            builder.HasKey(t => new { t.Id });

            //配置过滤器
            builder.HasQueryFilter(wxNews => EF.Property<bool>(wxNews, "DeletedMark") == false);

        }
    }
}
