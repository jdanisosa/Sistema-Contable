﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_Contable.DB;

#nullable disable

namespace Sistema_Contable.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221025055056_PrimeraMigracion")]
    partial class PrimeraMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Sistema_Contable.Models.Clasificacion_Grupo", b =>
                {
                    b.Property<int>("Id_Clasificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Clasificacion"), 1L, 1);

                    b.Property<int>("Id_Grupo_Contable")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Clasificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Clasificacion");

                    b.HasIndex("Id_Grupo_Contable");

                    b.ToTable("Clasificacion_Grupos");
                });

            modelBuilder.Entity("Sistema_Contable.Models.Cuenta", b =>
                {
                    b.Property<int>("Id_Cuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Cuenta"), 1L, 1);

                    b.Property<string>("Codigo_Cuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_Clasificacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Cuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Saldo_Actual")
                        .HasColumnType("real");

                    b.HasKey("Id_Cuenta");

                    b.HasIndex("Id_Clasificacion");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("Sistema_Contable.Models.Detalle_Partida_Diario", b =>
                {
                    b.Property<int>("Id_Cuenta")
                        .HasColumnType("int");

                    b.Property<int>("Id_Partida")
                        .HasColumnType("int");

                    b.Property<float>("Debe")
                        .HasColumnType("real");

                    b.Property<float>("Haber")
                        .HasColumnType("real");

                    b.Property<float>("Saldo")
                        .HasColumnType("real");

                    b.HasKey("Id_Cuenta", "Id_Partida");

                    b.HasIndex("Id_Partida");

                    b.ToTable("Detalle_Partida_Diarios");
                });

            modelBuilder.Entity("Sistema_Contable.Models.Grupo_Contable", b =>
                {
                    b.Property<int>("Id_Grupo_Contable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Grupo_Contable"), 1L, 1);

                    b.Property<string>("Nombre_Grupo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Grupo_Contable");

                    b.ToTable("Grupo_Contables");
                });

            modelBuilder.Entity("Sistema_Contable.Models.Partida_Diario", b =>
                {
                    b.Property<int>("Id_Partida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Partida"), 1L, 1);

                    b.Property<string>("Correlativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Numero_Documento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Partida");

                    b.ToTable("Partida_Diarios");
                });

            modelBuilder.Entity("Sistema_Contable.Models.Clasificacion_Grupo", b =>
                {
                    b.HasOne("Sistema_Contable.Models.Grupo_Contable", "Grupo_Contable")
                        .WithMany()
                        .HasForeignKey("Id_Grupo_Contable")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo_Contable");
                });

            modelBuilder.Entity("Sistema_Contable.Models.Cuenta", b =>
                {
                    b.HasOne("Sistema_Contable.Models.Clasificacion_Grupo", "Clasificacion_Grupo")
                        .WithMany()
                        .HasForeignKey("Id_Clasificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clasificacion_Grupo");
                });

            modelBuilder.Entity("Sistema_Contable.Models.Detalle_Partida_Diario", b =>
                {
                    b.HasOne("Sistema_Contable.Models.Cuenta", "Cuenta")
                        .WithMany()
                        .HasForeignKey("Id_Cuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Contable.Models.Partida_Diario", "Partida_Diario")
                        .WithMany()
                        .HasForeignKey("Id_Partida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");

                    b.Navigation("Partida_Diario");
                });
#pragma warning restore 612, 618
        }
    }
}
