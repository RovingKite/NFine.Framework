using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.EntityFramework.Entity.WeixinManage;

namespace NFine.EntityFramework.Map.SystemManage
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
