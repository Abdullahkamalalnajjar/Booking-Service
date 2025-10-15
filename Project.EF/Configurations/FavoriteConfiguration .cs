using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.EF.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<UserFavorite>
    {
        public void Configure(EntityTypeBuilder<UserFavorite> builder)
        
        {
            builder.ToTable("Favorites"); // ✅ اسم الجدول واضح ومحدد
            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.User)
                   .WithMany(u => u.favorites)
                   .HasForeignKey(f => f.UserId)
                   .OnDelete(DeleteBehavior.Restrict); // لتجنب multiple cascade paths

            builder.HasOne(f => f.Service)
                   .WithMany(s => s.favorites)
                   .HasForeignKey(f => f.ServiceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
    }


