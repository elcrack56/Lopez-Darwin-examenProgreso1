﻿// <auto-generated />
using System;
using Lopez_Darwin_examenProgreso1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lopez_Darwin_examenProgreso1.Migrations
{
    [DbContext(typeof(Lopez_Darwin_examenProgreso1Context))]
    partial class Lopez_Darwin_examenProgreso1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lopez_Darwin_examenProgreso1.Models.Celular", b =>
                {
                    b.Property<string>("modelo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("año")
                        .HasColumnType("int");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.HasKey("modelo");

                    b.ToTable("Celular");
                });

            modelBuilder.Entity("Lopez_Darwin_examenProgreso1.Models.Lopez", b =>
                {
                    b.Property<string>("nombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("EsEcuatoriano")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("celularesmodelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<decimal>("estatura")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("nombre");

                    b.HasIndex("celularesmodelo");

                    b.ToTable("Lopez");
                });

            modelBuilder.Entity("Lopez_Darwin_examenProgreso1.Models.Lopez", b =>
                {
                    b.HasOne("Lopez_Darwin_examenProgreso1.Models.Celular", "celulares")
                        .WithMany()
                        .HasForeignKey("celularesmodelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("celulares");
                });
#pragma warning restore 612, 618
        }
    }
}