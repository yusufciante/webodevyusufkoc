﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hastanerandevu.Utility;

#nullable disable

namespace hastanerandevu.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    [Migration("20231231175242_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("hastanerandevu.Models.Doktor", b =>
                {
                    b.HasOne("hastanerandevu.Models.DoktorBrans", "DoktorBrans")
                        .WithMany()
                        .HasForeignKey("doktorBransId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoktorBrans");
                });
#pragma warning restore 612, 618
        }
    }
}