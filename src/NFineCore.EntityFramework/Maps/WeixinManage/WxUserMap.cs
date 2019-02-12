using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.EntityFramework.Models.WeixinManage;

namespace NFineCore.EntityFramework.Maps.SystemManage
{
    public class WxUserMap : IEntityTypeConfiguration<WxUser>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WxUser> builder)
        {
            builder.ToTable("wx_user");

            //添加主键
            builder.HasKey(t => new { t.Id });

            //配置过滤器
            //builder.HasQueryFilter(wxUser => EF.Property<bool>(wxUser, "DeletedMark") == false);
        }
    }
}
