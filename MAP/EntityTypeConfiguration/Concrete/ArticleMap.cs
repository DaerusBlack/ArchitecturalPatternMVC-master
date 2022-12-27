using ENTITIES.Entity.Concrete;
using MAP.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.EntityTypeConfiguration.Concrete
{
    public class ArticleMap:BaseMap<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Content).HasMaxLength(500).IsRequired(true);
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired(true);
            base.Configure(builder);
        }
    }
}
