﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.EntityFramework.Entity.WeixinManage;

namespace NFine.EntityFramework.Map.SystemManage
{
    public class WxNewsMap : IEntityTypeConfiguration<WxNews>
    {
        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<WxNews> builder)
        {
            builder.ToTable("wx_news");

            //添加主键
            builder.HasKey(t => new { t.Id });

            //配置一对多关系
            builder.HasMany(p => p.WxNewsItems)
                                  .WithOne(p => p.WxNews)
                                  .HasForeignKey(p => p.NewsId);

            //配置过滤器
            builder.HasQueryFilter(wxNews => EF.Property<bool>(wxNews, "DeletedMark") == false);

        }
    }
}
