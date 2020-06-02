﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnovaBooster.Database;

namespace UnovaBooster.Migrations
{
    [DbContext(typeof(PokeContext))]
    [Migration("20200529184511_Locations")]
    partial class Locations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UnovaBooster.Entities.ElementType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ElementTypes");
                });

            modelBuilder.Entity("UnovaBooster.Entities.GymLeader", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("GymLeaders");
                });

            modelBuilder.Entity("UnovaBooster.Entities.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ItemTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PlayerID")
                        .HasColumnType("int");

                    b.Property<decimal>("StoreOriginalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("StorePromotionalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ID");

                    b.HasIndex("ItemTypeID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("UnovaBooster.Entities.ItemType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("UnovaBooster.Entities.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("UnovaBooster.Entities.Map", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Gym")
                        .HasColumnType("bit");

                    b.Property<int?>("GymLeaderID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("GymLeaderID")
                        .IsUnique();

                    b.HasIndex("RegionID");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("UnovaBooster.Entities.Move", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("ElementTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PokemonSpecimenID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ElementTypeID");

                    b.HasIndex("PokemonSpecimenID");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("UnovaBooster.Entities.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("ICS")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("UnovaBooster.Entities.Pokemon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("BaseAttack")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("BaseDeffense")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("BaseHP")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("BaseSpAttack")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("BaseSpDeffense")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("BaseSpeed")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("MaxAttack")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("MaxDeffense")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("MaxHP")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("MaxSpAttack")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("MaxSpDeffense")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("MaxSpeed")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("UnovaBooster.Entities.PokemonElementType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ElementTypeID")
                        .HasColumnType("int");

                    b.Property<int>("PokemonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ElementTypeID");

                    b.HasIndex("PokemonID");

                    b.ToTable("PokemonElementTypes");
                });

            modelBuilder.Entity("UnovaBooster.Entities.PokemonMove", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MoveID")
                        .HasColumnType("int");

                    b.Property<int>("PokemonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MoveID");

                    b.HasIndex("PokemonID");

                    b.ToTable("PokemonMoves");
                });

            modelBuilder.Entity("UnovaBooster.Entities.PokemonMoveByLevel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int?>("PokemonID")
                        .HasColumnType("int");

                    b.Property<int>("PokemonMoveID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PokemonID");

                    b.HasIndex("PokemonMoveID");

                    b.ToTable("PokemonMovesByLevel");
                });

            modelBuilder.Entity("UnovaBooster.Entities.PokemonSpecimen", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("CurrentHP")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("Fainted")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<decimal>("MaxHP")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("PlayerID")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerID1")
                        .HasColumnType("int");

                    b.Property<int>("PokemonID")
                        .HasColumnType("int");

                    b.Property<int>("VariationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("PlayerID1");

                    b.HasIndex("PokemonID");

                    b.ToTable("PokemonSpecimens");
                });

            modelBuilder.Entity("UnovaBooster.Entities.PokemonTM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PokemonTMs");
                });

            modelBuilder.Entity("UnovaBooster.Entities.Region", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("UnovaBooster.Entities.TM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MoveID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("PokemonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MoveID");

                    b.HasIndex("PokemonID");

                    b.ToTable("TMs");
                });

            modelBuilder.Entity("UnovaBooster.Entities.Variation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Variations");
                });

            modelBuilder.Entity("UnovaBooster.Entities.Item", b =>
                {
                    b.HasOne("UnovaBooster.Entities.ItemType", "Type")
                        .WithMany()
                        .HasForeignKey("ItemTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnovaBooster.Entities.Player", null)
                        .WithMany("Items")
                        .HasForeignKey("PlayerID");
                });

            modelBuilder.Entity("UnovaBooster.Entities.Map", b =>
                {
                    b.HasOne("UnovaBooster.Entities.GymLeader", "GymLeader")
                        .WithOne("Map")
                        .HasForeignKey("UnovaBooster.Entities.Map", "GymLeaderID");

                    b.HasOne("UnovaBooster.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionID");
                });

            modelBuilder.Entity("UnovaBooster.Entities.Move", b =>
                {
                    b.HasOne("UnovaBooster.Entities.ElementType", "ElementType")
                        .WithMany("Moves")
                        .HasForeignKey("ElementTypeID");

                    b.HasOne("UnovaBooster.Entities.PokemonSpecimen", null)
                        .WithMany("Moves")
                        .HasForeignKey("PokemonSpecimenID");
                });

            modelBuilder.Entity("UnovaBooster.Entities.PokemonElementType", b =>
                {
                    b.HasOne("UnovaBooster.Entities.ElementType", "ElementType")
                        .WithMany()
                        .HasForeignKey("ElementTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnovaBooster.Entities.Pokemon", "Pokemon")
                        .WithMany("ElementTypes")
                        .HasForeignKey("PokemonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UnovaBooster.Entities.PokemonMove", b =>
                {
                    b.HasOne("UnovaBooster.Entities.Move", "Move")
                        .WithMany()
                        .HasForeignKey("MoveID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnovaBooster.Entities.Pokemon", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UnovaBooster.Entities.PokemonMoveByLevel", b =>
                {
                    b.HasOne("UnovaBooster.Entities.Pokemon", null)
                        .WithMany("MovesByLevel")
                        .HasForeignKey("PokemonID");

                    b.HasOne("UnovaBooster.Entities.PokemonMove", "PokemonMove")
                        .WithMany()
                        .HasForeignKey("PokemonMoveID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UnovaBooster.Entities.PokemonSpecimen", b =>
                {
                    b.HasOne("UnovaBooster.Entities.Player", null)
                        .WithMany("CapturedPokemon")
                        .HasForeignKey("PlayerID");

                    b.HasOne("UnovaBooster.Entities.Player", null)
                        .WithMany("CurrentPokemonTeam")
                        .HasForeignKey("PlayerID1");

                    b.HasOne("UnovaBooster.Entities.Pokemon", "pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UnovaBooster.Entities.TM", b =>
                {
                    b.HasOne("UnovaBooster.Entities.Move", "Move")
                        .WithMany()
                        .HasForeignKey("MoveID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnovaBooster.Entities.Pokemon", null)
                        .WithMany("TmMoves")
                        .HasForeignKey("PokemonID");
                });
#pragma warning restore 612, 618
        }
    }
}
