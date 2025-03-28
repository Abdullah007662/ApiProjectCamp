using ApiProjectCamp.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectCamp.WebApi.Context
{
    public class ApiContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Burada Sql Serverda Oluşturacağımız Database'nin İsmini ve Erişim İçin Sertifika İzni Veriyoruz.
            optionsBuilder.UseSqlServer("server=DESKTOP-KI81GQD;database=ApiYummyDb;integrated security= true;Trust server certificate=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
