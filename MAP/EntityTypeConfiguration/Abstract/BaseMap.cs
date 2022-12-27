using ENTITIES.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.EntityTypeConfiguration.Abstract
{
    //IEntityTypeConfiguration.cs arayüzünü bize temin edecek yapı EF Core'dur.
    //EntityFramework Core'u bu adımda yükleyebiliriz. Lakin Ef Core, bu projede kullanacağımız veri tabanının içeriisnde de bulunmaktadır. Bu yüzden birden fazla paket indirmemek için biz direk çalışağımız veri tabanının paketinin indireceğiz. Böylelikle içerisinde Ef Core'da gelecektir.
    // Microsoft.EntityFrameworkCore.SqlServer paketini indirdiğinizde EF Core, sizin yüklediğiniz sqlserver sürüüyle stabil oplan versiyonu otomatik olarak indirir. Biz bu projede SQL ile çalıcağımız için sqlserver'ı indirmiş bulunduk.

    //ASP.Net Core'da hep Interface'leri çağıracağız.
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        //Asp.Net projelerinde bu configuration işlemini constructor method içerisinde yapıyorduk.   Burada sınıfımızız IEntityTypeConfiguration.cs arayüzünden kalıtım aldığından aşağıdaki methodu implement etmek ve BaseEntity.cs sınfının configuration ayarlarını yapmak zorundayız.
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id); //Buradan yapıcağınız değişiklikler, dataAnootations ile yaptıklarınızı ezer!
            builder.Property(x => x.CreateDate).IsRequired(true);
        }
    }
}
