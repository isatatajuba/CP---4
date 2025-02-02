﻿// <auto-generated />
using Empresa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Empresa.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20240906235747_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Empresa.Models.Departamento", b =>
                {
                    b.Property<int>("IdDepartament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDepartament"));

                    b.Property<string>("NameDepartament")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdDepartament");

                    b.ToTable("Departamentos_PX");
                });

            modelBuilder.Entity("Empresa.Models.Empregado", b =>
                {
                    b.Property<int>("EmpregadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpregadoId"));

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("FotoUrl")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Genero")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdDepartament")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("EmpregadoId");

                    b.ToTable("Empregados_PX");
                });
#pragma warning restore 612, 618
        }
    }
}
