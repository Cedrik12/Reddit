// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedditButBetter.Models.DAL;

#nullable disable

namespace Reddit.Migrations
{
    [DbContext(typeof(RedditContext))]
    partial class RedditContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Reddit.Models.Entities.Commentaire", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("lienid")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .HasColumnType("longtext");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("lienid");

                    b.HasIndex("userid");

                    b.ToTable("commentaires");
                });

            modelBuilder.Entity("Reddit.Models.Entities.Lien", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("image")
                        .HasColumnType("longblob");

                    b.Property<string>("title")
                        .HasColumnType("longtext");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("liens");
                });

            modelBuilder.Entity("Reddit.Models.Entities.Utilisateur", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("utilisateurs");

                    b.HasData(
                        new
                        {
                            id = 5,
                            email = "cedrikcool",
                            password = "yo",
                            username = "cedrik"
                        });
                });

            modelBuilder.Entity("Reddit.Models.Entities.Vote", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("lienid")
                        .HasColumnType("int");

                    b.Property<bool?>("upvote")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("lienid");

                    b.HasIndex("userid");

                    b.ToTable("votes");
                });

            modelBuilder.Entity("Reddit.Models.Entities.Commentaire", b =>
                {
                    b.HasOne("Reddit.Models.Entities.Lien", null)
                        .WithMany("comments")
                        .HasForeignKey("lienid");

                    b.HasOne("Reddit.Models.Entities.Utilisateur", "User")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reddit.Models.Entities.Lien", b =>
                {
                    b.HasOne("Reddit.Models.Entities.Utilisateur", "User")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reddit.Models.Entities.Vote", b =>
                {
                    b.HasOne("Reddit.Models.Entities.Lien", null)
                        .WithMany("votes")
                        .HasForeignKey("lienid");

                    b.HasOne("Reddit.Models.Entities.Utilisateur", "User")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reddit.Models.Entities.Lien", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("votes");
                });
#pragma warning restore 612, 618
        }
    }
}
