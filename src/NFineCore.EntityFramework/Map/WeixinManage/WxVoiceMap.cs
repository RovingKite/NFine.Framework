using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.EntityFramework.Entity.WeixinManage;

namespace NFineCore.EntityFramework.Map.SystemManage
{
    public class WxVoiceMap : IEntityTypeConfiguration<WxVoice>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WxVoice> builder)
        {
            builder.ToTable("wx_voice");

            //添加主键
            builder.HasKey(t => new { t.Id });

            //配置过滤器
            builder.HasQueryFilter(wxVoice => EF.Property<bool>(wxVoice, "DeletedMark") == false);
        }
    }
}
