using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MStart.DataAccess.Entities
{
    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<LookupCategory> LookupCategories { get; set; }
        public virtual DbSet<LookupCategoryCulture> LookupCategoryCultures { get; set; }
        public virtual DbSet<LookupCulture> LookupCultures { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        public virtual DbSet<Tranaction> Tranactions { get; set; }
        public virtual DbSet<UserImage> UserImages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Account_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Account>()
                .Property(e => e.Available_Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Account>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Tranactions)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.Account_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Culture>()
                .Property(e => e.CultureName)
                .IsUnicode(false);

            modelBuilder.Entity<Culture>()
                .HasMany(e => e.LookupCultures)
                .WithRequired(e => e.Culture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LookupCategory>()
                .Property(e => e.FixedCode)
                .IsUnicode(false);

            modelBuilder.Entity<LookupCategory>()
                .HasMany(e => e.LookupCategories1)
                .WithOptional(e => e.LookupCategory1)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<LookupCategory>()
                .HasMany(e => e.Lookups)
                .WithRequired(e => e.LookupCategory)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Lookup>()
                .Property(e => e.LookupCode)
                .IsUnicode(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Lookup)
                .HasForeignKey(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Lookup)
                .HasForeignKey(e => e.Gender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Lookups1)
                .WithOptional(e => e.Lookup1)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Tranaction>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Tranaction>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<UserImage>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.UserImage)
                .HasForeignKey(e => e.PhotoId);

            modelBuilder.Entity<User>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile_Number)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tranactions)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
