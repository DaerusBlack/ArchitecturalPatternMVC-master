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
    public class UserMap:BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Username).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(10).IsRequired();

          // builder.HasData(new User { Username = "bayzin", Password = "1234",Id = 1 });

            base.Configure(builder);
        }
    }
}
