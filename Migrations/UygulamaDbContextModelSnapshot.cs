﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hastanerandevu.Utility;

#nullable disable

namespace hastanerandevu.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    partial class UygulamaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("hastanerandevu.Models.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DoktorAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorMesai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poliklinik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("doktorBransId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("doktorBransId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("hastanerandevu.Models.DoktorBrans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("DoktorBranslari");
                });

            modelBuilder.Entity("hastanerandevu.Models.Randevu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("HastaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("hastanerandevu.Models.Doktor", b =>
                {
                    b.HasOne("hastanerandevu.Models.DoktorBrans", "DoktorBrans")
                        .WithMany()
                        .HasForeignKey("doktorBransId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoktorBrans");
                });

            modelBuilder.Entity("hastanerandevu.Models.Randevu", b =>
                {
                    b.HasOne("hastanerandevu.Models.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");
                });
#pragma warning restore 612, 618
        }
    }
}
