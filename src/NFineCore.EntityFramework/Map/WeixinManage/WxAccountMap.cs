﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.EntityFramework.Entity.WeixinManage;

namespace NFineCore.EntityFramework.Map.SystemManage
{
    public class WxAccountMap : IEntityTypeConfiguration<WxAccount>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WxAccount> builder)
        {
            builder.ToTable("wx_account");

            //添加主键
            builder.HasKey(t => new { t.Id });

            //配置过滤器
            builder.HasQueryFilter(wxOfficial => EF.Property<bool>(wxOfficial, "DeletedMark") == false);
        }
    }
}