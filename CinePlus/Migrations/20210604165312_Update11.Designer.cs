﻿// <auto-generated />
using System;
using CinePlus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CinePlus.Migrations
{
    [DbContext(typeof(CinePlusDBContext))]
    [Migration("20210604165312_Update11")]
    partial class Update11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CinePlus.Models.ArmChair", b =>
                {
                    b.Property<string>("ArmChairId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateArmChair")
                        .HasColumnType("int");

                    b.HasKey("ArmChairId");

                    b.ToTable("ArmChair");
                });

            modelBuilder.Entity("CinePlus.Models.ArmChairByRoom", b =>
                {
                    b.Property<string>("ArmChairByRoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ArmChairId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ArmChairByRoomId");

                    b.HasIndex("ArmChairId");

                    b.HasIndex("RoomId");

                    b.ToTable("ArmChairByRoom");
                });

            modelBuilder.Entity("CinePlus.Models.Cart", b =>
                {
                    b.Property<string>("CartId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ArmChairId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiscountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShowId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CartId");

                    b.HasIndex("ArmChairId");

                    b.HasIndex("ShowId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("CinePlus.Models.Discount", b =>
                {
                    b.Property<string>("DiscountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Percent")
                        .HasColumnType("real");

                    b.HasKey("DiscountId");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("CinePlus.Models.DiscountsByShow", b =>
                {
                    b.Property<string>("DiscountsByShowId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiscountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ShowId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DiscountsByShowId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("ShowId");

                    b.ToTable("DiscountsByShow");
                });

            modelBuilder.Entity("CinePlus.Models.Movie", b =>
                {
                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateUpload")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.HasIndex("MovieTypeId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("CinePlus.Models.MovieOnTop10", b =>
                {
                    b.Property<string>("MovieOnTop10Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Top10Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MovieOnTop10Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("Top10Id");

                    b.ToTable("MovieOnTop10");
                });

            modelBuilder.Entity("CinePlus.Models.MovieType", b =>
                {
                    b.Property<string>("MovieTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieTypeId");

                    b.ToTable("MovieType");
                });

            modelBuilder.Entity("CinePlus.Models.Partner", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Points")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Partner");
                });

            modelBuilder.Entity("CinePlus.Models.Pay", b =>
                {
                    b.Property<string>("PayId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiscountById")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayCartId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserBoughtArmChairId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserBougthArmChairId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PayId");

                    b.HasIndex("PayCartId");

                    b.HasIndex("UserBoughtArmChairId");

                    b.ToTable("Pay");
                });

            modelBuilder.Entity("CinePlus.Models.PayCart", b =>
                {
                    b.Property<string>("PayCartId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CardHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Payed")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PayCartId");

                    b.HasIndex("UserId");

                    b.ToTable("PayCart");
                });

            modelBuilder.Entity("CinePlus.Models.Room", b =>
                {
                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoArmChairs")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("CinePlus.Models.Show", b =>
                {
                    b.Property<string>("ShowId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("PriceInPoints")
                        .HasColumnType("bigint");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ShowId");

                    b.HasIndex("MovieId");

                    b.HasIndex("RoomId");

                    b.ToTable("Show");
                });

            modelBuilder.Entity("CinePlus.Models.Top10", b =>
                {
                    b.Property<string>("Top10Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Top10Id");

                    b.ToTable("Top10");
                });

            modelBuilder.Entity("CinePlus.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CinePlus.Models.UserBoughtArmChair", b =>
                {
                    b.Property<string>("UserBoughtArmChairId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ArmChairByRoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ShowId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserBoughtArmChairId");

                    b.HasIndex("ArmChairByRoomId");

                    b.HasIndex("ShowId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBoughtArmChair");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CinePlus.Models.ArmChairByRoom", b =>
                {
                    b.HasOne("CinePlus.Models.ArmChair", "ArmChair")
                        .WithMany()
                        .HasForeignKey("ArmChairId");

                    b.HasOne("CinePlus.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("CinePlus.Models.Cart", b =>
                {
                    b.HasOne("CinePlus.Models.ArmChair", "ArmChair")
                        .WithMany()
                        .HasForeignKey("ArmChairId");

                    b.HasOne("CinePlus.Models.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowId");

                    b.HasOne("CinePlus.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CinePlus.Models.DiscountsByShow", b =>
                {
                    b.HasOne("CinePlus.Models.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId");

                    b.HasOne("CinePlus.Models.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowId");
                });

            modelBuilder.Entity("CinePlus.Models.Movie", b =>
                {
                    b.HasOne("CinePlus.Models.MovieType", "MovieType")
                        .WithMany()
                        .HasForeignKey("MovieTypeId");
                });

            modelBuilder.Entity("CinePlus.Models.MovieOnTop10", b =>
                {
                    b.HasOne("CinePlus.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("CinePlus.Models.Top10", "Top10")
                        .WithMany()
                        .HasForeignKey("Top10Id");
                });

            modelBuilder.Entity("CinePlus.Models.Partner", b =>
                {
                    b.HasOne("CinePlus.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CinePlus.Models.Pay", b =>
                {
                    b.HasOne("CinePlus.Models.PayCart", "PayCart")
                        .WithMany()
                        .HasForeignKey("PayCartId");

                    b.HasOne("CinePlus.Models.UserBoughtArmChair", "UserBoughtArmChair")
                        .WithMany()
                        .HasForeignKey("UserBoughtArmChairId");
                });

            modelBuilder.Entity("CinePlus.Models.PayCart", b =>
                {
                    b.HasOne("CinePlus.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CinePlus.Models.Show", b =>
                {
                    b.HasOne("CinePlus.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("CinePlus.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("CinePlus.Models.UserBoughtArmChair", b =>
                {
                    b.HasOne("CinePlus.Models.ArmChairByRoom", "ArmChairByRoom")
                        .WithMany()
                        .HasForeignKey("ArmChairByRoomId");

                    b.HasOne("CinePlus.Models.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowId");

                    b.HasOne("CinePlus.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CinePlus.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CinePlus.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinePlus.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CinePlus.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
