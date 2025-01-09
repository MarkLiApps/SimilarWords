﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistance.EfCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250105212539_Adding WordStudyLog Table")]
    partial class AddingWordStudyLogTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.WordStudy.Word", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ExampleSoundUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("MeaningLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeaningShort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pronounciation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PronounciationAm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SimilarWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoundUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Words", (string)null);
                });

            modelBuilder.Entity("ApplicationCore.WordStudy.WordStudy", b =>
                {
                    b.Property<string>("UserName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("WordName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DaysToStudy")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastStudyTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTimeUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("UserName", "WordName");

                    b.ToTable("WordStudies", (string)null);
                });

            modelBuilder.Entity("ApplicationCore.WordStudy.WordStudyLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ScheduledStudyTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StudyTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("WordStudyId")
                        .HasColumnType("int");

                    b.Property<string>("WordStudyUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("WordStudyWordName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("WordStudyUserName", "WordStudyWordName");

                    b.ToTable("WordStudyLog");
                });

            modelBuilder.Entity("ApplicationCore.WordStudy.WordStudyLog", b =>
                {
                    b.HasOne("ApplicationCore.WordStudy.WordStudy", null)
                        .WithMany("WordStudyLogs")
                        .HasForeignKey("WordStudyUserName", "WordStudyWordName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationCore.WordStudy.WordStudy", b =>
                {
                    b.Navigation("WordStudyLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
