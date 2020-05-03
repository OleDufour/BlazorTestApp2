﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorAppMysql.Server.DBModels
{
    public partial class PropositionVoterContext : DbContext
    {
        public PropositionVoterContext()
        {
        }

        public PropositionVoterContext(DbContextOptions<PropositionVoterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Discussion> Discussion { get; set; }
        public virtual DbSet<Proposition> Proposition { get; set; }
        public virtual DbSet<UserProposition> UserProposition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=127.0.0.1;Port=3306;Database=PropositionVoter;user id=root;Pwd=;SslMode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.HasIndex(e => e.PropositionId)
                    .HasName("fk_Discussion_Proposition_idx");

                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.Proposition)
                    .WithMany(p => p.Discussion)
                    .HasForeignKey(d => d.PropositionId)
                    .HasConstraintName("fk_Discussion_Proposition");
            });

            modelBuilder.Entity<Proposition>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<UserProposition>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("idUser_Voted_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PropositionId)
                    .HasName("fk_User_Proposition_Proposition_idx");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.HasOne(d => d.Proposition)
                    .WithMany(p => p.UserProposition)
                    .HasForeignKey(d => d.PropositionId)
                    .HasConstraintName("fk_User_Proposition_Proposition");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
