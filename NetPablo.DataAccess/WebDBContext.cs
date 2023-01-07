using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NetPablo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPablo.DataAccess
{
    public class WebDBContext : DbContext
    {

        public WebDBContext() { }

        /*Aca configuro la cadena de conexion a la db*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) 
        {
            optionBuilder.UseSqlServer("Server=DESKTOP-4NI55Q0;Database=WebTest;Uid=sa;Password=Passw0rd;Encrypt=false");
        }


        /*Aca seteo las propiedades de la base de datos*/
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Product>(entity => {

                entity.HasKey(x=>x.Id);
                entity.Property(x => x.Name).IsRequired().IsUnicode(true).HasMaxLength(150);
                entity.Property(x=>x.AlternativeName).IsUnicode(true).HasMaxLength(150);
                entity.Property(x => x.Status).IsRequired();
                entity.Property(x=>x.CreationDate).IsRequired();
                entity.Property(x=>x.Price).IsRequired().HasPrecision(2);
            
            });

            modelBuilder.Entity<Cart>(entity => {

                entity.HasKey(x=>x.lineId);
                entity.Property(x => x.idProduct).IsRequired();
                entity.Property(x=>x.quantity).IsRequired();
                entity.Property(x=>x.dateCreated).IsRequired();
                entity.Property(x=>x.idUser).IsRequired();
                entity.Property(x=>x.priceCalculated).IsRequired().HasPrecision(2);

            });


            //DATA SEEDING
            modelBuilder.Entity<Product>().HasData(
                new List<Product>() {
                    new Product { Id = 1, Name = "Telefono celular", CreationDate = DateTime.Now, AlternativeName = "Telefono Alcatel", Price = 50000, Status = true },
                    new Product { Id = 2, Name = "Zapatilla", CreationDate = DateTime.Now, AlternativeName = "Marca Naik", Price = 25000, Status = true },
                    new Product { Id = 3, Name = "Manzana", CreationDate = DateTime.Now, AlternativeName = "Fruta organica", Price = 150, Status = true },
                    new Product { Id = 4, Name = "Chaleco", CreationDate = DateTime.Now, AlternativeName = "Chaleco de lana", Price = 35000, Status = true },
                    new Product { Id = 5, Name = "Mouse Inalambrico", CreationDate = DateTime.Now, AlternativeName = "Mouse con bluetooth", Price = 15000, Status = true }
                }

                );
        }

    }
}
