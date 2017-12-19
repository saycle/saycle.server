﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using saycle.server.Data;
using saycle.server.Models.Enums;
using System;

namespace saycle.server.Migrations
{
    [DbContext(typeof(SaycleContext))]
    [Migration("20171219151316_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("saycle.server.Models.Bookmark", b =>
                {
                    b.Property<Guid>("BookmarkID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreationTime");

                    b.Property<Guid>("StoryID");

                    b.Property<Guid>("UserID");

                    b.HasKey("BookmarkID");

                    b.HasIndex("StoryID");

                    b.HasIndex("UserID");

                    b.ToTable("Bookmark");
                });

            modelBuilder.Entity("saycle.server.Models.Cycle", b =>
                {
                    b.Property<Guid>("CycleID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreationTime");

                    b.Property<bool>("Deleted");

                    b.Property<Guid>("StoryID");

                    b.Property<string>("Text");

                    b.Property<Guid>("UserID");

                    b.HasKey("CycleID");

                    b.HasIndex("StoryID");

                    b.HasIndex("UserID");

                    b.ToTable("Cycles");
                });

            modelBuilder.Entity("saycle.server.Models.Favorite", b =>
                {
                    b.Property<Guid>("UserID");

                    b.Property<Guid>("StoryID");

                    b.HasKey("UserID", "StoryID");

                    b.HasAlternateKey("StoryID", "UserID");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("saycle.server.Models.Language", b =>
                {
                    b.Property<Guid>("LanguageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("LanguageID");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("saycle.server.Models.Login", b =>
                {
                    b.Property<Guid>("LoginID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Browser");

                    b.Property<string>("IP");

                    b.Property<string>("Region");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("Url");

                    b.Property<Guid>("UserID");

                    b.HasKey("LoginID");

                    b.HasIndex("UserID");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("saycle.server.Models.Rating", b =>
                {
                    b.Property<Guid>("RatingID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreationTime");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<Guid>("UserID");

                    b.Property<int>("Value");

                    b.HasKey("RatingID");

                    b.HasIndex("UserID");

                    b.ToTable("Ratings");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Rating");
                });

            modelBuilder.Entity("saycle.server.Models.Story", b =>
                {
                    b.Property<Guid>("StoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreationTime");

                    b.Property<Guid>("CreatorID");

                    b.Property<bool>("Deleted");

                    b.Property<Guid>("LanguageID");

                    b.Property<int>("Mode");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("StoryID");

                    b.HasIndex("CreatorID");

                    b.HasIndex("LanguageID");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("saycle.server.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Birthday");

                    b.Property<DateTime?>("CreationTime");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<bool>("Verified");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("saycle.server.Models.UserLanguage", b =>
                {
                    b.Property<Guid>("UserID");

                    b.Property<Guid>("LanguageID");

                    b.HasKey("UserID", "LanguageID");

                    b.HasAlternateKey("LanguageID", "UserID");

                    b.ToTable("UserLanguage");
                });

            modelBuilder.Entity("saycle.server.Models.Visit", b =>
                {
                    b.Property<Guid>("VisitID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("StoryID");

                    b.Property<DateTime>("Timestamp");

                    b.Property<Guid>("UserID");

                    b.HasKey("VisitID");

                    b.HasIndex("StoryID");

                    b.HasIndex("UserID");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("saycle.server.Models.StoryRating", b =>
                {
                    b.HasBaseType("saycle.server.Models.Rating");

                    b.Property<Guid?>("CycleID");

                    b.Property<Guid>("StoryID");

                    b.HasIndex("CycleID");

                    b.HasIndex("StoryID");

                    b.ToTable("StoryRating");

                    b.HasDiscriminator().HasValue("StoryRating");
                });

            modelBuilder.Entity("saycle.server.Models.Bookmark", b =>
                {
                    b.HasOne("saycle.server.Models.Story", "Story")
                        .WithMany("Bookmarks")
                        .HasForeignKey("StoryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("saycle.server.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("saycle.server.Models.Cycle", b =>
                {
                    b.HasOne("saycle.server.Models.Story", "Story")
                        .WithMany("Cycles")
                        .HasForeignKey("StoryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("saycle.server.Models.User", "Author")
                        .WithMany("Cycles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("saycle.server.Models.Favorite", b =>
                {
                    b.HasOne("saycle.server.Models.Story", "Story")
                        .WithMany()
                        .HasForeignKey("StoryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("saycle.server.Models.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("saycle.server.Models.Login", b =>
                {
                    b.HasOne("saycle.server.Models.User", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("saycle.server.Models.Rating", b =>
                {
                    b.HasOne("saycle.server.Models.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("saycle.server.Models.Story", b =>
                {
                    b.HasOne("saycle.server.Models.User", "Creator")
                        .WithMany("CreatedStories")
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("saycle.server.Models.Language", "Language")
                        .WithMany("Stories")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("saycle.server.Models.UserLanguage", b =>
                {
                    b.HasOne("saycle.server.Models.Language", "Language")
                        .WithMany("Users")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("saycle.server.Models.User", "User")
                        .WithMany("Languages")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("saycle.server.Models.Visit", b =>
                {
                    b.HasOne("saycle.server.Models.Story", "Story")
                        .WithMany()
                        .HasForeignKey("StoryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("saycle.server.Models.User", "User")
                        .WithMany("Visits")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("saycle.server.Models.StoryRating", b =>
                {
                    b.HasOne("saycle.server.Models.Cycle")
                        .WithMany("Ratings")
                        .HasForeignKey("CycleID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("saycle.server.Models.Story", "Story")
                        .WithMany("Ratings")
                        .HasForeignKey("StoryID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}