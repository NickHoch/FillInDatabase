using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSiteCore.DAL.Entities.SqlViews;

namespace WebSiteCore.DAL.Entities
{
    public class EFDbContext : DbContext
    {
        //public virtual DbSet<Client> Clients { get; set; }
        //public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<ConvenienceType> ConvenienceTypes { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<BoardType> BoardTypes { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<ApartmentImage> ApartmentImages { get; set; }

        public virtual DbQuery<VApartmentData> VApartmentsData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\v11.0;Database=testHotel;Trusted_Connection=True;");
        }
    }
}
