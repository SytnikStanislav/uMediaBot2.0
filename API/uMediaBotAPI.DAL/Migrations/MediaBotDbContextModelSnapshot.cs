﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using uMediaBotAPI.DAL.Data;

namespace uMediaBotAPI.DAL.Migrations
{
    [DbContext(typeof(MediaBotDbContext))]
    partial class MediaBotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("uMediaBotAPI.DAL.Entities.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentData");

                    b.Property<DateTime>("UploadTime");

                    b.HasKey("Id");

                    b.ToTable("Contets");
                });

            modelBuilder.Entity("uMediaBotAPI.DAL.Entities.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("PreviousFolderId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Folders");
                });
#pragma warning restore 612, 618
        }
    }
}
