﻿// <auto-generated />
using System;
using EmployeeManagement.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20200919042231_DbMigration")]
    partial class DbMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeManagement.DbEntities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("Dob")
                        .HasColumnName("DOB")
                        .HasColumnType("date");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("HobbyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnName("JoiningDate")
                        .HasColumnType("date");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SkillsName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HobbyId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagement.DbEntities.Hobbies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HobbyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Hobbies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HobbyName = "Playing Crikt"
                        },
                        new
                        {
                            Id = 2,
                            HobbyName = "Cooking"
                        },
                        new
                        {
                            Id = 3,
                            HobbyName = "Dancing"
                        });
                });

            modelBuilder.Entity("EmployeeManagement.DbEntities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Business Analyst"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Project Manager"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "Software Developer"
                        },
                        new
                        {
                            Id = 4,
                            RoleName = "Web Designer"
                        });
                });

            modelBuilder.Entity("EmployeeManagement.DbEntities.Skills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SkillsName = "HTML/CSS"
                        },
                        new
                        {
                            Id = 2,
                            SkillsName = "Dot Net"
                        },
                        new
                        {
                            Id = 3,
                            SkillsName = "Andriod"
                        },
                        new
                        {
                            Id = 4,
                            SkillsName = "iOS"
                        },
                        new
                        {
                            Id = 5,
                            SkillsName = "Java"
                        },
                        new
                        {
                            Id = 6,
                            SkillsName = "SQL"
                        },
                        new
                        {
                            Id = 7,
                            SkillsName = "AI"
                        },
                        new
                        {
                            Id = 8,
                            SkillsName = "ML"
                        },
                        new
                        {
                            Id = 9,
                            SkillsName = "XML"
                        },
                        new
                        {
                            Id = 10,
                            SkillsName = "Python"
                        },
                        new
                        {
                            Id = 11,
                            SkillsName = "JavaScript/jQuery"
                        });
                });

            modelBuilder.Entity("EmployeeManagement.DbEntities.Employee", b =>
                {
                    b.HasOne("EmployeeManagement.DbEntities.Hobbies", "Hobbies")
                        .WithMany("Employee")
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagement.DbEntities.Role", "Role")
                        .WithMany("Employee")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
