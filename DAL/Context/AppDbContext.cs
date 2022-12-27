using ENTITIES.Entity.Concrete;
using MAP.EntityTypeConfiguration.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //.Net'te burada connection strinfg ifademizi yazıyorduk. Artık burada connection string yazılmayacak.

            // Asp.Net Core bizleri DI uygulamaya zorlamaktadır. Burada da bunu yapıyoruz. AppDbContext uygulama içeride herhangi bir yerde inject edildiğinde kullanıma hazırlanırken Statrup.cs sınıfındaki options yani özellikleri çağırarak "base" yani "DbContext.cs" sınıfına ilerlemektedir.

            //Core'da farklı veri tabanları ile çalışabilme imkanımız olduğundan burada bir esneklik temin edilmiştir. Artık connection string appsetting.json dosyasından startup.cs içerisindeki register edilmiş AppDbContext.cs tarafından çağrılacak ve işleme tabi olacaktır.

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;Database=ArchitecturalDb;Trusted_Connection=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.Entity<Article>().HasOne(a => a.Author).WithMany(u => u.Articles).HasForeignKey(u => u.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles{ get; set; }
    }
}
