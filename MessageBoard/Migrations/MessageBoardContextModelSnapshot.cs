﻿// <auto-generated />
using System;
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageBoard.Migrations
{
    [DbContext(typeof(MessageBoardContext))]
    partial class MessageBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MessageBoard.Models.Board", b =>
                {
                    b.Property<int>("BoardId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("BoardId");

                    b.ToTable("Boards");

                    b.HasData(
                        new
                        {
                            BoardId = 1,
                            Description = "General discussions about computer programming i.e., best prectices, tips-and-trick, etc...",
                            Name = "Programming"
                        },
                        new
                        {
                            BoardId = 2,
                            Description = "A place where we can share cute things our pets have done",
                            Name = "Pets"
                        },
                        new
                        {
                            BoardId = 3,
                            Description = "Trading nutrition tips, recipes, and support",
                            Name = "Diet/Nutrition"
                        },
                        new
                        {
                            BoardId = 4,
                            Description = "A friendly chat about what video games we are playing these days",
                            Name = "Video Games"
                        },
                        new
                        {
                            BoardId = 5,
                            Description = "Best places to eat around Portland",
                            Name = "Eats!"
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<DateTime>("DatePosted");

                    b.Property<string>("Heading")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("MessageId");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MessageBoard.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoardId");

                    b.Property<DateTime>("DatePosted");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("PostId");

                    b.HasIndex("BoardId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MessageBoard.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("Token");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Admin",
                            LastName = "User",
                            Password = "noel",
                            Role = "Admin",
                            Username = "noel"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Admin",
                            LastName = "User",
                            Password = "spencer",
                            Role = "Admin",
                            Username = "spencer"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Admin",
                            LastName = "User",
                            Password = "christine",
                            Role = "Admin",
                            Username = "christine"
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.HasOne("MessageBoard.Models.Post")
                        .WithMany("Messages")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MessageBoard.Models.Post", b =>
                {
                    b.HasOne("MessageBoard.Models.Board")
                        .WithMany("Posts")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
