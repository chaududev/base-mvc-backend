
using Domain.Cloth;
using Domain.Customers;
using Domain.Invoices;
using Domain.Laundries;
using Domain.LaundryInvoices;
using Domain.Staffs;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure
{
    public class MyDbContext : DbContext
    {

        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<DetailInvoice> DetailInvoices { get; set; }

        public DbSet<DetailInvoiceLaundry> DetailInvoiceLaundries { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Laundry> Laundries { get; set; }

        public DbSet<LaundryInvoice> LaundryInvoices { get; set; }

        public DbSet<Origin> Origins { get; set; }

        public DbSet<RoleStaff> RoleStaffs { get; set; }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<TypeClothes> TypeClothes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);
            modelBuilder.Entity("Domain.Cloth.Clothes", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Description")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<int>("OriginId")
                    .HasColumnType("int");

                b.Property<decimal>("Price")
                    .HasColumnType("decimal(18,2)");

                b.Property<int>("RentalPrice")
                    .HasColumnType("int");

                b.Property<int>("RentalTime")
                    .HasColumnType("int");

                b.Property<Size>("Size")
                    .HasColumnType("int");

                b.Property<Status>("Status")
                    .HasColumnType("int");

                b.Property<int>("TypeClothesId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("OriginId");

                b.HasIndex("TypeClothesId");

                b.ToTable("Clothes");
            });

            modelBuilder.Entity("Domain.Cloth.Origin", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Address")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.HasKey("Id");

                b.ToTable("Origin");
            });

            modelBuilder.Entity("Domain.Cloth.TypeClothes", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<int>("Limit")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.HasKey("Id");

                b.ToTable("TypeClothes");
            });

            modelBuilder.Entity("Domain.Customers.Customer", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Address")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("FullName")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Phone")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.HasKey("Id");

                b.ToTable("Customer");

            });

            modelBuilder.Entity("Domain.Invoices.DetailInvoice", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<int>("ClothesId")
                    .HasColumnType("int");

                b.Property<int>("InvoiceId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("DetailInvoice");

            });

            modelBuilder.Entity("Domain.Invoices.Invoice", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<int>("CustomerId")
                    .HasColumnType("int");

                b.Property<DateTime>("Date")
                    .HasColumnType("datetime2");

                b.Property<int>("Discount")
                    .HasColumnType("int");

                b.Property<int>("StaffId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Invoice");

            });

            modelBuilder.Entity("Domain.Laundries.Laundry", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Address")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Phone")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<int>("Rate")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Laundry");

            });

            modelBuilder.Entity("Domain.LaundryInvoices.DetailInvoiceLaundry", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<int>("ClothesId")
                    .HasColumnType("int");

                b.Property<int>("LaundryInvoiceId")
                    .HasColumnType("int");

                b.Property<decimal>("Price")
                    .HasColumnType("decimal(18,2)");

                b.HasKey("Id");

                b.ToTable("DetailInvoiceLaundry");

            });

            modelBuilder.Entity("Domain.LaundryInvoices.LaundryInvoice", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<DateTime>("Date")
                    .HasColumnType("datetime2");

                b.Property<int>("LaundryId")
                    .HasColumnType("int");

                b.Property<int>("StaffId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("LaundryInvoice");

            });

            modelBuilder.Entity("Domain.Staffs.RoleStaff", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.HasKey("Id");

                b.ToTable("RoleStaff");

            });

            modelBuilder.Entity("Domain.Staffs.Staff", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Address")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<DateTime>("Birthday")
                    .HasColumnType("datetime2");

                b.Property<string>("CitizenCode")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("FullName")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Phone")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<int>("RoleId")
                    .HasColumnType("int");

                b.Property<string>("Email")
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnType("nvarchar(50)");

                b.Property<string>("Password")
                 .IsRequired()
                 .HasMaxLength(50)
                 .HasColumnType("nvarchar(50)");

                b.Property<DateTime>("CreatedDate")
                  .HasColumnType("datetime2");
                b.HasKey("Id");

                b.ToTable("Staff");

            });
            //Configure One to Many

            modelBuilder.Entity("Domain.Cloth.Clothes", b =>
            {
                b.HasOne("Domain.Cloth.Origin", "Origin")
                    .WithMany("Clothes")
                    .HasForeignKey("OriginId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Domain.Cloth.TypeClothes", "TypeClothes")
                    .WithMany("Clothes")
                    .HasForeignKey("TypeClothesId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Origin");

                b.Navigation("TypeClothes");
            });

            modelBuilder.Entity("Domain.Invoices.DetailInvoice", b =>
            {
                b.HasOne("Domain.Cloth.Clothes", "Cloth")
                    .WithMany("DetailInvoices")
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Domain.Invoices.Invoice", "Invoice")
                    .WithMany("DetailInvoices")
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Cloth");

                b.Navigation("Invoice");
            });

            modelBuilder.Entity("Domain.Invoices.Invoice", b =>
            {
                b.HasOne("Domain.Customers.Customer", "Customer")
                    .WithMany("Invoices")
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Domain.Staffs.Staff", "Staff")
                    .WithMany("Invoices")
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Customer");

                b.Navigation("Staff");
            });

            modelBuilder.Entity("Domain.LaundryInvoices.DetailInvoiceLaundry", b =>
            {
                b.HasOne("Domain.Cloth.Clothes", "Cloth")
                    .WithMany("DetailInvoiceLaundries")
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Domain.LaundryInvoices.LaundryInvoice", "LaundryInvoice")
                    .WithMany("DetailInvoiceLaundries")
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Cloth");

                b.Navigation("LaundryInvoice");
            });

            modelBuilder.Entity("Domain.LaundryInvoices.LaundryInvoice", b =>
            {
                b.HasOne("Domain.Laundries.Laundry", "Laundry")
                    .WithMany("LaundryInvoices")
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Domain.Staffs.Staff", "Staff")
                    .WithMany("LaundryInvoices")
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Laundry");

                b.Navigation("Staff");
            });

            modelBuilder.Entity("Domain.Staffs.Staff", b =>
            {
                b.HasOne("Domain.Staffs.RoleStaff", "RoleStaff")
                    .WithMany("Staffs")
                    .HasForeignKey("Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("RoleStaff");
            });

            modelBuilder.Entity("Domain.Cloth.Clothes", b =>
            {
                b.Navigation("DetailInvoiceLaundries");

                b.Navigation("DetailInvoices");
            });

            modelBuilder.Entity("Domain.Cloth.Origin", b =>
            {
                b.Navigation("Clothes");
            });

            modelBuilder.Entity("Domain.Cloth.TypeClothes", b =>
            {
                b.Navigation("Clothes");
            });

            modelBuilder.Entity("Domain.Customers.Customer", b =>
            {
                b.Navigation("Invoices");
            });

            modelBuilder.Entity("Domain.Invoices.Invoice", b =>
            {
                b.Navigation("DetailInvoices");
            });

            modelBuilder.Entity("Domain.Laundries.Laundry", b =>
            {
                b.Navigation("LaundryInvoices");
            });

            modelBuilder.Entity("Domain.LaundryInvoices.LaundryInvoice", b =>
            {
                b.Navigation("DetailInvoiceLaundries");
            });

            modelBuilder.Entity("Domain.Staffs.RoleStaff", b =>
            {
                b.Navigation("Staffs");
            });

            modelBuilder.Entity("Domain.Staffs.Staff", b =>
            {
                b.Navigation("Invoices");

                b.Navigation("LaundryInvoices");
            });
            
            //data seeding
            modelBuilder.Entity<Clothes>().HasData(
                new { Id =1, Name = "Váy công sở Zara", Description = "Màu trắng", Size = Size.Large, Price = 89.99m, RentalTime = 0, RentalPrice = 200000, TypeClothesId = 1, OriginId = 1, Status = Status.Available },
                new { Id=2, Name = "Áo công sở Uniqlo", Description = "Màu đen", Size = Size.Medium, Price = 58.99m, RentalTime = 0, RentalPrice = 100000, TypeClothesId = 2, OriginId = 2, Status = Status.Available }
                );
            modelBuilder.Entity<TypeClothes>().HasData(
                new { Id=1, Name = "Váy", Limit = 15 },
                new { Id=2, Name = "Áo", Limit = 20 }
                );
            modelBuilder.Entity<Origin>().HasData(
                new { Id = 1, Name = "Zara", Address = "Korea" },
                new { Id = 2, Name = "Uniqlo", Address = "Japan" }
                );
            modelBuilder.Entity<Customer>().HasData(
                new { Id = 1, FullName = "Chau Hoang Bich Du", Phone="0943357474", Address="32 Nguyen Hue Str, Hue" },
                new { Id = 2, FullName = "Chau Chi Khanh", Phone = "0935727272", Address = "42 Nguyen Hue Str, Ha Noi" }
                );
            modelBuilder.Entity<DetailInvoice>().HasData(
                new { Id = 1, InvoiceId=1, ClothesId=1,Quantity=1},
                new { Id = 2, InvoiceId = 1, ClothesId = 2, Quantity = 1 }
                );
            modelBuilder.Entity<Invoice>().HasData(
               new { Id = 1, Date = new DateTime(2023, 2, 1),CustomerId=1,StaffId=1,Discount=0}
               );
            modelBuilder.Entity<Laundry>().HasData(
                new { Id = 1, Name = "O Ti", Phone = "0943357373", Address = "56 Nguyen Hue Str, Hue",Rate=3 },
                new { Id = 2, Name = "O Mi", Phone = "0935727276", Address = "42 Hai Ba Trung Str, Hue",Rate=4 }
                );
            modelBuilder.Entity<DetailInvoiceLaundry>().HasData(
                new { Id = 1, LaundryInvoiceId = 1, ClothesId = 1, Quantity = 1, Price = 1.00m },
                new { Id = 2, LaundryInvoiceId = 1, ClothesId = 2, Quantity = 1, Price = 0.99m }
                );
            modelBuilder.Entity<LaundryInvoice>().HasData(
               new { Id = 1, Date = new DateTime(2023, 2, 3), LaundryId = 2, StaffId = 1 }
               );
            modelBuilder.Entity<RoleStaff>().HasData(
               new { Id = 1, Name="Admin" },
               new { Id = 2, Name = "Accountant" }
               );
            modelBuilder.Entity<Staff>().HasData(
               new { Id = 1, CitizenCode="04321842241", FullName = "Nguyen Thi Kim Tuyen",Birthday= new DateTime(2001, 2, 1), Phone = "0943357323", Address = "5/6 Nguyen Cong Tru Str, Hue", RoleId = 1, Email = "admin@abc.com", Password = "SS1JiBmooIzUmIjlbQEUet0eMI/KvUUX5j9E/Qk/Bf8=", CreatedDate = new DateTime(2022, 1, 17) },
               new { Id = 2, CitizenCode = "04242144124", FullName = "Nguyen Van Tai", Birthday = new DateTime(1989, 2, 1), Phone = "0943357329", Address = "5/10 Nguyen Hue Str, Hue", RoleId = 2, Email = "tai@gmail.com", Password = "SS1JiBmooIzUmIjlbQEUet0eMI/KvUUX5j9E/Qk/Bf8=", CreatedDate = new DateTime(2023, 1, 1) }
               );
            //pass="admin@2022"
        }

        private const string connectionString = @"Server=DESKTOP-FF1278R;Database=ClothesShop;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
