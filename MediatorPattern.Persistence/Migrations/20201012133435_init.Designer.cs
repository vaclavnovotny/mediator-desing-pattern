﻿// <auto-generated />
using MediatorPattern.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MediatorPattern.Persistence.Migrations
{
    [DbContext(typeof(ElementsContext))]
    [Migration("20201012133435_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MediatorPattern.Domain.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("MediatorPattern.Domain.Element", b =>
                {
                    b.OwnsOne("MediatorPattern.Domain.Position", "Position", b1 =>
                        {
                            b1.Property<int>("ElementId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<double>("X")
                                .HasColumnType("float");

                            b1.Property<double>("Y")
                                .HasColumnType("float");

                            b1.Property<double>("Z")
                                .HasColumnType("float");

                            b1.HasKey("ElementId");

                            b1.ToTable("Elements");

                            b1.WithOwner()
                                .HasForeignKey("ElementId");
                        });

                    b.OwnsOne("MediatorPattern.Domain.Size", "Size", b1 =>
                        {
                            b1.Property<int>("ElementId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<double>("Height")
                                .HasColumnType("float");

                            b1.Property<double>("Width")
                                .HasColumnType("float");

                            b1.HasKey("ElementId");

                            b1.ToTable("Elements");

                            b1.WithOwner()
                                .HasForeignKey("ElementId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
