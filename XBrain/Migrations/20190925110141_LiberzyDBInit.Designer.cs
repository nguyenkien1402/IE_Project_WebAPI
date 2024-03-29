﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XBrain.Models;

namespace XBrain.Migrations
{
    [DbContext(typeof(XBrainContext))]
    [Migration("20190925110141_LiberzyDBInit")]
    partial class LiberzyDBInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XBrain.Models.DailyActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivityContent")
                        .HasMaxLength(250);

                    b.Property<string>("ActivityTitle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateAchieve")
                        .HasColumnType("date");

                    b.Property<double>("NumberOfHour");

                    b.Property<double>("TargetHour");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DailyActivity");
                });

            modelBuilder.Entity("XBrain.Models.DailyRoutine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan?>("ActualEndTime");

                    b.Property<TimeSpan?>("ActualStartTime");

                    b.Property<DateTime>("DateAchieve")
                        .HasColumnType("date");

                    b.Property<string>("DayOperation")
                        .HasMaxLength(100);

                    b.Property<TimeSpan>("PlanEndTime");

                    b.Property<TimeSpan>("PlanStartTime");

                    b.Property<string>("RoutineContent");

                    b.Property<string>("RoutineTitle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DailyRoutine");
                });

            modelBuilder.Entity("XBrain.Models.SleepingTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateAchieve")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("SleepTime");

                    b.Property<int>("UserId");

                    b.Property<TimeSpan?>("WakingupTime");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SleepingTime");
                });

            modelBuilder.Entity("XBrain.Models.XbrainUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeviceId")
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasMaxLength(100);

                    b.Property<string>("HashPassword")
                        .HasMaxLength(250);

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("XBrainUser");
                });

            modelBuilder.Entity("XBrain.Models.DailyActivity", b =>
                {
                    b.HasOne("XBrain.Models.XbrainUser", "User")
                        .WithMany("DailyActivity")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__DailyActi__UserI__403A8C7D");
                });

            modelBuilder.Entity("XBrain.Models.DailyRoutine", b =>
                {
                    b.HasOne("XBrain.Models.XbrainUser", "User")
                        .WithMany("DailyRoutine")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__DailyRout__Actua__3B75D760");
                });

            modelBuilder.Entity("XBrain.Models.SleepingTime", b =>
                {
                    b.HasOne("XBrain.Models.XbrainUser", "User")
                        .WithMany("SleepingTime")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__SleepingT__UserI__49C3F6B7");
                });
#pragma warning restore 612, 618
        }
    }
}
