﻿// <auto-generated />
using HabitBuilder_Backend2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HabitBuilder_Backend2.Migrations
{
    [DbContext(typeof(HabitContext))]
    partial class HabitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HabitBuilder_Backend2.Models.Habit", b =>
                {
                    b.Property<int>("HabitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HabitId"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("DailyCompletion")
                        .HasColumnType("int");

                    b.Property<int>("DateCreated")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("MonthlyCompletion")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearlyCompletion")
                        .HasColumnType("int");

                    b.HasKey("HabitId");

                    b.ToTable("Habits");
                });

            modelBuilder.Entity("HabitBuilder_Backend2.Models.HabitReward", b =>
                {
                    b.Property<int>("HabitId")
                        .HasColumnType("int");

                    b.Property<int>("RewardId")
                        .HasColumnType("int");

                    b.HasKey("HabitId", "RewardId");

                    b.HasIndex("RewardId");

                    b.ToTable("HabitRewards");
                });

            modelBuilder.Entity("HabitBuilder_Backend2.Models.Reward", b =>
                {
                    b.Property<int>("RewardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RewardId"), 1L, 1);

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RewardId");

                    b.ToTable("Rewards");
                });

            modelBuilder.Entity("HabitBuilder_Backend2.Models.HabitReward", b =>
                {
                    b.HasOne("HabitBuilder_Backend2.Models.Habit", "Habits")
                        .WithMany("HabitRewards")
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitBuilder_Backend2.Models.Reward", "Rewards")
                        .WithMany("HabitRewards")
                        .HasForeignKey("RewardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habits");

                    b.Navigation("Rewards");
                });

            modelBuilder.Entity("HabitBuilder_Backend2.Models.Habit", b =>
                {
                    b.Navigation("HabitRewards");
                });

            modelBuilder.Entity("HabitBuilder_Backend2.Models.Reward", b =>
                {
                    b.Navigation("HabitRewards");
                });
#pragma warning restore 612, 618
        }
    }
}