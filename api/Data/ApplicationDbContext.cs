using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data 
{
     public class ApplicationDbContext: DbContext 
     {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
       
        }

    
        public DbSet<Ability> Ability { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PkmnType> PkmnType { get; set; }
        public DbSet<BaseStats> BaseStats { get; set; }
        public DbSet<Move> Move { get; set; }
        public DbSet<MoveEffect> MoveEffect { get; set; }
        public DbSet<DamageClass> DamageClass { get; set; }

        public DbSet<PokemonPkmnType> PokemonPkmnType { get; set; }
        public DbSet<PokemonAbility> PokemonAbility { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Register Pokemon-BaseStats one-to-one relationship
            modelBuilder.Entity<Pokemon>()
                .HasOne(e => e.BaseStats)
                .WithOne(e => e.Pokemon)
                .HasForeignKey<BaseStats>();


            // Register Pokemon-PkmnType many-to-many relationship
            modelBuilder.Entity<Pokemon>()
                .HasMany(e => e.PkmnTypes)
                .WithMany(e => e.Pokemon)
                .UsingEntity<PokemonPkmnType>();

            modelBuilder.Entity<PkmnType>()
                .HasMany(e => e.Pokemon)
                .WithMany(e => e.PkmnTypes)
                .UsingEntity<PokemonPkmnType>();


            // Register Pokemon-Ability many-to-many relationship
            modelBuilder.Entity<Pokemon>()
                .HasMany(e => e.Abilities)
                .WithMany(e => e.Pokemon)
                .UsingEntity<PokemonAbility>();

            modelBuilder.Entity<Ability>()
                .HasMany(e => e.Pokemon)
                .WithMany(e => e.Abilities)
                .UsingEntity<PokemonAbility>();

            // Register Pokemon-Gender many-to-many relationship
            modelBuilder.Entity<Pokemon>()
                .HasMany(e => e.Genders)
                .WithMany(e => e.Pokemon)
                .UsingEntity<PokemonGender>();

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Pokemon)
                .WithMany(e => e.Genders)
                .UsingEntity<PokemonGender>();




            /* 
            -------------------------------------------------------------------------
                                     SEED DATABASE
            -------------------------------------------------------------------------
            */

            DataSeeder dataSeeder = new DataSeeder(modelBuilder);
            dataSeeder.SeedAll();
            
        }
    }
}