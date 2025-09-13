
namespace Project.EF.Configurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {

            // Seed Data
            builder.HasData(
                [
                new Service { Id = 1, Name = "الفساتين", ImageUrl = "https://ar.lunss.com/collection/pretty-simple-evening-formal-dresses-2519.html" },
                new Service { Id = 2, Name = "القاعات", ImageUrl = "https://imagesawe.s3.amazonaws.com/styles/max980/s3/listing/2019/03/14/the_westin_cairo_golf_resort_spa.jpg?itok=TQJVM7S0" },
                new Service { Id = 3, Name = "الكوشات", ImageUrl = "https://static.sayidaty.net/styles/900_scale/public/2018/09/22/4174871-220791780.jpg.webp" },
                new Service { Id = 4, Name = "الشاليهات", ImageUrl = "https://trymyroom.com/Files/Blogs/800x600_6223059c-8175-4433-9f11-0329230edf23.webp" },
                new Service { Id = 5, Name = "الفنادق", ImageUrl = "https://ibsacademy.org/U/c/c-img-221.jpg" }
                ]
            );
        }
    }
}
